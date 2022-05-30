using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraslatorAlt : MonoBehaviour
{
    [Header("Traslator Settings")]
    [SerializeField] float duration;
    [SerializeField] Transform[] points;

    [SerializeField] Transform start;
    [SerializeField] Transform end;

    public AnimationCurve accelerationCurve;

    Vector2 deltaMovement;
    Rigidbody2D rb;
    float elapsed = 0;
    float position = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        elapsed += (Time.fixedDeltaTime / duration);
        position = Mathf.PingPong(elapsed, 1);
        float amount = accelerationCurve.Evaluate(position);

        Vector2 pos = Vector2.Lerp(start.position, end.position, amount);
        deltaMovement = pos - rb.position;
        rb.MovePosition(pos);
    }
}
