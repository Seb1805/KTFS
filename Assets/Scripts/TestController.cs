using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TestController : MonoBehaviour
{

    public string url = "https://localhost:7035/api/highscore";


    //InputField outputArea;

    //void Start()
    //{

    //    outputArea = GameObject.Find("Highscores").GetComponent<InputField>();
    //    GetData();
    //    //GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    //}

    //void GetData() => StartCoroutine(GetData_Coroutine());

    //IEnumerator GetData_Coroutine()
    //{
    //    outputArea.text = "Loading...";
    //    string uri = "https://my-json-server.typicode.com/typicode/demo/posts";
    //    using (UnityWebRequest request = UnityWebRequest.Get(uri))
    //    {
    //        yield return request.SendWebRequest();
    //        if (request.result == UnityWebRequest.Result.Success)
    //            outputArea.text = request.downloadHandler.text;
    //        else
    //            outputArea.text = request.error;
    //    }
    //}

    [ContextMenu("Test Get")]
    public async void TestGet()
    {

        using var www = UnityWebRequest.Get(url);

        //www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (www.result == UnityWebRequest.Result.Success)
            Debug.Log($"Success: {www.downloadHandler.text}");
        else
            Debug.Log($"Failed: {www.error}");
    }


    [ContextMenu("Test Post")]
    public async void TestPost()
    {
        var playerInfo = new Person
        {
            name = "Marc",
            score = 400
        };
        
        string test = JsonConvert.SerializeObject(playerInfo);

        //WWWForm form = new WWWForm();
        //form.AddField("name", "Marc");
        //form.AddField("score", 4230);

        //using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        //{
        //    yield return request.SendWebRequest();
        //    if(request.isNetworkError || request.isHttpError)
        //    {
        //        Debug.Log($"POST Failed - Error code: {request.error}");
        //    }
                
        //    else
        //    {
        //        Debug.Log($"Success: {test} was sent");
        //    }

        //}

        WWWForm form = new WWWForm();
        form.AddField("name", "Marc");
        form.AddField("score", 4230);


        using UnityWebRequest wwwP = UnityWebRequest.Post(url, form);

        var operation = wwwP.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (wwwP.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {test} was sent");
            TestGet();
        }
        else
        {
            Debug.Log($"POST Failed: {wwwP.uploadHandler.data.ToString()}");
            Debug.Log($"Error code: {wwwP.error}");
            Debug.Log($"Sended information: {test}");
        }
    }

}

public class Person
{
    public string name { get; set; }
    public int score { get; set; }
}