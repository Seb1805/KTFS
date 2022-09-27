using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    public Animator animator;

    string sceneToLoad = "";
    [HideInInspector] public string reason = "";
    [HideInInspector] public float score;

    public static LevelChangerController instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayerWon(string sceneName, float timeUsed)
    {
        score = timeUsed;
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void PlayerLose(string sceneName, string cause)
    {
        reason = cause;
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
