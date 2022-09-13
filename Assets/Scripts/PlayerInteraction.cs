using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool triggerInteraction = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Debug.LogError("shiit");

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.LogError("Heyo");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.LogError("E Pressed");
            if (collision.gameObject.transform.GetComponent<Interactable>())
            {
                Debug.LogError("Object responding?");
                collision.gameObject.transform.GetComponent<Interactable>().Interact();
                return;
            }
        }
    }

}
