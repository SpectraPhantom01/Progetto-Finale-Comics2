using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : Interactable
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
            //animator.SetBool("State", active);
        }
        else if (!oneTime && active)
        {
            active = false;
            //animator.SetBool("State", active);
        }
    }

    private void Event()
    {
        LeverEvent.Invoke();
        Debug.Log("Attivazione evento");
    }

    public override void Record()
    {
        LeverState();
        gameManager.interactableListener += Event;
    }
}
