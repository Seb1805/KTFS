using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;

    float TotalClicks;

    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");

        // Tilføj tjek på om TotalClicks er lig 50 og derefter forlade scenen 
        if (TotalClicks == 20)
        {
            SaveDataBetweenScenes savedata = GameObject.Find("DataBetweenScenes").GetComponent<SaveDataBetweenScenes>();
            savedata.door.GetComponent<DoorScript>().UnlockDoor();
            //DoorScript.UnlockDoor();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.UnloadSceneAsync("HackOneClicker");
        }
        // Den nedenunder skal bruges når vi skal åbne denne scene 
        //SceneManger.LoadScene("HackOneClick", LoadSceneMode.Additive)
    }
}
