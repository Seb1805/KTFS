using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    /// <summary>
    /// Events that will be excuted when the Player interacts with the object
    /// </summary>
    public abstract void Interact();

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<PlayerUIController>().OpenInteraction();
        }
    }

    private void OnTriggerExit(Collider collision)

    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<PlayerUIController>().CloseInteraction();
        }
    }
}
