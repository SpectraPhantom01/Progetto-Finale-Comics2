using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeManager : MonoBehaviour
{
    Animator fade;
    [SerializeField] UnityEvent fadeOutEvent;
    [SerializeField] UnityEvent fadeInEvent;

    private void Start()
    {
        fade = GetComponent<Animator>();
    }

    public void FadeOutAnimationEvent()
    {
        fadeOutEvent.Invoke();
    }

    public void FadeInAnimationEvent()
    {
        fadeInEvent.Invoke();
    }

    public void SetFadeOut()
    {
        fade.SetBool("SetFadeOut", true);
    }

    public void SetFadeIn()
    {
        fade.SetBool("SetFadeOut", false);
    }

}
