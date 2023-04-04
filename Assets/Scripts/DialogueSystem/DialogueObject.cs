using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
  [SerializeField][TextArea] private string[] sentences;

  public string[] Sentences => sentences;
}
