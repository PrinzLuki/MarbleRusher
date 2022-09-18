using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarbleStats : MonoBehaviour, IDamageable
{
    public float Health;

    private void Start()
    {
        UI_Manager.Instance.ActivateGameUI(true);
        GameManager.Instance.LoadPlayerMaterial(this.transform);
        UI_Manager.Instance.isTimerOn = false;
        GameManager.Instance.StopTimer();
        GameManager.Instance.ResetTimer();
        GameManager.Instance.SetMouseSensivityInCam();
    }

    private void Update()
    {
        if (GetComponent<Rigidbody>().angularVelocity != Vector3.zero && !UI_Manager.Instance.isTimerOn)
        {
            UI_Manager.Instance.isTimerOn = true;
            GameManager.Instance.StartTimer();
        }

    }


    public void TakeDmg(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            SceneManagement.Instance.ReloadScene();
        }
    }
}
