using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
    private Transform mLookAt;
    private Transform localTrans;

    // Start is called before the first frame update
    void Start()
    {
        localTrans = GetComponent<Transform>();
        mLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mLookAt)
        {
            localTrans.LookAt(2 * localTrans.position - mLookAt.position);
        }
    }
}
