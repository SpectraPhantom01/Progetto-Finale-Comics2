using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (playerBehaviour != null)
        {
            playerBehaviour.ExplosionEvent();
        }
    }
}
