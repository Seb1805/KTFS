using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healtText;

    float health, maxHealt = 100;

    private void Start()
    {
        health = maxHealt;
    }

    private void Update()
    {
        healtText.text = "HP: " + health + "%";
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
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealt));
        healtText.color = healthColor;
    }
}
