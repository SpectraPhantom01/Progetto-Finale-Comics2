using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionBehaviour : MonoBehaviour
{
    [Header("Explosion Animation Event")]
    UnityEvent endExplosion;

    float radius;
    float offsetExplosion;
    float distance;
    //[SerializeField] Vector2 direction;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //public void ExplosionAnimation(Animator animator)
    //{
    //    //Attivazione animazione esplosione
    //    animator.SetTrigger("Explosion");
    //}

    public void InitializeExplosion(float offsetExplosion, float radius, float distance, UnityEvent unityEvent)
    {
        this.offsetExplosion = offsetExplosion;
        this.radius = radius;
        this.distance = distance;
        endExplosion = unityEvent;
    }

    public void Explosion()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll((Vector2)transform.position + new Vector2(0, offsetExplosion), radius, Vector2.up, distance);

        foreach (RaycastHit2D h in hit)
        {
            Interactable interactable = h.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                //interactable.action.Invoke();

                //Registrazione:
                Debug.Log("Registrato");
                interactable.Record();
            }
        }
    }

    public void EndExplosionEvent()
    {
        endExplosion.Invoke();
        Destroy(gameObject);
    }

}
