using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Comment : MonoBehaviour
{
    [SerializeField] CommentSO commentSO;
    TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = commentSO.comment;
    }
}
