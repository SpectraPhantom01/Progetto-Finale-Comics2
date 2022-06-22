using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    [Header("Gas Settings")]
    [SerializeField] Canvas canvas;
    [SerializeField] float speedModifier;
    [SerializeField] float time;
    float timer;
    //float realSpeed;

    private IEnumerator Countdown()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                //Esplosione
                Debug.Log("Morto");
                ResetCountdown();
            }
            yield return null;
        }
    }

    private void StartCountdown()
    {
        timer = time;
        StartCoroutine(Countdown());
    }

    private void ResetCountdown()
    {
        timer = 0;
        StopCoroutine(Countdown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementModifier(speedModifier);
            StartCountdown();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementModifier(1);
            ResetCountdown();
        }
    }
}
