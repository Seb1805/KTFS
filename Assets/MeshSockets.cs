using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketId
    {
        Spine
    }

    Dictionary<SocketId,MeshSocket> socketMap = new Dictionary<SocketId, MeshSocket>();

    // Start is called before the first frame update
    void Start()
    {
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
        foreach (var s in sockets)
        {
            socketMap[s.socketId] = s;
        }
    }

    public void Attach(Transform objTransform,SocketId socketId)
    {
        socketMap[socketId].Attach(objTransform);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
