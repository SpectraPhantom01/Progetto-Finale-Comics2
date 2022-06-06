using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.Explosion();
        }
    }
}
