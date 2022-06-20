using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MailDisplay : MonoBehaviour
{
    public Email email;

    public TextMeshProUGUI titolo;
    public TextMeshProUGUI mittente;
    public TextMeshProUGUI data;
    public TextMeshProUGUI oggetto;

    // Start is called before the first frame update
    void Start()
    {
        titolo.text = email.titolo;
        mittente.text = email.mittente;
        data.text = email.data;
        oggetto.text = email.oggetto;
    }
}
