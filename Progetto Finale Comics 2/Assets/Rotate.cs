using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotator Settings")]
    [SerializeField]
    float speed;
    AudioSource sound;

    public bool active = true;

    int i = 1;

    private void Start()
    {
        if (sound)
            sound.Play();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            rotate();
        }
    }

    private void rotate()
    {
        this.gameObject.transform.Rotate(0, 0, speed);
    }

    public void ObjectState()
    {
        if (!active)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }
}
