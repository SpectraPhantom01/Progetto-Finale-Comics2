using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayRecensioniFinali : MonoBehaviour
{
    public Recensioni2 recensione;

    public TextMeshProUGUI nomeUtente;
    public TextMeshProUGUI dataPubblicazione;
    public TextMeshProUGUI descrizione;

    //public Image sfondo;
    public Image valutazione;

    // Start is called before the first frame update
    void Start()
    {
        nomeUtente.text = recensione.nomeUtente;
        dataPubblicazione.text = recensione.dataPubblicazione;
        descrizione.text = recensione.descrizione;

        //sfondo.sprite = recensione.sfondo;
        valutazione.sprite = recensione.valutazione;
    }
}
