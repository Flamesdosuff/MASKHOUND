using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class MASKTutorialMananger : MonoBehaviour
{
    public RectTransform[] objetivos;  // botones reales
    public TutorialHighlighter highlight;
    public TextMeshProUGUI texto;
    public UIFade personajeFade;
    public UIFade dialogoFade;
    private int paso = -1;

    void Start()
    {

        PlayerPrefs.DeleteAll();


        if (PlayerPrefs.GetInt("MASKTutorialCompleted", 0) == 1)
        {
            gameObject.SetActive(false);
            return;
        }

        MostrarPaso(-1);
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SiguientePaso();
        }
    }

    void MostrarPaso(int i)
    {
        if (i < 0)
        {
            highlight.gameObject.SetActive(false);
            highlight.gameObject.SetActive(true);
        }
        if (i >= 0)
        {
            highlight.target = objetivos[i];
        }
        switch (i)
        {
            case -1:
                personajeFade.FadeIn();
                dialogoFade.FadeIn();
                texto.text = "This is my mask shop… let’s take another look at what I’ve got here.";
                // Protagonista
                break;

            case 0:
                highlight.target = objetivos[0];
                texto.text = "Here’s my inventory. Everything I’ve collected so far—base masks, inks, and materials.";
                // Protagonista
                break;

            case 1:
                highlight.target = objetivos[1];
                texto.text = "And over here is my workbench. I can combine two items to create something new. Good thing I’ve got my recipes right here.";
                // Protagonista
                break;
        }

    }

    void SiguientePaso()
    {
        paso++;

        if (paso >= objetivos.Length)
        {
            PlayerPrefs.SetInt("MASKTutorialCompleted", 1);
            PlayerPrefs.Save();

            gameObject.SetActive(false); // termina tutorial
            return;
        }

        MostrarPaso(paso);
    }
}