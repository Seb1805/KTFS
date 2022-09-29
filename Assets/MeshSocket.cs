using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public MeshSockets.SocketId socketId;
    Transform attachPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attach(Transform objTransform)
    {
        objTransform.SetParent(attachPoint,false);
    }
}
