using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslator : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] Transform[] points;
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    public AnimationCurve accelerationCurve;

    public Vector2 deltaMovement;
    int index;
    float elapsed = 0;
    float position = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = points[0].position;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, points[index].position) < 0.02f)
        {
            index++;
            if (index == points.Length)
            {
                index = 0;
            }
        }

        //elapsed += (Time.fixedDeltaTime / duration);
        //position = Mathf.PingPong(elapsed, 1);
        //float amount = accelerationCurve.Evaluate(position);

        //Vector2 pos = Vector2.Lerp(start.position, end.position, amount);
        //deltaMovement = pos - rb.position;
        //rb.MovePosition(pos);

        transform.position = Vector2.MoveTowards(transform.position, points[index].position, duration * Time.deltaTime);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(start.position, end.position);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!(collision.gameObject.layer == LayerMask.NameToLayer("Player")))
    //        return;

    //    Debug.Log("Sono sulla piattaforma");
    //    Rigidbody2D rbody = collision.GetComponent<Rigidbody2D>();
    //    rbody.velocity = rb.velocity;

    //}

}
