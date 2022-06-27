using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcha : MonoBehaviour
{
    [SerializeField]
    private GameObject stretch;
    [SerializeField]
    private bool rimpicciolisci = true;
    [SerializeField]
    private float scale = 2;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (rimpicciolisci)
                stretch.transform.localScale = new Vector3(1, stretch.transform.localScale.y*scale, 1);
            else
                stretch.transform.localScale = new Vector3(1, stretch.transform.localScale.y /scale, 1);
            //Destroy(gameObject);
        }
    }
}
