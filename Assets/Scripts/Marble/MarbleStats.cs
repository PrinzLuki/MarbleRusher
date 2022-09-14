using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarbleStats : MonoBehaviour, IDamageable
{
    public float Health;

    public void TakeDmg(int dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
            SceneManagement.Instance.ReloadScene();
        }
    }
}
