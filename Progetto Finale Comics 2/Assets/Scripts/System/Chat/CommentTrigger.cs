using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentTrigger : MonoBehaviour
{ 
    [SerializeField] CommentSO commentSO;
    [SerializeField] Comment prefabComment;
    bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (!activated)
            {
                Comment instantiedComment = Instantiate(prefabComment);
                instantiedComment.InitializeComment(commentSO.username, commentSO.comment);
                
                ChatManager.instance.AddComment(instantiedComment);
                activated = true;
            }
        }     
    }
}
