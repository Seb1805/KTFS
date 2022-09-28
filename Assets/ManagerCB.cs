using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerCB : MonoBehaviour
{
    int guessNumber;
    int bulls;
    int cows;
    public Text GameInstruction;
    public GameObject inputField;
    int randomNumber = 0; 

    public void CheckNumber()
    {
        if (randomNumber == 0) randomNumber = Random.Range(100, 999);
        Debug.LogError(randomNumber);

        int RandomDigit1 = (randomNumber / 100) % 10;
        int RandomDigit2 = (randomNumber / 10) % 10;
        int RandomDigit3 = (randomNumber / 1) % 10;
        int.TryParse(inputField.GetComponent<InputField>().text, out guessNumber);

        bulls = 0;
        cows = 0;
        int guessDigit1 = (guessNumber / 100) % 10;
        int guessDigit2 = (guessNumber / 10) % 10;
        int guessDigit3 = (guessNumber / 1) % 10;

        if (guessDigit1 == RandomDigit1) bulls++;
        else if (guessDigit1 == RandomDigit2) cows++;
        else if (guessDigit1 == RandomDigit3) cows++;

        if (guessDigit2 == RandomDigit2) bulls++;
        else if (guessDigit2 == RandomDigit1) cows++;
        else if (guessDigit2 == RandomDigit3) cows++;

        if (guessDigit3 == RandomDigit3) bulls++;
        else if (guessDigit3 == RandomDigit1) cows++;
        else if (guessDigit3 == RandomDigit2) cows++;


        GameInstruction.text += guessNumber + " Bulls: " + bulls + " Cows: " + cows + " ";

        if(bulls == 3)
        {
            SaveDataBetweenScenes savedata = GameObject.Find("DataBetweenScenes").GetComponent<SaveDataBetweenScenes>();
            savedata.door.GetComponent<DoorScript>().UnlockDoor();
            //DoorScript.UnlockDoor();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.UnloadSceneAsync("HackTwoCB");
            Debug.LogError("Done did it");
        }
        
        // Den nedenunder skal bruges når vi skal åbne denne scene
        //SceneManger.LoadScene("HackTwoCB", LoadSceneMode.Additive)
    }
}