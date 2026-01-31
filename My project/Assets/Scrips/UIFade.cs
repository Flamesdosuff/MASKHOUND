using UnityEngine;
using System.Collections;

public class UIFade : MonoBehaviour
{
    public CanvasGroup group;
    public float duration = 0.3f;

    void Awake()
    {
        if (!group) group = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(1));
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float target)
    {
        float start = group.alpha;
        float t = 0f;

        group.blocksRaycasts = true;

        while (t < duration)
        {
            t += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, target, t / duration);
            yield return null;
        }

        group.alpha = target;
        group.blocksRaycasts = target > 0.9f;
        group.interactable = target > 0.9f;
    }
}
