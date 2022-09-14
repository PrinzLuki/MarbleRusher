using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cam;
    [SerializeField]float xValue;
    [SerializeField]float yValue;

    public void ResetCameraPosition()
    {
        cam.m_XAxis.Value = xValue;
        cam.m_YAxis.Value = yValue;
    }
}
