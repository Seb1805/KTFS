using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    float health, maxHealth = 100;
    private Animator _animator;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "HP: " + health + "%";
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            _animator.SetTrigger("Dead");
        }
    }


    private void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthText.color = healthColor;
    }
}
