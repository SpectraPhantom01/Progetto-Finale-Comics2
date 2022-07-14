using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosizione : MonoBehaviour
{
    [SerializeField]
    bool posizione = true;
    [SerializeField]
    bool rotazione = true;
    [SerializeField]
    bool velocit� = true;

    Vector3 posizioneIniziale;
    Quaternion rotazioneIniziale;
    // Start is called before the first frame update
    void Start()
    {
        posizioneIniziale = this.gameObject.transform.position;
        rotazioneIniziale = this.gameObject.transform.rotation;
        GameManager.instance.onRespawn += Reset;
    }

    private void Reset()
    {
        if (posizione)
            this.gameObject.transform.position = posizioneIniziale;

        if (rotazione)
            this.gameObject.transform.rotation = rotazioneIniziale;

        if (velocit�)
        {
            if (this.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = default;
            }
        }
        
    }
}
