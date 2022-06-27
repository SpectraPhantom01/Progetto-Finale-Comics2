using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.SetExplosion();
        }
    }
}

