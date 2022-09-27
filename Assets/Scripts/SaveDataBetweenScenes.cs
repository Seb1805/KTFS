using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataBetweenScenes : MonoBehaviour
{
    public GameObject door;

    //save the object between the scenes
    public static SaveDataBetweenScenes instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
