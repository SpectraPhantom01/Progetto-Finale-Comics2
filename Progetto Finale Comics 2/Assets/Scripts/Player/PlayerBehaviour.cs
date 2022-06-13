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
    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent endExplosion;
    

    //Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void Explosion()
    {
        //Attivazione animazione esplosione
    }

    public void ExplosionEvent()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll((Vector2)transform.position + new Vector2(0, offsetExplosion), radius, Vector2.up, distance);

        foreach (RaycastHit2D h in hit)
        {
            Interactable interactable = h.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                //interactable.action.Invoke();

                //Registrazione:
                //interactable.Record();
                
            }
        }    
    }

    public void DeathEvent()
    {
        //Momento effettivo dell'esplosione
        onDeath.Invoke();
    }

    public void EndExplosionEvent()
    {
        endExplosion.Invoke();
        //Richiamo del fade out
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, offsetExplosion), radius);
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, distance), radius);
    }
}
