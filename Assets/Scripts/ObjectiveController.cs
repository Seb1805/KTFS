using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    private List<GameObject> objectives;
    private List<bool> objectivesComplete = new List<bool>();

    bool redButton = false;
    bool defendShip = false;
    
    public GameObject ship;
    Timekeep timer;
    LevelChangerController levelChange;

    GameObject objectivesUI;
    


    private void Start()
    {
        objectives = new List<GameObject>(GameObject.FindGameObjectsWithTag("Objectives"));
        foreach (GameObject obj in objectives)
        {
            objectivesComplete.Add(false);
        }
        objectivesUI = GameObject.Find("ObjectiveBody");
        timer = GameObject.Find("TimeKeeper").GetComponent<Timekeep>();
        levelChange = GameObject.Find("LevelChanger").GetComponent<LevelChangerController>();
    }

    private void Update()
    {
        
    }

    

    public void PickUpObjectiveCheck(GameObject objective)
    {
        foreach (GameObject obj in objectives)
        {
            if (obj.name == objective.name)
            {
                objectivesComplete[objectives.IndexOf(obj)] = true;
                int numberOfCollected = objectivesComplete.Where(c => c).Count();
                if (numberOfCollected == objectivesComplete.Count())
                {
                    redButton = true;
                    GameObject.Find("ObjectiveRedButton").SetActive(true);
                }
                return;
            }
        }
    }

    public void RedButtonPressed()
    {
        GameObject.Find("ObjectiveRedButton").SetActive(false);
        GameObject.Find("ObjectiveProtectShip").SetActive(true);
        defendShip = true;
        ship.GetComponent<BoxCollider>().enabled = !ship.GetComponent<BoxCollider>().enabled;
    }

    public void ProtectShip()
    {
        timer.Pause();
        levelChange.PlayerWon("TestEndScene", timer.getTime());
    }

    void UpdateQuestLog()
    {
        
    }


}
