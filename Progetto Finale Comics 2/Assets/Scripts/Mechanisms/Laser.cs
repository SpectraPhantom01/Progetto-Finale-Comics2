using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LaserType { Normal, Repeater }

public class Laser : MonoBehaviour
{
    [Header("Ray Settings")]
    [SerializeField] Transform origin;
    [SerializeField] float distance = 10;

    [Header("Timer Settings")]
    [SerializeField] float delayTimer;
    [SerializeField] float activeTimer;
    [SerializeField] float inactiveTimer;

    [Header("Laser Type Settings")]
    [SerializeField] LaserType laserType;

    LineRenderer lineRenderer;
    bool active;
    float timer;

    private void Awake()
    {
        timer = delayTimer;
        lineRenderer = GetComponent<LineRenderer>(); 
        StartCoroutine(DelayCountdown());
    }

    private void Update()
    {
        if (active)
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, Vector2.down);

        if (hit)
        {
            DrawRay(origin.position, hit.point);
        }
        else
        {
            //DrawRay(origin.position, origin.transform.right * distance);
            DrawRay(origin.position, new Vector2(origin.position.x, -distance));
        }
    }

    private IEnumerator DelayCountdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                StopCoroutine(DelayCountdown());
                LaserState();

                if (laserType == LaserType.Repeater)
                {
                    timer = activeTimer;
                    //StartCoroutine(ActiveCountdown());
                    StartCoroutine(Test());
                }               
            }
            yield return null;
        }
    }

    private void LaserState()
    {
        if (!active)
        {
            active = true;
            lineRenderer.enabled = true;
        }
        else
        {
            active = false;
            lineRenderer.enabled = false;
        }       
    }

    private IEnumerator Test()
    {
        while(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                timer = activeTimer;
                LaserState();

                //StopCoroutine(Test());
                yield return null;
                //StartCoroutine(Test());
            }     
        } 
    }

    //private IEnumerator InactiveCountdown()
    //{
    //    while (timer > 0)
    //    {
    //        timer -= Time.deltaTime;

    //        if (timer < 0)
    //        {
    //            StopCoroutine(InactiveCountdown());

    //            timer = activeTimer;
    //            active = true;
    //            lineRenderer.enabled = true;

    //            StartCoroutine(ActiveCountdown());
    //        }

    //        yield return null;
    //    }
    //}

    //private IEnumerator ActiveCountdown()
    //{
    //    while (timer > 0)
    //    {
    //        timer -= Time.deltaTime;

    //        if (timer < 0)
    //        {
    //            StopCoroutine(ActiveCountdown());

    //            timer = inactiveTimer;
    //            active = false;
    //            lineRenderer.enabled = false;

    //            StartCoroutine(InactiveCountdown());
    //        }

    //        yield return null;
    //    }
    //}

    private void DrawRay(Vector2 start, Vector2 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
