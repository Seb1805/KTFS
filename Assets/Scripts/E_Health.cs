using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Health : MonoBehaviour
{
    public int e_health;

    public void Damage(int damageAmount)
    {
        e_health -= damageAmount;

        if (e_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
