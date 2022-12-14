using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiWeapons : MonoBehaviour
{
    RaycastWeapon currentWeapon;
    Animator animator;
    MeshSockets sockets;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sockets = GetComponent<MeshSockets>();
    }
    public void Equip(RaycastWeapon weapon)
    {
        currentWeapon = weapon;
        sockets.Attach(weapon.transform, MeshSockets.SocketId.Spine);
        currentWeapon.transform.SetParent(transform,false);
    }

    public void ActivateWeapon()
    {
        animator.SetBool("Equip", true);
    }

    public bool HasWeapon()
    {
        return currentWeapon != null;
    }
}
