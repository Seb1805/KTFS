using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    public Animator animator;

    string sceneToLoad = "";
    [HideInInspector] public string reason = "";

    public static LevelChangerController instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayerWon()
    {
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
