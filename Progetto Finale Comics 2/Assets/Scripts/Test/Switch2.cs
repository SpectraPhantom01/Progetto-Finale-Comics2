using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch2 : Interactable2
{
    public bool oneTime;
    bool active;
    public UnityEvent LeverEvent;
    //Animator animator;
    GameManager gameManager;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }

    public void LeverState()
    {
        if (!active)
        {
            active = true;
            //animator.SetBool("State", attivata);
        }
        else if (!oneTime && active)
        {
            active = false;
            //animator.SetBool("State", attivata);
        }
    }

    private void Event()
    {
        LeverEvent.Invoke();
    }

    public override void Record()
    {
        LeverState();
        gameManager.interactableListener += Event;
    }
}
