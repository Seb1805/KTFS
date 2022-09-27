using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPanel : Interactable
{
    public GameObject Door;
    public override void Interact(GameObject player)
    {
        //CharacterController cc = player.Find<GameObject>("PlayerAmature").GetComponent<ThirdPersonController>();
        //cc.enabled = false;
        //player.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SaveDataBetweenScenes savedata = GameObject.Find("DataBetweenScenes").GetComponent<SaveDataBetweenScenes>();
        savedata.door = Door;
        SceneManager.LoadScene("HackTwoCB", LoadSceneMode.Additive);
    }
}
