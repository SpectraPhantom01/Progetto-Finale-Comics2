using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasManager : MonoBehaviour
{
    [Header("Gas Settings")]
    [SerializeField] float speedModifier;
    [SerializeField] float time;

    //PlayerController player;
    float timer;

    public static GasManager instance;
    public static int gasCounter;

    private void OnDestroy()
    {
        instance = null;
    }

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Countdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                GameManager.instance.player.SetExplosion();
                ResetCountdown();
            }
            yield return null;
        }
    }

    public void StartCountdown()
    {
        timer = time;
        StartCoroutine(Countdown());
    }

    public void ResetCountdown()
    {
        StopCoroutine(Countdown());
        timer = 0;
        //player = null;
    }


}
