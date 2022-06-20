using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        ExplosionBehaviour playerBehaviour = collision.gameObject.GetComponent<ExplosionBehaviour>();
        if (playerBehaviour != null)
        {
            playerBehaviour.Explosion();
        }
    }
}

