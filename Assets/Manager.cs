using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;

    float TotalClicks;

    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");

        // Tilføj tjek på om TotalClicks er lig 50 og derefter forlade scenen 
        //if (TotalClicks == 50)
        //{
        //    SceneManger.UnloadSceneAsync("HackOneClick")
        //}
        // Den nedenunder skal bruges når vi skal åbne denne scene 
        //SceneManger.LoadScene("HackOneClick", LoadSceneMode.Additive)
    }
}
