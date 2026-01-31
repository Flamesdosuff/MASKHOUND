using UnityEngine;

public class TutorialHighlighter : MonoBehaviour
{
    public RectTransform target;    // botón real (MenuCanvas)
    private RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (target == null) return;
        rect.position = target.position;
        rect.sizeDelta = target.sizeDelta * 1.2f; // un poco más grande
    }
}
