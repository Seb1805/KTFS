using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkTest : MonoBehaviour
{
    public string url;
    Button getbutton;
    Button postbutton;
    GameObject table;
    public GameObject HighscoreRow;

    void Start()
    {
        table = GameObject.Find("Table");

        getbutton = GameObject.Find("GetButton").GetComponent<Button>();
        postbutton = GameObject.Find("PostButton").GetComponent<Button>();

        getbutton.onClick.AddListener(OnButtonGetScore);
        postbutton.onClick.AddListener(OnButtonPostScore);
    }

    private void OnButtonGetScore()
    {
        StartCoroutine(SimpleGetRequest());
    }

    IEnumerator SimpleGetRequest()
    {

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log($"GET: failed");
            }
            else
            {
                Debug.Log($"Success GET ");
                //Debug.Log($"{request.downloadHandler.text}");
                
                List<PlayerData> leaderboardScores = JsonConvert.DeserializeObject<List<PlayerData>>(request.downloadHandler.text).OrderByDescending(x => x.Score).ToList();
            
                foreach(Transform item in table.transform)
                {
                    Destroy(item.gameObject);
                }


                for(int i = 0; i < leaderboardScores.Count(); i++)
                {
                    if(i >= 10)
                    {
                        break;
                    }
                    GameObject playerInfo = Instantiate(HighscoreRow, table.transform);
                    TextMeshProUGUI playerPlaceDisplay = playerInfo.transform.Find("Place").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI playerNameDisplay = playerInfo.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI playerScoreDisplay = playerInfo.transform.Find("Score").GetComponent<TextMeshProUGUI>();


                    playerPlaceDisplay.text = $"{i + 1}";
                    playerNameDisplay.text = leaderboardScores[i].Name;
                    playerScoreDisplay.text = leaderboardScores[i].Score.ToString();

                }


                
                

            }
        }

    }

    private void OnButtonPostScore()
    {
        StartCoroutine(SimplePostRequest());
    }

    [Obsolete]
    IEnumerator SimplePostRequest()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", "test Unity");
        form.AddField("score", 364);

        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log($"POST: failed");
            }
            else
            {
                Debug.Log($"Success POST ");
                
            }
        }
        
    }
}
