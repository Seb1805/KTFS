using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healtText;

    int health, maxHealth = 100;

    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        if(healtText!= null)
        {
            healtText.text = "HP: " + health + "%";
        }

    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healtText.color = healthColor;
    }
}
