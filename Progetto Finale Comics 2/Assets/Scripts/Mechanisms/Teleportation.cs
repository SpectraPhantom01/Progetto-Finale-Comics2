using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] Animator animator;
    GameObject player;
    [SerializeField] Transform teleportPoint;

    // Start is called before the first frame update
    private void Start()
    {
        teleportPoint = this.gameObject.transform.parent.transform.GetChild(1); //risale al padre per poi prendere il transform del secondo figlio
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetBool("Charging", true);
            player = collision.gameObject;
            TeleportSoundStart();
        }    
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetBool("Charging", false);
            player = null;
            TeleportSoundStop();
        }
    }

    void Teleport()
    {
        player.transform.position = teleportPoint.position;
    }

    void TeleportSoundStart()
    {
        AudioManager.instance.Play("Teletrasporto");
    }
    private void TeleportSoundStop()
    {
        AudioManager.instance.Stop("Teletrasporto");
    }
}
