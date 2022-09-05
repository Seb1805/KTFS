using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMN : MonoBehaviour
{
    int guessNumber;
    public Text GameInstruction;
    public GameObject inputField;
    int randomNumber = 0;

    public void CheckNumber()
    {
        if (randomNumber == 0) randomNumber = Random.Range(0, 999);
        Debug.Log("wAA AWAA" + randomNumber);

        int.TryParse(inputField.GetComponent<InputField>().text, out guessNumber);

        if (guessNumber > randomNumber)
        {
            GameInstruction.text += guessNumber + " Your guess was to high! ";
        }
        else if (guessNumber < randomNumber)
        {
            GameInstruction.text += guessNumber + " Your guess was to low! ";
        }
        else
        {
            GameInstruction.text += "You won bitch 'Skift til anden scene'"; 
        }

        // Den nedenunder skal bruges når vi skal åbne denne scene
        //SceneManger.LoadScene("HackTwoCB", LoadSceneMode.Additive)
    }
}