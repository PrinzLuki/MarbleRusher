using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject exitButton;
    public LayerMask menuLayer;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        MouseClickInput(ray);
    }


    void StartGame()
    {
        Debug.Log("StartGame");
        SceneManagement.Instance.LoadScene();
    }

    void OpenSettings()
    {
        Debug.Log("OpenSettings");
    }

    void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    void MouseClickInput(Ray ray)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 999, menuLayer))
            {
                ButtonCheck(hit.collider.gameObject);
            }
        }
    }

    public void ButtonCheck(GameObject obj)
    {
        if (obj == playButton)
        {
            StartGame();
        }
        else if(obj == settingsButton)
        {
            OpenSettings();
        }
        else if(obj == exitButton)
        {
            ExitGame();
        }
    }



}
