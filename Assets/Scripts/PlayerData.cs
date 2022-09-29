using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    //public ObjectId id;
    public int Score;
    public string Name;
    public DateTime DateCreated;
    public DateTime DateUpdated;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
