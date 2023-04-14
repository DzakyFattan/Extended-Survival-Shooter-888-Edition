using System.Collections;
// using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueUI : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private UnityEvent onDialogueEnd;

    private TypewriterEffect typewriterEffect;


    // Start is called before the first frame update
    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        showDialogue(dialogueObject);
    }

    public void showDialogue(DialogueObject dialogue)
    {
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
        onDialogueEnd.Invoke();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
