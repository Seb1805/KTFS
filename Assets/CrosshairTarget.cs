using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MonoBehaviour
{
    Camera mainCam;
    Ray ray;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCam.transform.position;
        ray.direction = mainCam.transform.forward;
        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
        else
        {
            transform.position = ray.origin + ray.direction * 1000.0f;
        }
    }
}
