using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class RaycastLaserRifle : MonoBehaviour
{
    public int gunDamage = 1;
    public int ammo = 32;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public Camera fpsCam;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource reload;
    private AudioSource shootSound;
    private ParticleSystem laserFlash;
    private LineRenderer laserLine;
    private float nextFire;
    private bool allowedToFire = true;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        reload = GameObject.Find("ReloadSound").GetComponent<AudioSource>();

        shootSound = GameObject.Find("ShootSound").GetComponent<AudioSource>();

        laserFlash = GameObject.Find("Laser").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && allowedToFire == true)
        {
            nextFire = Time.time + fireRate;

            if (ammo != 0)
            {
                ammo -= 1;

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
                //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);

                    //EXPERIMENTAL!!!!!!!!!!!!!!!!!!!!!!!!
                    Hitbox hitbox = hit.collider.GetComponent<Hitbox>();

                    if (hitbox != null)
                    {
                        hitbox.OnRaycastHit(this, hit.normal);
                    }
                    //EXPERIMENTAL!!!!!!!!!!!!!!!!!!!!!!!!

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

        if (Input.GetKey(KeyCode.Mouse0) == false)
        {
            laserFlash.Stop();
        }
        if (Input.GetKey(KeyCode.Mouse0) && ammo == 0)
        {
            laserFlash.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) || ammo == 0)
        {
            laserFlash.Stop();
            StartCoroutine(ReloadEffect());
        }
    }


    private IEnumerator ShotEffect()
    {
        shootSound.Play();
        laserFlash.Play();

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
