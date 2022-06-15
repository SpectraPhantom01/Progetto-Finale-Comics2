using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchOld : MonoBehaviour
{
    public bool oneTime;
    bool active;

    public UnityEvent LeverEvent;

    //Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
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

    public void LeverAnimationEvent()
    {
        LeverEvent.Invoke();
    }
}
