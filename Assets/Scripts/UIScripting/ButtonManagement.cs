using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonManagement : MonoBehaviour
{
    public LayerMask buttonLayer;
    public UnityEvent buttonEvents = new();
    public UnityEvent buttonHoverEvents = new();

    private void Update()
    {
        MouseClickInput();
    }

    public void MouseHoverInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 999, buttonLayer))
        {
            if (hit.collider.GetComponent<ButtonManagement>() == null) return;

            hit.collider.GetComponent<ButtonManagement>().buttonHoverEvents?.Invoke();
        }
    }


    void MouseClickInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 999, buttonLayer))
            {
                if (hit.collider.GetComponent<ButtonManagement>() == null) return;

                hit.collider.GetComponent<ButtonManagement>().buttonEvents?.Invoke();
            }
        }
    }


}
