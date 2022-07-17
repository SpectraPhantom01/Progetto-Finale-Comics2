using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager Settings")]
    [SerializeField] Canvas canvas;
    public Transform currentSpawn;
    public UnityAction interactableListener;
    public UnityAction onRespawn;

    public static GameManager instance;

    [SerializeField] PlayerController player;
    Animator canvasAnimator;

    private void OnDestroy()
    {
        instance = null;
    }

    private void Awake()
    {
        instance = this;

        canvasAnimator = canvas.GetComponent<Animator>();
        SetDeath();
    }

    public void SetDeath()
    {        
        Fader canvasFader = canvas.GetComponent<Fader>();

        canvasFader.fadeOutAction += Respawn;
        canvasFader.fadeOutAction += SetFadeIn;
        canvasFader.fadeInAction += player.OnEnable;
        canvasFader.fadeInAction += InvokeInteractableListener;
    }

    public void Respawn(/*Transform player*/)
    {
        //player.position = currentSpawn.position;
        player.transform.position = currentSpawn.position;
        onRespawn?.Invoke();
    }

    //public void FadeOutAnimationEvent()
    //{
    //    Respawn();
    //    SetFadeIn();
    //}

    //public void FadeInAnimationEvent()
    //{
    //    player.GetComponent<PlayerController>().OnEnable();
    //    InvokeInteractableListener();
    //}

    public void SetFadeOut()
    {
        canvasAnimator.SetBool("SetFadeOut", true);
    }

    public void SetFadeIn()
    {
        canvasAnimator.SetBool("SetFadeOut", false);
    }

    //public void SetPlayer(PlayerController playerController)
    //{
    //    player = playerController.gameObject;
    //}

    public void InvokeInteractableListener()
    {
        interactableListener?.Invoke();
    }
}
