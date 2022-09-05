using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCB : MonoBehaviour
{
    int guessNumber;
    int bulls;
    int cows;
    public Text GameInstruction;
    public GameObject inputField;

    public void CheckNumber()
    {
        
        int randomNumber = 678; //skal have et random nummer
        
        int RandomDigit1 = (randomNumber / 100) % 10;
        int RandomDigit2 = (randomNumber / 10) % 10;
        int RandomDigit3 = (randomNumber / 1) % 10;

        //string brr = inputField.GetComponent<InputField>().text;
        int.TryParse(inputField.GetComponent<InputField>().text, out guessNumber);

        //int.TryParse(inputField.GetComponent<Text>().text, out guessNumber); // input value
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
        
        // Den nedenunder skal bruges når vi skal åbne denne scene
        //SceneManger.LoadScene("HackTwoCB", LoadSceneMode.Additive)
    }
}