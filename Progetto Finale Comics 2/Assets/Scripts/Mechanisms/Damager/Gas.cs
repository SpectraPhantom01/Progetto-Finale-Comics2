using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    [Header("Gas Settings")]
    [SerializeField] float speed;
    [SerializeField] float time;
    float timer;
    float realSpeed;

    private IEnumerator Countdown()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        { 
            //Esplosione
        }
        yield return null;
    }

    private void StartCountdown()
    {
        timer = time;

        //Assegnazione speed
        
        //Real Speed terrà a mente la speed originale

        StartCoroutine(Countdown());
    }

    private void ResetCountdown()
    {
        timer = 0;

        //Viene riassegnata la speed originale

        StopCoroutine(Countdown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            
            StartCountdown();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            
            ResetCountdown();
        }
    }
}
