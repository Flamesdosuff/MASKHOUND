using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class ParkDigController : MonoBehaviour
{
    [Header("Capas")]
    public int capasTotales = 4;
    public int progresoPorCapa = 15;

    int capaActual = 1;
    int progresoActual = 0;
    bool minijuegoActivo = true;

    [Header("Dog Paws")]
    public RectTransform leftPaw;
    public RectTransform rightPaw;

    public Vector3 pawOffset = new Vector3(0, -25f, 0);
    public float pawMoveTime = 0.08f;


    [Header("UI")]
    public Image backgroundImage;
    public Image spaceIcon;
    public Slider progressBar;
    public TMP_Text layerText;

    [Header("Fondos por capa")]
    public Sprite[] layerBackgrounds;

    [Header("Resultado")]
    public GameObject resultPanel;
    public Image resultImage;
    public TMP_Text resultText;
    public Button exitButton;

    Vector3 leftPawStart;
    Vector3 rightPawStart;

    void Start()
    {
        IniciarMinijuego();
    }

    void Update()
    {
        if (!minijuegoActivo) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnDig();
        }
    }

    void Awake()
    {
        if (leftPaw != null)
            leftPawStart = leftPaw.localPosition;

        if (rightPaw != null)
            rightPawStart = rightPaw.localPosition;
    }


    // =====================
    // LÓGICA
    // =====================
    void IniciarMinijuego()
    {
        capaActual = 0;
        progresoActual = 0;
        minijuegoActivo = true;

        progressBar.maxValue = progresoPorCapa;
        progressBar.value = 0;

        resultPanel.SetActive(false);
        exitButton.gameObject.SetActive(false);

        UpdateLayerText();
        UpdateBackground();
    }

    void OnDig()
    {
        progresoActual++;
        progressBar.value = progresoActual;

        // Feedback espacio
        spaceIcon.transform.localScale = Vector3.one * 1.2f;
        Invoke(nameof(ResetSpaceIcon), 0.08f);

        //  mover patitas
        AnimatePaws();

        if (progresoActual >= progresoPorCapa)
            NextLayer();
    }


    void AnimatePaws()
    {
        if (leftPaw != null)
            leftPaw.localPosition = leftPawStart + pawOffset;

        if (rightPaw != null)
            rightPaw.localPosition = rightPawStart + pawOffset;

        Invoke(nameof(ResetPaws), pawMoveTime);
    }

    void ResetPaws()
    {
        if (leftPaw != null)
            leftPaw.localPosition = leftPawStart;

        if (rightPaw != null)
            rightPaw.localPosition = rightPawStart;
    }


    void ResetSpaceIcon()
    {
        spaceIcon.transform.localScale = Vector3.one;
    }

    void NextLayer()
    {
        progresoActual = 0;
        progressBar.value = 0;
        capaActual++;

        if (capaActual > capasTotales)
        {
            FinishDig();
        }
        else
        {
            UpdateLayerText();
            UpdateBackground();
        }
    }

    void FinishDig()
    {
        minijuegoActivo = false;

        // Texto principal
        if (layerText != null)
            layerText.text = "CONGRATULATIONS!";

        // Obtener base
        if (BaseDatabase.Instance == null)
        {
            Debug.LogError("BaseDatabase.Instance is NULL");
            return;
        }

        ItemData baseGanada = BaseDatabase.Instance.GetRandomBase();
        if (baseGanada == null) return;

        // Agregar al inventario
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.AddItem(baseGanada);

        // UI Resultado
        if (resultImage != null)
        {
            resultImage.sprite = baseGanada.sprite;
            resultImage.preserveAspect = true;
            resultImage.enabled = true;
        }

        if (resultText != null)
            resultText.text = "You found a base!";

        if (resultPanel != null)
            resultPanel.SetActive(true);

        if (exitButton != null)
        {
            exitButton.gameObject.SetActive(true);
            exitButton.interactable = true;
        }
    }


    // =====================
    // UI
    // =====================
    void UpdateBackground()
    {
        if (backgroundImage == null) return;
        if (layerBackgrounds == null || layerBackgrounds.Length == 0) return;

        int index = capaActual-1;

        if (index < 0 || index >= layerBackgrounds.Length)
        {
            Debug.LogWarning("Background index fuera de rango: " + index);
            return;
        }

        backgroundImage.sprite = layerBackgrounds[index];
    }
    void UpdateLayerText()
    {
        if (layerText == null) return;

        layerText.text = "Layer " + (capaActual + 1) + " / " + "5";
    }

}
