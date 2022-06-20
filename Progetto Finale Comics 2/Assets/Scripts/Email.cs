using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuova Email", menuName = "Email")]
public class Email : ScriptableObject
{
    public string titolo;
    public string mittente;
    public string data;
    public string oggetto;
}
