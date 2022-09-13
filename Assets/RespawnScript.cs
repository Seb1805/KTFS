using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject deathScreen;


    GameObject[] objs = { null, null, null };
    int[] objs2 = { 1, 2, 3 };
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> list = new List<GameObject>(objs);
        ////List<GameObject> list1 = objs.ToList();
        ////List<int> list = objs2.ToList();
        //foreach (GameObject obj in objs)
        //{
        //    list.Add(obj);
        //}
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
