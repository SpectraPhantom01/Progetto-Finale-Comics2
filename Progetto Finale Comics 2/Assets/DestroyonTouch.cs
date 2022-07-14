using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyonTouch : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.onRespawn += Reactive;
    }

    private void Reactive()
    {
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            if (gameObject.GetComponentInChildren<PlayerController>() != null)
            {
                gameObject.GetComponentInChildren<PlayerController>().gameObject.transform.parent = null;
            }
            gameObject.SetActive(false);
        }

    }
}
