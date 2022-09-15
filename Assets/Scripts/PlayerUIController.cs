using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    // HP
    float maxHealth = 100;
    float health;
    Slider healthBar;

    // Timer
    float timeDuration = 2f * 60f;
    float time;
    int minutes = 0;
    bool startTimer = false;

    // UI elements
    public GameObject interactMessage;
    public GameObject timerUIHolder;
    public GameObject timerUI;
    TextMeshProUGUI timerMinutes;
    TextMeshProUGUI timerSeconds;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar = GameObject.Find("HP").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        time = timeDuration;
        timerUIHolder = GameObject.Find("TimerArea");
        timerUI = GameObject.Find("Timer");
        timerMinutes = timerUI.transform.Find("Minutes").GetComponent<TextMeshProUGUI>();
        timerSeconds = timerUI.transform.Find("Seconds").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (startTimer)
        {
            time = time - Time.deltaTime *2;
            if (time > 60f)
            {
                minutes = (int)time / 60;
                timerMinutes.text = $"{minutes}";
            }
            else
            {
                timerMinutes.text = $"0";
            }

            int sec = (int)time % 60;
            if (sec >= 10)
            {
                timerSeconds.text = $"{sec}";
            } else
            {
                timerSeconds.text = $"0{sec}";
            }


        }


    }

    public void DamageTaken(float damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    public void OpenInteraction()
    {
        interactMessage.SetActive(true);
    }

    public void CloseInteraction()
    {
        interactMessage.SetActive(false);
    }

    public void StartCountdownTimer()
    {
        timerUIHolder.SetActive(true);
        startTimer = true;
    }

}
