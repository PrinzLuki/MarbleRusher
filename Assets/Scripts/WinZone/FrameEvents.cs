using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameEvents : MonoBehaviour
{
    public GameObject nextFrame;

    public void StartNextFrameAnim()
    {
        if (nextFrame == null) return;
        nextFrame.SetActive(true);

        if (nextFrame.GetComponent<Animator>() == null) return;
        nextFrame.GetComponent<Animator>().SetTrigger("Lazer");
    }
}
