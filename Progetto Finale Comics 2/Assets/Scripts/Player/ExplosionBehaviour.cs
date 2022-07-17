using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionBehaviour : MonoBehaviour
{
    float radius;
    float offsetExplosion;
    float distance;
    //[SerializeField] Vector2 direction;

    public void InitializeExplosion(float offsetExplosion, float radius, float distance)
    {
        this.offsetExplosion = offsetExplosion;
        this.radius = radius;
        this.distance = distance;
    }

    public void Explosion()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll((Vector2)transform.position + new Vector2(0, offsetExplosion), radius, Vector2.up, distance);

        foreach (RaycastHit2D h in hit)
        {
            Interactable interactable = h.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                interactable.Record();
            }
        }
    }

    public void EndExplosionEvent()
    {
        GameManager.instance.SetFadeOut();
        Destroy(gameObject);
    }

}
