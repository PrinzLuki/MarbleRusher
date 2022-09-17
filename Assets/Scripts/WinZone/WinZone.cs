using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            StartCoroutine(WinSequence(collision.gameObject));
        }
    }

    IEnumerator WinSequence(GameObject player)
    {
        GameManager.Instance.StopTimer();
        yield return new WaitForSeconds(0.15f);
        player.GetComponent<MarbleMovement>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.3f);
        UI_Manager.Instance.StartWinSequence();
    }
}
