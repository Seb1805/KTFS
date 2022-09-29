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
    Button postbutton;
    GameObject table;

    GameObject leaderboard;
    GameObject posting;
    GameObject offlineScore;
    GameObject serverConnectionMessage;
    GameObject loading;

    public string url;
    public GameObject HighscoreRow;
    public GameObject inputfield;
    public int bestOfTheBest = 5;

    bool allowPosting = true;
    string tempInput;

    private void Awake()
    {
        table = GameObject.Find("Table");

        postbutton = GameObject.Find("PostButton").GetComponent<Button>();

        leaderboard = GameObject.Find("Leaderboard");
        posting = GameObject.Find("postArea");
        offlineScore = GameObject.Find("OfflineScoreText");
        serverConnectionMessage = GameObject.Find("ServerConnectionText");
        loading = GameObject.Find("Loading");

        leaderboard.SetActive(false);
        posting.SetActive(false);
        offlineScore.SetActive(false);
        serverConnectionMessage.SetActive(false);

       
            StartCoroutine(SimpleGetRequest());
        
    }
    void Start()
    {

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

                loading.SetActive(false);
                serverConnectionMessage.SetActive(true);
                offlineScore.SetActive(true);
                offlineScore.GetComponent<TextMeshProUGUI>().text = $"Your score: {TimeSpan.FromSeconds((int)LevelChangerController.instance.score).ToString("mm\\:ss")}";

                yield break;

            }
            else
            {
                loading.SetActive(false);
                Debug.Log($"Success GET ");
                //Debug.Log($"{request.downloadHandler.text}");
                
                List<PlayerData> leaderboardScores = JsonConvert.DeserializeObject<List<PlayerData>>(request.downloadHandler.text).OrderBy(x => x.score).ToList();
            
                foreach(Transform item in table.transform)
                {
                    Destroy(item.gameObject);
                }

                
                if(LevelChangerController.instance.score < leaderboardScores[bestOfTheBest - 1].score && allowPosting)
                {
                    leaderboard.SetActive(false);
                    posting.SetActive(true);
                    allowPosting = false;
                } 
                else
                {
                    leaderboard.SetActive(true);
                    posting.SetActive(false);
                    for (int i = 0; i < leaderboardScores.Count(); i++)
                    {
                        if (i >= bestOfTheBest)
                        {
                            break;
                        }

                        GameObject playerInfo = Instantiate(HighscoreRow, table.transform);
                        TextMeshProUGUI playerPlaceDisplay = playerInfo.transform.Find("Place").GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI playerNameDisplay = playerInfo.transform.Find("Name").GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI playerScoreDisplay = playerInfo.transform.Find("Score").GetComponent<TextMeshProUGUI>();

                        

                        playerPlaceDisplay.text = $"{i + 1}";
                        playerNameDisplay.text = leaderboardScores[i].name;
                        playerScoreDisplay.text = TimeSpan.FromSeconds(leaderboardScores[i].score).ToString("mm\\:ss");


                        
                    }
                }
            }
        }

    }

    public void OnButtonPostScore()
    {
        tempInput = inputfield.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().text;
        Debug.Log(tempInput);
        StartCoroutine(SimplePostRequest());
    }

    [Obsolete]
    public IEnumerator SimplePostRequest()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", tempInput);
        form.AddField("score", (int)LevelChangerController.instance.score);

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
                posting.SetActive(false);
                StartCoroutine(SimpleGetRequest());
            }
        }
        
    }
}
