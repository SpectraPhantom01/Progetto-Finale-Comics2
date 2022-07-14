using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumabile : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            gameObject.SetActive(false);
    }
}
