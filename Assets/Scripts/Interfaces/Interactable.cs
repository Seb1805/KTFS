using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    private bool InAreaOf = false;
    private void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    /// <summary>
    /// Events that will be executed when the Player interacts with the object
    /// </summary>
    public abstract void Interact(GameObject player);

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            InAreaOf = true;
            collision.GetComponentInParent<PlayerUIController>().OpenInteraction();
        }
    }

    private void OnTriggerExit(Collider collision)

    {
        if (collision.CompareTag("Player"))
        {
            InAreaOf = false;
            collision.GetComponentInParent<PlayerUIController>().CloseInteraction();
        }
    }

    public void PickedUp(GameObject player)
    {
        player.GetComponentInParent<PlayerUIController>().CloseInteraction();
        Destroy(gameObject);
    }
}
