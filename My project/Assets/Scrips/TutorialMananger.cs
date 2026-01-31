using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TutorialMananger : MonoBehaviour
{
    public RectTransform[] objetivos;
    public TutorialHighlighter highlight;

    public TextMeshProUGUI textoProtagonista;
    public TextMeshProUGUI textoAbuelo;

    public UIFade personajeFade;
    public UIFade dialogoFade;

    public UIFade abueloperro;
    public UIFade dialogoFade2;

    private int paso = -15;
    private int pasoFinal = 4;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
        {
            gameObject.SetActive(false);
            return;
        }

        MostrarPaso(paso);
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SiguientePaso();
        }
    }

    // ===============================
    // ====== UTILIDADES ============
    // ===============================

    void HablaProtagonista(string mensaje)
    {
        dialogoFade2.FadeOut();   // ocultas SOLO la burbuja del abuelo

        personajeFade.FadeIn();
        dialogoFade.FadeIn();

        textoProtagonista.text = mensaje;
    }


    void HablaAbuelo(string mensaje)
    {
        dialogoFade.FadeOut();

        abueloperro.FadeIn();
        dialogoFade2.FadeIn();

        textoAbuelo.text = mensaje;
    }

    // ===============================
    // ====== PASOS ==================
    // ===============================

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
            // ===== PRÓLOGO =====

            case -15:
                HablaProtagonista("Grandpa? I can’t believe it… I haven’t seen you in forever. How are you doing?");
                break;

            case -14:
                HablaAbuelo("John… I’m sorry for calling you like this, out of nowhere.");
                break;

            case -13:
                HablaAbuelo("I won’t lie to you. I don’t have much time left.");
                break;

            case -12:
                HablaAbuelo("I’m going to die soon… and I have no one else to leave my inheritance to.");
                break;

            case -11:
                HablaAbuelo("I want you to take it. Everything I built… I want it to be yours.");
                break;

            case -10:
                HablaProtagonista("Thank you, Grandpa. I swear I’ll continue your legacy. I won’t let it fade away.");
                break;

            case -9:
                HablaAbuelo("Then make it official. Sign these papers… and face what comes next.");
                break;

            // ===== GIRO =====

            case -8:
                HablaProtagonista("Alright… it’s done. I’ll protect everything you left behind.");
                break;

            case -7:
                HablaAbuelo("Good… now I can finally tell you what you truly inherited.");
                break;

            case -6:
                HablaAbuelo("A debt of one hundred thousand dollars.");
                break;

            case -5:
                HablaAbuelo("(The old man collapses. Silence.)");
                break;

            case -4:
                HablaProtagonista("No… Grandpa! Don’t die! Please!");
                break;

            case -3:
                abueloperro.FadeOut();
                dialogoFade2.FadeOut();
                HablaProtagonista("A hundred thousand dollars…? This can’t be real.");
                break;

            case -2:
                HablaProtagonista("I have no savings. No safety net.");
                break;

            case -1:
                HablaProtagonista("My only job is making masks.");
                break;

            // ===== GAMEPLAY =====

            case 0:
                HablaProtagonista("Alright… first things first. This is my shop. Luckily, it already has all the machinery I need to make masks.");
                break;

            case 1:
                HablaProtagonista("For materials, I can go to the market and check the bundles. I should be able to find everything I need there.");
                break;

            case 2:
                HablaProtagonista("The bank… that’s where I’ll have to pay the debt. I don’t think there’s a rush yet, but I can’t ignore it forever.");
                break;

            case 3:
                HablaProtagonista("At the park, I can dig around and scratch the ground. Who knows… I might find something valuable.");
                break;

            case 4:
                HablaProtagonista("And the auctions… I could get some really good stuff there. As long as I have money. Yeah… this should be enough to pay off that debt!");
                break;
        }
    }

    void SiguientePaso()
    {
        paso++;

        if (paso > pasoFinal)
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
            PlayerPrefs.Save();

            dialogoFade.FadeOut();
            dialogoFade2.FadeOut();
            personajeFade.FadeOut();
            abueloperro.FadeOut();

            gameObject.SetActive(false);
            return;
        }

        MostrarPaso(paso);
    }
}
