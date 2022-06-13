using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (playerBehaviour != null)
        {
            playerBehaviour.ExplosionEvent();
        }
    }
}

