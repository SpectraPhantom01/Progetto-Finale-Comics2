using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecensioneDisplay : MonoBehaviour
{
    public Recensioni recensione;

    public TextMeshProUGUI oreGiocate;
    public TextMeshProUGUI dataPubblicazione;
    public TextMeshProUGUI descrizione;
    public TextMeshProUGUI valutazioneText;

    //public Image sfondo;
    public Image valutazione;
    // Start is called before the first frame update
    void Start()
    {
        oreGiocate.text = recensione.oreGiocate;
        dataPubblicazione.text = recensione.dataPubblicazione;
        descrizione.text = recensione.descrizione;
        valutazioneText.text = recensione.valutazioneText;

        //sfondo.sprite = recensione.sfondo;
        valutazione.sprite = recensione.valutazione;
    }
}
