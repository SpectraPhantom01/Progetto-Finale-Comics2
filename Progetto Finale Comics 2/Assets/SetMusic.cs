using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour
{
    [SerializeField]
    private string music;

    void Start()
    {
        AudioManager.instance.Play(music);
    }
}
