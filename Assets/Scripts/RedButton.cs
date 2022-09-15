using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Interactable
{
    PlayerUIController playerUI;
    public override void Interact(GameObject player)
    {
        playerUI.StartCountdownTimer();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerUI = GameObject.Find("Player").GetComponent<PlayerUIController>();
    }

}
