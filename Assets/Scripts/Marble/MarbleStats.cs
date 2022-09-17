using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarbleStats : MonoBehaviour, IDamageable
{
    public float Health;

    private void Start()
    {
        GameManager.Instance.LoadPlayerMaterial(this.transform);
        GameManager.Instance.StopTimer();
        GameManager.Instance.ResetTimer();
        GameManager.Instance.StartTimer();
    }

    public void TakeDmg(int dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
            SceneManagement.Instance.ReloadScene();
        }
    }
}
