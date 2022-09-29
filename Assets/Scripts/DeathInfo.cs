using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathInfo : MonoBehaviour
{
    TextMeshProUGUI reasonOfDeath;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (LevelChangerController.instance.completed)
        {
            GameObject.Find("Death").SetActive(false);
        }
        else
        {
            GameObject.Find("Win").SetActive(false);
            GameObject.Find("NetworkController").SetActive(false);
            reasonOfDeath = GameObject.Find("DeathText").GetComponent<TextMeshProUGUI>();
            reasonOfDeath.text = LevelChangerController.instance.reason;

        }

    }

    // Update is called once per frame
    void Update()
    {

        
        //reasonOfDeath.text = "this is a test template text";

    }
}
