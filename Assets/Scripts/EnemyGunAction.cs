using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunAction : MonoBehaviour
{
    public int gunDamage = 1;
    public int ammo = 32;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
  

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource reload;
    private AudioSource shoot;
    private ParticleSystem muzzleFlash;
    private LineRenderer laserLine;
    private float nextFire;
    private bool allowedToFire = true;
    [SerializeField] private GameObject bulletHole;

    private Transform target;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        reload = GameObject.Find("ReloadSound").GetComponent<AudioSource>();

        shoot = GameObject.Find("ShootSound").GetComponent<AudioSource>();

        muzzleFlash = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (target != null && Time.time > nextFire && allowedToFire == true)
        {
            nextFire = Time.time + fireRate;

            if (ammo != 0)
            {
                ammo -= 1;

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = gunEnd.position;

                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(1, hit.point);
                    Health health = hit.collider.GetComponent<Health>();
                    GameObject.Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));

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
                    laserLine.SetPosition(1, rayOrigin + (gunEnd.transform.forward * weaponRange));
                }
            }
        }

        //if (Input.GetKey(KeyCode.Mouse0) == false)
        //{
        //    muzzleFlash.Stop();
        //}
        //if (Input.GetKey(KeyCode.Mouse0) && ammo == 0)
        //{
        //    muzzleFlash.Stop();
        //}

        if ( ammo == 0)
        {
            //muzzleFlash.Stop();
            StartCoroutine(ReloadEffect());
        }
    }


    private IEnumerator ShotEffect()
    {
        shoot.Play();
        //muzzleFlash.Play();

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
