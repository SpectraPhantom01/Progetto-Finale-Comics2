using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finelivello : MonoBehaviour
{
    public GameObject error;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            error.SetActive(true);
        }
            
    }
}
