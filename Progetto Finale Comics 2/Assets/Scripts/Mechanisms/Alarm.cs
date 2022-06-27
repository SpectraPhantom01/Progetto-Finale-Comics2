using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [Header("Alarm Settings")]
    [SerializeField] float activeTime;
    public UnityEvent activation;
    bool isActive = false;
    float timer;
    //public UnityEvent deactivation;

    public void AlarmActivation()
    {
        if (!isActive)
        {
            isActive = true;
            activation.Invoke();
            timer = activeTime;
            StartCoroutine(Countdown());
        }
    }

    private void AlarmDeactivation()
    {
        //deactivation.Invoke();
        activation.Invoke();
        timer = 0;
        StopCoroutine(Countdown());
        isActive = false;
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
