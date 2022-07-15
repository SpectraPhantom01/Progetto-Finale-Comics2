using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    [SerializeField] int maxComments = 17;
    [SerializeField] GameObject textContainerUI;
    public static ChatManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void AddComment(Comment comment)
    {
        comment.transform.SetParent(textContainerUI.transform, false);

        if(textContainerUI.transform.childCount > maxComments)
        {
            Destroy(textContainerUI.transform.GetChild(0).gameObject);
        }
    }

}
