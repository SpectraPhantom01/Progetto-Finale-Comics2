using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] float radius;
    [SerializeField] float offsetExplosion;
    //[SerializeField] Vector2 direction;
    [SerializeField] float distance;

    [Header("Explosion Animation Event")]
    [SerializeField] UnityEvent preparation;
    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent endExplosion;

    //Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    //public void ExplosionAnimation(Animator animator)
    //{
    //    //Attivazione animazione esplosione
    //    animator.SetTrigger("Explosion");
    //}

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

    public void PreparationEvent()
    {
        preparation.Invoke();
    }

    public void DeathEvent()
    {
        onDeath.Invoke();
    }

    public void EndExplosionEvent()
    {
        endExplosion.Invoke();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, offsetExplosion), radius);
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, distance), radius);
    }
}
