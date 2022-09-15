using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Speed;
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, transform.rotation.y + Speed, 0);
    }
}
