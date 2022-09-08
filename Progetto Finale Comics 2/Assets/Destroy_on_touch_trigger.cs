using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_on_touch_trigger : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
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
    private void Start()
    {
        GameManager.instance.onRespawn += Reactive;
    }

    private void Reactive()
    {
        gameObject.SetActive(true);
    }
}
