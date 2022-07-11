using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [Header("Alarm Settings")]
    [SerializeField] float activeTime;
    public UnityEvent activation;
    Animator animator;
    bool isActive = false;
    float timer;
    //public UnityEvent deactivation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AlarmActivation()
    {
        if (!isActive)
        {
            isActive = true;
            activation.Invoke();
            timer = activeTime;

            animator.SetBool("State", isActive);
            AudioManager.instance.Play("Alarm");

            StartCoroutine(Countdown());
        }
    }

    private void AlarmDeactivation()
    {
        //deactivation.Invoke();
        isActive = false;
        activation.Invoke();
        timer = 0;

        animator.SetBool("State", isActive);
        AudioManager.instance.Stop("Alarm");

        StopCoroutine(Countdown());     
    }

    private IEnumerator Countdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                AlarmDeactivation();
            }
            yield return null;
        }  
    }


}
