using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TMPFadeController : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;
    [SerializeField] private TMP_Text targetText;

    [SerializeField] private UnityEvent onFadeComplete;

    public void FadeText()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            targetText.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        targetText.color = endColor;
        onFadeComplete.Invoke();
    }
}
