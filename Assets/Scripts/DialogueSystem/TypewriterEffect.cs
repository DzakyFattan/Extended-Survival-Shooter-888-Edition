using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
  public Coroutine Run(string text, TMP_Text textLabel, float delay)
  {
    return StartCoroutine(ShowText(text, textLabel, delay));
  }

  private IEnumerator ShowText(string text, TMP_Text textLabel, float delay)
  {
    textLabel.text = string.Empty;

    yield return new WaitForSeconds(0.2f);
    foreach (char c in text)
    {
      textLabel.text += c;
      yield return new WaitForSeconds(delay);
    }
  }
}
