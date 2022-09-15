using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    private List<GameObject> objectives;


    private void Start()
    {
        objectives = new List<GameObject>(GameObject.FindGameObjectsWithTag("Objectives"));
    }


    public void ObjectiveCheck(GameObject objective)
    {
        foreach (GameObject obj in objectives)
        {
            if (obj.name == objective.name)
            {
                objectives.Remove(obj);
                return;
            }
        }
    }

}
