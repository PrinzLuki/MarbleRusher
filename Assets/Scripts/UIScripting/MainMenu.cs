using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    [Range(0, 100), SerializeField] float musicVolume = 50;
    [Range(0, 100), SerializeField] float soundVolume = 50;
    [Range(0, 100), SerializeField] float mouseSensitivity = 50;


    #region ButtonManagement MainMenu / Settings
    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManagement.Instance.LoadScene();
        UI_Manager.Instance.ActivateGameUI(true);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void OpenSettings()
    {
        Debug.Log("OpenSettings");
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    public void ChangeButtonColor()
    {

    }

    public void IncreaseMusicVolume(TMP_Text value)
    {
        if (musicVolume == 100) return;

        musicVolume += 1;
        value.text = musicVolume.ToString();
    }
    public void DecreaseMusicVolume(TMP_Text value)
    {
        if (musicVolume == 0) return;

        musicVolume -= 1;
        value.text = musicVolume.ToString();
    }
    public void IncreaseSoundVolume(TMP_Text value)
    {
        if (soundVolume == 100) return;

        soundVolume += 1;
        value.text = soundVolume.ToString();
    }
    public void DecreaseSoundVolume(TMP_Text value)
    {
        if (soundVolume == 0) return;

        soundVolume -= 1;
        value.text = soundVolume.ToString();
    }
    public void IncreaseMouseSensivity(TMP_Text value)
    {
        if (mouseSensitivity == 100) return;

        mouseSensitivity += 1;
        value.text = mouseSensitivity.ToString();
    }
    public void DecreaseMouseSensivity(TMP_Text value)
    {
        if (mouseSensitivity == 0) return;

        mouseSensitivity -= 1;
        value.text = mouseSensitivity.ToString();
    }

    #endregion
}
