using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverButton : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    private Vector3 escalaOriginal;
    public Vector3 escalaHover = new Vector3(1.1f, 1.1f, 1.1f);
    public float velocidad = 10f;

    // SONIDOS
    public AudioClip sonidoHover;
    public AudioClip sonidoClick;

    private AudioSource audioSource;
    private bool hover = false;

    void Start()
    {
        escalaOriginal = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hover)
            transform.localScale = Vector3.Lerp(transform.localScale, escalaHover, Time.deltaTime * velocidad);
        else
            transform.localScale = Vector3.Lerp(transform.localScale, escalaOriginal, Time.deltaTime * velocidad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
        if (sonidoHover)
            audioSource.PlayOneShot(sonidoHover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (sonidoClick)
            audioSource.PlayOneShot(sonidoClick);
    }
}
