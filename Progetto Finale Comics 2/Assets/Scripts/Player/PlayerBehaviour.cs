using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float radius;
    [SerializeField] float offsetExplosion;
    //[SerializeField] Vector2 direction;
    [SerializeField] float distance;

    public void Explosion()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll((Vector2)transform.position + new Vector2(0, offsetExplosion), radius, Vector2.up, distance);

        foreach (RaycastHit2D h in hit)
        {
            Interactable interactable = h.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                interactable.action.Invoke();
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, offsetExplosion), radius);
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, distance), radius);
    }
}
