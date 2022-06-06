using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] Transform origin;
    [SerializeField] float distance = 100;
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, -Vector2.up);
        if (hit)
        {
            DrawRay(origin.position, hit.point);
        }
        else
        {
            DrawRay(origin.position, origin.transform.right * distance);
        }
    }

    private void DrawRay(Vector2 start, Vector2 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
