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
    bool startTimer = false;
    float timeDuration = 2f * 60f;
    float time;
    int clockSpeed = 1;
    int minutes = 0;

    // UI elements
    public GameObject interactMessage;
    public GameObject timerUIHolder;
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
        
    }

    void Update()
    {
        Countdown();
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
        timerMinutes = GameObject.Find("Minutes").GetComponent<TextMeshProUGUI>();
        timerSeconds = GameObject.Find("Seconds").GetComponent<TextMeshProUGUI>();
        startTimer = true;
    }

    void Countdown()
    {
        if (startTimer)
        {
            time = time - Time.deltaTime * clockSpeed;
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
            }
            else
            {
                timerSeconds.text = $"0{sec}";
            }
        }

        if (time < 0) startTimer = false;
    }
}
