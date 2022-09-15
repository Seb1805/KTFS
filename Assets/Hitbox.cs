using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public AiHealth health;

    public void OnRaycastHit(RaycastLaserRifle weapon,Vector3 direction)
    {
        health.TakeDamage(weapon.gunDamage, direction);
    }

    //public void OnRaycastHit(Raycastweapon weapon)
    //{

    //}
}
