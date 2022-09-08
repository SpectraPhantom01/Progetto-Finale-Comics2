using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State { Inactive, Prep, Active }

public class Laser : MonoBehaviour
{
    [Header("Ray Settings")]
    [SerializeField] Transform origin;
    [SerializeField] float distance = 10;

    [Header("Time Settings")]
    [SerializeField] float delayTime;
    [Tooltip("0 sempre attivo, Valore >= 0"), Min(0)]
    [SerializeField] float activeTime;
    [Tooltip("Valore >= 0, usato solo se Active Time è > 0"), Min(0)]
    [SerializeField] float inactiveTime;
    [SerializeField] float timePrep = 1f;

    LineRenderer lineRenderer;
    Coroutine laserRoutine;

    public bool startActive;
    bool acceso;
    bool active;

    State state = State.Inactive;
   

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if(timePrep == 0)
        {
            lineRenderer.enabled = true;
            lineRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
            SetColorActive();
        }
        else
        {
            if (startActive)
                LaserState();
        }     
    }

    private void SetColorActive()
    {
        state = State.Active;

        lineRenderer.startColor = new Color(0.8f, 0, 0);
        lineRenderer.endColor = new Color(1, 0.5f, 0);
    }

    private void Update()
    {
        //if (active)
        //{
        //    ShootLaser();
        //}

        switch (state)
        {
            case State.Prep:
                PrepareLaser();
                break;
            case State.Active:
                ShootLaser();
                break;
        }

    }

    private void ShootLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, -origin.up);

        if (hit)
        {
            DrawRay(origin.position, hit.point);

            //Attivazione particellare se non attivi
            //Controllo il punto d'impatto
            //Se diverso da punto d'impatto --> spostati a punto di impatto

            CheckPlayer(hit);

        }
        else
        {
            //DrawRay(origin.position, origin.transform.right * distance);
            DrawRay(origin.position, new Vector2(origin.position.x, -distance));
        }
    }

    private static void CheckPlayer(RaycastHit2D hit)
    {
        PlayerController player = hit.transform.gameObject.GetComponent<PlayerController>();
        if (player != null && !player.isDead)
        {
            player.OnDisable();
            player.SetExplosion();
        }
    }

    private IEnumerator LaserRoutine()
    {
        //Attivazione con delay
        //Aggiungere particellare

        yield return new WaitForSeconds(delayTime);

        while (acceso)
        {
            SetColorPrep();

            yield return new WaitForSeconds(timePrep);


            //Attivo
            if (state == State.Prep)
            {
                SetColorActive();

                SetLaser(true);
            }

            //Delay
            yield return new WaitForSeconds(activeTime);

            if (inactiveTime > 0)
            {
                //Disattivo
                state = State.Inactive;
                lineRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
                SetLaser(false);

                //Delay
                yield return new WaitForSeconds(inactiveTime);
            }
        }
    }

    private void SetColorPrep()
    {
        state = State.Prep;

        lineRenderer.enabled = true;
        lineRenderer.startColor = new Color(0, 0.5f, 1);
        lineRenderer.endColor = new Color(0.8f, 0.92f, 0.016f);
    }

    private void PrepareLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, -origin.up);
        lineRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, lineRenderer.material.color.a + (Time.deltaTime / timePrep)));

        if (hit)
        {
            DrawRay(origin.position, hit.point);  
        }
        else
        {
            DrawRay(origin.position, new Vector2(origin.position.x, -distance));
        }

    }

    private void SetLaser(bool state)
    {
        //active = state;
        lineRenderer.enabled = state;
    }

    public void LaserState()
    {
        acceso = !acceso;
        if (acceso)
        {
            if(laserRoutine == null)
                laserRoutine = StartCoroutine(LaserRoutine());
        }
        else
        {
            if (laserRoutine != null)
            {
                StopCoroutine(laserRoutine);
                laserRoutine = null;
                state = State.Inactive;
                SetLaser(false);
            }              
        }
    }

    private void DrawRay(Vector2 start, Vector2 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
