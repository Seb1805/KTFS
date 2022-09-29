using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    public Animator animator;

    string sceneToLoad = "";
    [HideInInspector] public string reason = "";
    [HideInInspector] public float score = 0;
    [HideInInspector] public bool completed;

    public static LevelChangerController instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayerWon(string sceneName, bool win, float timeUsed)
    {
        completed = win;
        score = timeUsed;
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void PlayerLose(string sceneName, bool win, string cause)
    {
        completed = win;
        reason = cause;
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
