using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nuova recensione",menuName = "RecensioneFinale")]
public class Recensioni2 : ScriptableObject
{
    public string nomeUtente;
    public string dataPubblicazione;
    public string descrizione;

    //public Sprite sfondo;
    public Sprite valutazione;
}
