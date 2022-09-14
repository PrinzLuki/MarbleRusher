using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDmg(1000);
        }
    }
}
