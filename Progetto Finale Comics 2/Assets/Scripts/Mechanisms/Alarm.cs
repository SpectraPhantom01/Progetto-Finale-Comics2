using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [Header("Alarm Settings")]
    [SerializeField] float activeTime;
    public UnityEvent activation;
    float timer;
    //public UnityEvent deactivation;

    public void AlarmActivation()
    {
        activation.Invoke();
        timer = activeTime;
        StartCoroutine(Countdown());
    }

    public void AlarmDeactivation()
    {
        //deactivation.Invoke();

        activation.Invoke();
        timer = 0;
        StopCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            AlarmDeactivation();
        }
        yield return null;
    }


}
