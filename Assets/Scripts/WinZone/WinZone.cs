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
        GetComponent<Animator>().SetTrigger("win");
        yield return new WaitForSeconds(0.15f);
        player.GetComponent<MarbleMovement>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        UI_Manager.Instance.StartWinSequence();
        player.GetComponent<Rigidbody>().isKinematic = true;
    }
}
