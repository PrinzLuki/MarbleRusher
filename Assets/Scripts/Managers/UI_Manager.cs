using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public static UI_Manager Instance { get { return instance; } }

    public GameObject pauseObj;
    bool isPaused;
    bool isPlaying = true;
    public bool isTimerOn;
    [Header("WIN Window")]
    [SerializeField] Canvas winScreenCanvas;
    [SerializeField] GameObject frame;
    [SerializeField] GameObject rightFrame;
    [SerializeField] GameObject lowerFrame;
    [SerializeField] GameObject leftFrame;
    [SerializeField] GameObject backGround;
    [SerializeField] TMP_Text allDeathsTxt;
    [SerializeField] TMP_Text neededTimeTxt;
    [Header("Game UI")]
    [SerializeField] TMP_Text timerTmp;

    private void OnEnable()
    {
        GameManager.OnTimeChanged += TimerTextChange;
    }

    private void OnDisable()
    {
        GameManager.OnTimeChanged -= TimerTextChange;
    }


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

    public void ActivateGameUI(bool isActive)
    {
        timerTmp.gameObject.SetActive(isActive);
    }

    public void BackToMenu()
    {
        SceneManagement.Instance.LoadMenu();
        isPaused = false;
        pauseObj.SetActive(isPaused);
        ResetWinScreen();
        ActivateGameUI(false);
    }
    #endregion

    #region Win Window

    public void StartWinSequence()
    {
        winScreenCanvas.worldCamera = Camera.main;
        isPlaying = false;
        isPaused = false;
        pauseObj.SetActive(isPaused);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SetTimeInWinScreen();
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

    public void SetTimeInWinScreen()
    {
        neededTimeTxt.text = timerTmp.text;
    }

    public void LoadNextLevel()
    {
        SceneManagement.Instance.LoadNextLevelScene();
        isPlaying = true;
        isPaused = false;
        pauseObj.SetActive(isPaused);
        ResetWinScreen();
    }

    #endregion



    public void TimerTextChange(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);


        timerTmp.text = timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString() + ":" + timeSpan.Milliseconds.ToString();
    }

}
