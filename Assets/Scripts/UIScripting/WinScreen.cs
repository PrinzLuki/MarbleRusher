using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    Camera cam;

    public GameObject replayButton;
    public GameObject nextLevelButton;
    public GameObject mainMenuButton;

    public LayerMask buttonLayer;
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (GetComponent<Canvas>().worldCamera == null)
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
            cam = Camera.main;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        ButtonManagement(ray);
    }

    void ButtonManagement(Ray ray)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 999, buttonLayer))
            {
                ButtonCheck(hit.collider.gameObject);
            }
        }
    }

    void ButtonCheck(GameObject obj)
    {
        if (obj == replayButton)
        {
            UI_Manager.Instance.Restart();
        }
        else if (obj == nextLevelButton)
        {
            SceneManagement.Instance.LoadScene();
        }
        else if (obj == mainMenuButton)
        {
            UI_Manager.Instance.BackToMenu();
        }
    }

}
