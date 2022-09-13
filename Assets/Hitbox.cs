using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public AiHealth health;

    public void OnRaycastHit(RaycastLaserRifle weapon)
    {
        health.TakeDamage(weapon.gunDamage);
    }

    //public void OnRaycastHit(Raycastweapon weapon)
    //{

    //}
}
