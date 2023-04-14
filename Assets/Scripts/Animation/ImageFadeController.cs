using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ImageFadeController : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;
    [SerializeField] private Image targetImg;
    [SerializeField] private UnityEvent onFadeComplete;
    [SerializeField] private float durationBeforeComplete;

    public void FadeImage()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            targetImg.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        targetImg.color = endColor;
        yield return new WaitForSeconds(durationBeforeComplete);
        onFadeComplete.Invoke();
    }
}
