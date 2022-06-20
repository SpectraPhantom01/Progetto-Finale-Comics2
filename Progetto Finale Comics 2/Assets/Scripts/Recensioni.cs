using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nuova recensione",menuName = "Recensione")]
public class Recensioni : ScriptableObject
{
    public string oreGiocate;
    public string dataPubblicazione;
    public string descrizione;
    public string valutazioneText;

    //public Sprite sfondo;
    public Sprite valutazione;
}
