using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TraslatorType { platform, standard } 

public class Traslator : MonoBehaviour 
{
    [Header("Traslator Settings")]
    [SerializeField] float duration;
    [SerializeField] float stasisTime = 1;
    [SerializeField] Transform[] points;
    [SerializeField] TraslatorType traslatorType;
    [SerializeField] int startingIndex;
    int index;

    //[SerializeField] Transform start;
    //[SerializeField] Transform end;
    //public AnimationCurve accelerationCurve;

    [HideInInspector] public bool isTeleporting;
    public bool active = true;
    
    int i = 1;

    //Vector2 deltaMovement;
    //float elapsed = 0;
    //float position = 0;

    private void Start()
    {
        ResetPlatform();
        //GameManager.instance.onRespawn += ResetPlatform;
    }

    private void FixedUpdate()
    {
        if (active)
        {
            if (Vector2.Distance(transform.position, points[index].position) < 0.02f)
            {
                bool result = false;
                //index = Mathf.Clamp(index, 0, points.Length - 1);

                switch (traslatorType)
                {
                    case TraslatorType.platform:
                        result = CheckTeleport();
                        break;
                    case TraslatorType.standard:
                        result = CheckBounds();
                        break;
                }

                if (!result)
                    index += i;

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[index].position, duration * Time.fixedDeltaTime);
            }      
        }

        //MOVIMENTO ALTERNATIVO:
        //elapsed += (Time.fixedDeltaTime / duration);
        //position = Mathf.PingPong(elapsed, 1);
        //float amount = accelerationCurve.Evaluate(position);

        //Vector2 pos = Vector2.Lerp(start.position, end.position, amount);
        //deltaMovement = pos - rb.position;
        //rb.MovePosition(pos);

    }

    private void ResetPlatform()
    {
        index = startingIndex;
        i = 1;
        transform.position = points[index].position;
    }

    private bool CheckBounds()
    {
        if (index == points.Length - 1)
        {
            i = -1;
            return true;
        }
        else if (index == 0)
        {
            i = 1;
            return true;
        }
        return false;
    }

    private bool CheckTeleport()
    {
        if (index == points.Length - 1)
        {
            active = false;
            isTeleporting = true;
            Invoke("TeleportPlatform", stasisTime);
            return true;
        }
        return false;
    }

    private void TeleportPlatform()
    {
        index = 0;
        transform.position = points[0].position;
        isTeleporting = false;
    }

    public void PlatformState()
    {
        if (!active)
        {
            active = true;
        }
        else
        {
            ResetPlatform();
            active = false;
        }
    }


    //private void OnDrawGizmos()
    //{
    //    //Gizmos.DrawLine(start.position, end.position);
    //    foreach(Transform p in points)
    //    {
    //        for (int i = 0; i < points.Length; i++)
    //        {
    //            //Gizmos.DrawLine(points[i], points[i + 1]);
    //        }
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!(collision.gameObject.layer == LayerMask.NameToLayer("Player")))
    //        return;

    //    Debug.Log("Sono sulla piattaforma");
    //    Rigidbody2D rbody = collision.GetComponent<Rigidbody2D>();
    //    rbody.velocity = rb.velocity;

    //}

}
