using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkTest : MonoBehaviour
{
    public string url;
    Button getbutton;
    Button postbutton;

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
        UnityWebRequest www = new UnityWebRequest(url);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log($"GET: failed");
        }
        else
        {
            Debug.Log($"Success Get");
        }

    }

    private void OnButtonPostScore()
    {
        StartCoroutine(SimplePostRequest());
    }

    IEnumerator SimplePostRequest()
    {
        WWWForm wwwF = new WWWForm();

        wwwF.AddField("name", "Wirk");
        wwwF.AddField("score", 10923);

        UnityWebRequest www = UnityWebRequest.Post(url, wwwF);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log($"POST: failed");
        }
        else
        {
            Debug.Log($"Success POST");
        }

    }
}
