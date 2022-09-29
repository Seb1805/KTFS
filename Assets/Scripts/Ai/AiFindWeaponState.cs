using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFindWeaponState : AiState
{
    public void Enter(AiAgent agent)
    {
        WeaponPickup pickup = FindClosestWeapon(agent);
        agent.navMeshAgent.destination = pickup.transform.position;
        //Find weapon faster
        agent.navMeshAgent.speed = 5;
    }

    public void Exit(AiAgent agent)
    {

    }

    public AiStateId GetId()
    {
        return AiStateId.FindWeapon;
    }

    public void Update(AiAgent agent)
    {
        if (agent.weapons.HasWeapon())
        {
            agent.weapons.ActivateWeapon();
        }
    }


    private WeaponPickup FindClosestWeapon(AiAgent agent)
    {
        WeaponPickup[] weapons = Object.FindObjectsOfType<WeaponPickup>();
        WeaponPickup closestWeapon = null;
        float cloestDistance = float.MaxValue;
        foreach (var weapon in weapons)
        {
            float distanceToWeapon = Vector3.Distance(agent.transform.position, weapon.transform.position);
            if (distanceToWeapon < cloestDistance)
            {
                cloestDistance = distanceToWeapon;
                closestWeapon = weapon;
            }
        }
        return closestWeapon;
    }
}
