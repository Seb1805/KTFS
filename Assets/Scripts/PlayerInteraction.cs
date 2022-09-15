using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool triggerInteraction = false;
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.transform.GetComponent<Interactable>())
            {
                other.gameObject.transform.GetComponent<Interactable>().Interact(gameObject);
                return;
            }
        }
    }
}
