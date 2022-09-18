using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    [Range(0, 100), SerializeField] float musicVolume = 50;
    [Range(0, 100), SerializeField] float soundVolume = 50;

    [SerializeField] TMP_Text mouseSensivityTxt;

    [SerializeField] Material standardMat;
    [SerializeField] Material hoveredMat;

    #region ButtonManagement MainMenu / Settings
    public void StartGame()
    {
        SceneManagement.Instance.LoadScene();
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void OpenSettings()
    {
        mouseSensivityTxt.text = ((int)GameManager.Instance.mouseSensivity).ToString();
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
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
        if (GameManager.Instance.mouseSensivity == 400) return;

        GameManager.Instance.mouseSensivity += 1;
        value.text = GameManager.Instance.mouseSensivity.ToString();
        GameManager.Instance.SetMouseSensivity(GameManager.Instance.mouseSensivity);
    }

    public void DecreaseMouseSensivity(TMP_Text value)
    {
        if (GameManager.Instance.mouseSensivity == 0) return;

        GameManager.Instance.mouseSensivity -= 1;
        value.text = GameManager.Instance.mouseSensivity.ToString();
        GameManager.Instance.SetMouseSensivity(GameManager.Instance.mouseSensivity);
    }

    #endregion
}
