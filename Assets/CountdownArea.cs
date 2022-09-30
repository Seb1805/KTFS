using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class CountdownArea : MonoBehaviour
{
    public bool saveTimer = false;
    public float timeInSeconds = 20;

    float clockSpeed = 1f;
    float countdownTimer;
    bool startTimer = false;
    bool completed = false;

    public GameObject generalTimerAreaUI;
    TextMeshProUGUI countdownTimerUI;


    void Start()
    {
        //CountdownTimer = TimeInSeconds;
        countdownTimer = 30;

        countdownTimerUI = generalTimerAreaUI.transform.Find("GeneralTimerText").GetComponent<TextMeshProUGUI>();

        generalTimerAreaUI.SetActive(false);
    }

    void Update()
    {
        if (startTimer)
        {
            countdownTimer = countdownTimer - Time.deltaTime * clockSpeed;

            if (countdownTimer >= 10)
            {
                countdownTimerUI.text = TimeSpan.FromSeconds(countdownTimer).ToString("mm\\:ss");
            }
            else
            {
                countdownTimerUI.text = TimeSpan.FromSeconds(countdownTimer).ToString("ss\\.ff");
            }
            if (countdownTimer < 0)
            {
                // Some sort of feedback; sound, light, a change, UI element
                generalTimerAreaUI.SetActive(false);
                completed = true;
                ObjectiveController objectiveController = GameObject.Find("MissionController").GetComponent<ObjectiveController>();
                objectiveController.ProtectShip();
            }

        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            generalTimerAreaUI.SetActive(true);
            startTimer = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTimer = false;
            generalTimerAreaUI.SetActive(false);
            if (!saveTimer)
            {
                countdownTimer = timeInSeconds;
            }
        }
    }
}
