using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public static UI_Manager Instance { get { return instance; } }

    public GameObject pauseObj;
    bool isPaused;
    bool isPlaying = true;

    [Header("WIN Window")]
    [SerializeField] GameObject frame;
    [SerializeField] GameObject rightFrame;
    [SerializeField] GameObject lowerFrame;
    [SerializeField] GameObject leftFrame;
    [SerializeField] GameObject backGround;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PauseGame();
    }


    #region Pause
    void PauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isPlaying)
        {
            isPaused = !isPaused;
            Debug.Log(isPaused);
            pauseObj.SetActive(isPaused);

            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isPaused;
        }
    }

    public void Restart()
    {
        SceneManagement.Instance.ReloadScene();
        isPlaying = true;
        isPaused = false;
        pauseObj.SetActive(isPaused);
        ResetWinScreen();
    }

    public void BackToMenu()
    {
        SceneManagement.Instance.LoadMenu();
        isPaused = false;
        pauseObj.SetActive(isPaused);
        ResetWinScreen();
    }
    #endregion

    #region Win Window

    public void StartWinSequence()
    {
        isPlaying = false;
        isPaused = false;
        pauseObj.SetActive(isPaused);
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
        frame.SetActive(true);
    }

    void ResetWinScreen()
    {
        frame.SetActive(false);
        rightFrame.SetActive(false);
        lowerFrame.SetActive(false);
        leftFrame.SetActive(false);
        backGround.SetActive(false);
    }

    #endregion

}
