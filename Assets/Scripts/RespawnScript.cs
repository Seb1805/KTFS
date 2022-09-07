using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //if (collision.CompareTag("Player"))
        //{
        //    //Restart if you get out of bounds

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Restart if you get out of bounds

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //DOESNT WORK??

            Vector3 vector3 = spawnPoint.transform.position;

            playerPos.transform.position = vector3;
            Physics.SyncTransforms();
        }
    }
}
