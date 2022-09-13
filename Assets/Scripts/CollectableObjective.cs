using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjective : Interactable
{
    ObjectiveController controller;
    public override void Interact()
    {
        Debug.LogError($"Objective : {controller.objective}");

        controller.objective = true;
        Debug.LogError($"Objective : {controller.objective}");
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<ObjectiveController>();
    }

}
