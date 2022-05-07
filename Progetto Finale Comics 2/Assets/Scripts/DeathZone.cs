using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Death Zone Settings")]
    [SerializeField] Checkpoint checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bruh");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.position = checkpoint.transform.position;
        }
    }

}
