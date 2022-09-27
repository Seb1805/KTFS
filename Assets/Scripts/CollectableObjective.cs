using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjective : Interactable
{
    ObjectiveController controller;
    public override void Interact(GameObject player)
    {
        controller = GameObject.Find("MissionController").GetComponent<ObjectiveController>();
        controller.PickUpObjectiveCheck(gameObject);
        PickedUp(player);
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

}
