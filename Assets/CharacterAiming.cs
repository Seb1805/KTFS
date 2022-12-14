using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public float aimDuration = 0.3f;
    Camera mainCamera;


    public Rig aimLayer;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed + Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (aimLayer)
        {
            aimLayer.weight = 1.0f;
        }

        //if (Input.GetMouseButton(1))
        //{
        //    aimLayer.weight += Time.deltaTime / aimDuration;
        //}
        //else
        //{
        //    aimLayer.weight -= Time.deltaTime / aimDuration;
        //    weapon.StopFiring();
        //}

        //Only make muzzle flash and shoot when we are AIMING!
        if(aimLayer.weight == 1)
        {
            //Handle cooldown

        }

    }
}
