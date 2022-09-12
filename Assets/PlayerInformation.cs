using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    private float health = 100;
    private RawImage healthUI;
    // Start is called before the first frame update
    void Start()
    {
        healthUI = GameObject.Find("HPCurrent").GetComponent<RawImage>();
    }

    void DamageTaken(float damage)
    {
        health -= damage;
        var procsd = 250 - ((health / 100) * 250);
        healthUI.transform.transform.right = new Vector3(procsd);
    }
}
