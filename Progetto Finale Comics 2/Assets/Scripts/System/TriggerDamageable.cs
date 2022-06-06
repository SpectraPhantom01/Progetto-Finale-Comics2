using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.Explosion();
        }
    }
}
