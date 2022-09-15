using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPanel : Interactable
{
    public override void Interact(GameObject player)
    {
        //CharacterController cc = player.Find<GameObject>("PlayerAmature").GetComponent<ThirdPersonController>();
        //cc.enabled = false;
        //player.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("HackTwoCB", LoadSceneMode.Additive);
    }
}
