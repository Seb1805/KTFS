using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAssault57 : MonoBehaviour
{
    public int gunDamage = 1;
    public int ammo = 32;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource reload;
    private AudioSource shoot;
    private ParticleSystem muzzleFlash;
    private LineRenderer laserLine;
    private float nextFire;
    private bool allowedToFire = true;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        reload = GameObject.Find("ReloadSound").GetComponent<AudioSource>();

        shoot = GameObject.Find("ShootSound").GetComponent<AudioSource>();

        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();

        fpsCam = GetComponentInParent<Camera>();

    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && allowedToFire == true)
        {
            nextFire = Time.time + fireRate;

            if (ammo != 0)
            {
                ammo -= 1;

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);
                    Enemy health = hit.collider.GetComponent<Enemy>();

                    if (health != null)
                    {
                        health.Damage(gunDamage);
                    }

                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
                else
                {
                    laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                }
            }
        }

        muzzleFlash.Stop();

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadEffect());
        }
    }

    private IEnumerator ShotEffect()
    {
        shoot.Play();

        muzzleFlash.Play();

        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }

    private IEnumerator ReloadEffect()
    {
        reload.Play();

        allowedToFire = false;

        yield return new WaitForSeconds(2.5f);

        ammo = 32;

        allowedToFire = true;
    }
}
