using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private float maxHealth = 100;
    private float health;
    private Slider healthBar;


    
    public GameObject interactMessage;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar = GameObject.Find("HP").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

    }

    void DamageTaken(float damage)
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
}
