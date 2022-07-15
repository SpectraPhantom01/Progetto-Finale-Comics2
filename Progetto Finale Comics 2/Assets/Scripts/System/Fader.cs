using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fader : MonoBehaviour
{
    //[SerializeField] UnityEvent fadeOutEvent;
    //[SerializeField] UnityEvent fadeInEvent;
    
    public UnityAction fadeOutAction;
    public UnityAction fadeInAction;
    //Animator fade;

    //private void Start()
    //{
    //    fade = GetComponent<Animator>();
    //}

    public void FadeOutAnimationEvent()
    {
        //fadeOutEvent.Invoke();

        fadeOutAction?.Invoke();
    }

    public void FadeInAnimationEvent()
    {
        //fadeInEvent.Invoke();

        fadeInAction?.Invoke();
    }

    //public void SetFadeOut()
    //{
    //    fade.SetBool("SetFadeOut", true);
    //}

    //public void SetFadeIn()
    //{
    //    fade.SetBool("SetFadeOut", false);
    //}

}
