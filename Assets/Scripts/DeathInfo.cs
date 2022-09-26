using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathInfo : MonoBehaviour
{
    TextMeshProUGUI reasonOfDeath;
    // Start is called before the first frame update
    void Start()
    {
        reasonOfDeath = gameObject.transform.Find("DeathText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        reasonOfDeath.text = LevelChangerController.instance.reason;
        //reasonOfDeath.text = "this is a test template text";

    }
}
