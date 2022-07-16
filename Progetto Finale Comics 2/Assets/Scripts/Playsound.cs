using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsound : MonoBehaviour
{
    [SerializeField]
    string sound;
    public void Playsounds()
    {
        AudioManager.instance.Play(sound);
    }

    public void Stopsounds()
    {
        AudioManager.instance.Stop(sound);
    }
}
