using System;
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

    // UI elements
    public GameObject interactMessage;
    public GameObject timerUIHolder;
    public GameObject overallTimer;

    LevelChangerController levelChange;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar = GameObject.Find("HP").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        time = timeDuration;

        interactMessage.SetActive(false);
        timerUIHolder.SetActive(false);

        levelChange = GameObject.Find("LevelChanger").GetComponent<LevelChangerController>();

    }

    void Update()
    {
        Countdown();
        if (Input.GetKeyDown(KeyCode.K))
        {
            DamageTaken(20);
        }
    }

    public void DamageTaken(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if(health <= 0)
        {
            levelChange.PlayerLose("TestEndScene", "You're trash, git gut");
        }
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
        overallTimer = GameObject.Find("OverallTimer");
        startTimer = true;
    }

    void Countdown()
    {
        if (startTimer)
        {
            time = time - Time.deltaTime * clockSpeed;

            overallTimer.GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(time).ToString("m\\:ss");
        }

        if (time < 0) startTimer = false;
    }
}
