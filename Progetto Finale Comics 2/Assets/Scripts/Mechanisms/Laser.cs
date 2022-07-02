using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    LineRenderer lineRenderer;
    Coroutine laserRoutine;

    public bool startActive;
    bool acceso;
    bool active;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    
        if (startActive)
            LaserState();
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
            //Attivo
            if (!active)
                SetLaser(true);

            //Delay
            yield return new WaitForSeconds(activeTime);

            if(activeTime > 0)
            {
                //Disattivo
                SetLaser(false);
                //Delay
                yield return new WaitForSeconds(inactiveTime);
            }           
        }
    }

    private void SetLaser(bool state)
    {
        active = state;
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
