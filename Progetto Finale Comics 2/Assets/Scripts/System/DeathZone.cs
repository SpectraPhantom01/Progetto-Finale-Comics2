using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Death Zone Settings")]
    //[SerializeField] Checkpoint checkpoint;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //collision.transform.position = checkpoint.transform.position;
            gameManager.Respawn(player.transform);
        }
    }

}
