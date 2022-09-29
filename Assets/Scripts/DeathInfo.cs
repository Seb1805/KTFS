using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathInfo : MonoBehaviour
{
    TextMeshProUGUI reasonOfDeath;

    private void Awake()
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

}
