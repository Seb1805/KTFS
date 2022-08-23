using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Attach the gameobject in the ui
    public GameObject InGameMnu; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (InGameMnu.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.visible = false;
        }


       if(Input.GetKeyUp(KeyCode.Escape))
        {
            InGameMnu.SetActive(!InGameMnu.activeInHierarchy);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
