using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    Animator fade;

    private void Start()
    {
        fade = GetComponent<Animator>();
    }


    //public void Setfade()
    //{
    //    fade.SetTrigger("Test");
    //}

}
