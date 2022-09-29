using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjective : Interactable
{
    private AudioSource pickupSound;


    ObjectiveController controller;
    public override void Interact(GameObject player)
    {
        controller = GameObject.Find("MissionController").GetComponent<ObjectiveController>();
        controller.PickUpObjectiveCheck(gameObject);
        PickedUp(player);
        pickupSound.Play();
    }

    // Start is called before the first frame update
    private void Start()
    {
        pickupSound = GameObject.Find("PickupSound").GetComponent<AudioSource>();
    }

}