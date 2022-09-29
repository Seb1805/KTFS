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
    public GameObject HighscoreRow;

    void Start()
    {
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
                
                List<PlayerData> leaderboardScores = JsonConvert.DeserializeObject<List<PlayerData>>(request.downloadHandler.text);
            
                foreach (var item in leaderboardScores)
                {
                    Debug.Log(item);
                }


            }
        }



        //UnityWebRequest www = new UnityWebRequest(url);

        //yield return www.SendWebRequest();

        //if(www.isNetworkError || www.isHttpError)
        //{
        //    Debug.Log($"GET: failed");
        //}
        //else
        //{
        //    Debug.Log($"Success Get: {www.downloadHandler}");
        //}

    }

    private void OnButtonPostScore()
    {
        StartCoroutine(SimplePostRequest());
    }

    [Obsolete]
    IEnumerator SimplePostRequest()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", "test data");
        form.AddField("score", 0);

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
