using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuova patch note", menuName = "Patch Note")]

public class PatchNoteSO : ScriptableObject
{
    public string nPatchNote;
    [TextArea(4,20)] public string patch;
}
