using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Timekeep : MonoBehaviour
{
    float time = 0;
    float clockSpeed = 1;
    bool goes = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goes)
        {
            clock();
        }
    }

    void clock()
    {
        time = time + Time.deltaTime * clockSpeed;
    }

    public void Pause()
    {
        goes = false;
    }
    public float getTime()
    {
        return time;
    }
}
