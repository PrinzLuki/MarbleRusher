using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    MainMenu, FirstTrail, SecondTrail,
}

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    public static SceneManagement Instance { get { return instance; } }

    [SerializeField] List<SceneData> sceneList;
    SceneData currentScene;

    [Header("Fading Settings")]
    public GameObject fader;
    public float fadeTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadSceneDelay(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneDelay(GameManager.Instance.playerLevel));
    }
     public void LoadNextLevelScene()
    {
        StartCoroutine(LoadSceneDelay(++GameManager.Instance.playerLevel));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadSceneDelay(0));
    }

    IEnumerator LoadSceneDelay(int scene)
    {
        fader.GetComponent<Animator>().SetBool("fadeOut", true);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);
        fader.GetComponent<Animator>().SetBool("fadeOut", false);
        yield return new WaitForSeconds(fadeTime);
    }
}

[System.Serializable]
public class SceneData
{
    public string sceneName;
}
