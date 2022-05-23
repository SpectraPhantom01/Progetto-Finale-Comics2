using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Traslator traslator;

    void Start()
    {
        traslator = GetComponent<Traslator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!(collision.gameObject.layer == LayerMask.NameToLayer("Player")))
            return;
        //Movimento

        //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity += traslator.rb.velocity;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }

}
