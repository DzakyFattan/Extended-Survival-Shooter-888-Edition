using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
  [SerializeField] private GameObject HUDCanvas;
  [SerializeField] private GameObject EnemyManager;
  [SerializeField] private GameObject dialogueBox;
  [SerializeField] private TMP_Text textLabel;
  [SerializeField] private DialogueObject dialogueObject;

  private TypewriterEffect typewriterEffect;


  // Start is called before the first frame update
  void Start()
  {
    typewriterEffect = GetComponent<TypewriterEffect>();
    CloseDialogue();
    showDialogue(dialogueObject);
  }

  public void showDialogue(DialogueObject dialogue)
  {
    HUDCanvas.SetActive(false);
    EnemyManager.SetActive(false);
    dialogueBox.SetActive(true);
    StartCoroutine(StepThroughDialogue(dialogue));
  }

  public IEnumerator StepThroughDialogue(DialogueObject dialogue)
  {
    yield return new WaitForSeconds(0.5f);
    foreach (string sentence in dialogue.Sentences)
    {
      yield return typewriterEffect.Run(sentence, textLabel, 0.02f);
      yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }
    CloseDialogue();
  }

  private void CloseDialogue()
  {
    dialogueBox.SetActive(false);
    textLabel.text = string.Empty;
    HUDCanvas.SetActive(true);
    EnemyManager.SetActive(true);
  }
}
