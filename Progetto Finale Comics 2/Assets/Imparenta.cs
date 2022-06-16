using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imparenta : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.transform.parent = null;
            player = null;
        }
    }
}
