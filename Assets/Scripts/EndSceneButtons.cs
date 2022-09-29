using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EndSceneButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public string changeToScene;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SceneChange);
    }

    void SceneChange()
    {
        Destroy(GameObject.Find("LevelChanger"));
        Destroy(GameObject.Find("DataBetweenScenes"));
        SceneManager.LoadScene(changeToScene);
    }
}
