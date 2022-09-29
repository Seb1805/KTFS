using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerMN : MonoBehaviour
{
    int guessNumber;
    public Text GameInstruction;
    public GameObject inputField;
    int randomNumber = 0;
    int txtConter = 0;

    public void CheckNumber()
    {
        txtConter++;
        if (randomNumber == 0) randomNumber = Random.Range(0, 999);
        Debug.Log(randomNumber);

        if (txtConter == 10)
        {
            GameInstruction.text = "";
            txtConter = 0;
        }

        int.TryParse(inputField.GetComponent<InputField>().text, out guessNumber);

        if (guessNumber > randomNumber)
        {
            GameInstruction.text += guessNumber + " Your guess was to high! ";
        }
        else if (guessNumber < randomNumber)
        {
            GameInstruction.text += guessNumber + " Your guess was to low! ";
        }
        else if (guessNumber == 123321)
        {
            win();
        }
        else win();

        // Den nedenunder skal bruges når vi skal åbne denne scene
        //SceneManger.LoadScene("HackTwoCB", LoadSceneMode.Additive)
    }

    private void win()
    {
        SaveDataBetweenScenes savedata = GameObject.Find("DataBetweenScenes").GetComponent<SaveDataBetweenScenes>();
        savedata.door.GetComponent<DoorScript>().UnlockDoor();
        //DoorScript.UnlockDoor();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.UnloadSceneAsync("HackThreeMN");
    }
}