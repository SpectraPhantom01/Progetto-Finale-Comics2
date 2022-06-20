using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ExplosionBehaviour playerBehaviour = collision.gameObject.GetComponent<ExplosionBehaviour>();
        if (playerBehaviour != null)
        {
            playerBehaviour.Explosion();
        }
    }
}
