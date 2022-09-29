using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crosshairTarget;
    public Transform weaponParent;
    public Transform rightGrip;
    public Transform leftGrip;
    RaycastWeapon weapon;
    Animator animator;
    AnimatorOverrideController overrides;

    public UnityEngine.Animations.Rigging.Rig handIK;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        overrides = animator.runtimeAnimatorController as AnimatorOverrideController;
        RaycastWeapon currentWeapon = GetComponentInChildren<RaycastWeapon>();
        if(currentWeapon)
        {
            Equip(currentWeapon);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (weapon)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.StartFiring();
            }
            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            weapon.UpdateBullets(Time.deltaTime);
            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }
        }
        else
        {
            handIK.weight = 0.0f;
            animator.SetLayerWeight(1, 0.0f);
        }
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        if (weapon)
        {
            //Destroy the gameObject
            Destroy(weapon.gameObject);
        }

        weapon = newWeapon;
        //Remember to set raycast destination after picking up a weapon
        weapon.raycastDestination = crosshairTarget;
        //Attach to parent
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        
        //Hand posture
        handIK.weight = 1.0f;
        animator.SetLayerWeight(1, 1.0f);

        Invoke(nameof(SetAnimationDelayed), 0.001f);
    }

    void SetAnimationDelayed()
    {
        overrides["weapon_anim_empty"] = weapon.weaponAnimation;
    }

    [ContextMenu("Save weapon pose")]
    void SaveWeaponPose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(leftGrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(rightGrip.gameObject, false);
        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(weapon.weaponAnimation);
    }
}
