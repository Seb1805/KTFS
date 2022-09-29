using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Interactable
{
    PlayerUIController playerUI;
    ObjectiveController controller;
    public override void Interact(GameObject player)
    {
        controller.RedButtonPressed();
        playerUI.StartCountdownTimer();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUIController>();
        controller = GameObject.Find("MissionController").GetComponent<ObjectiveController>();
    }

}
