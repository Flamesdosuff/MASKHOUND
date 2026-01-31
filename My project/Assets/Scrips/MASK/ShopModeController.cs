using UnityEngine;

public enum ShopMode
{
    Crafting,
    Selling
}

public class ShopModeController : MonoBehaviour
{
    public static ShopModeController Instance;

    [Header("Canvas Groups")]
    public CanvasGroup craftingGroup;
    public CanvasGroup sellGroup;

    [Header("Estado")]
    public ShopMode currentMode = ShopMode.Crafting;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        ShowCrafting();
    }

    // ======================
    // MODOS
    // ======================
    public void ShowCrafting()
    {

        SetGroup(craftingGroup, true);
        SetGroup(sellGroup, false);
        currentMode = ShopMode.Crafting;

    }

    public void ShowSell()
    {


        SetGroup(craftingGroup, false);
        SetGroup(sellGroup, true);
        currentMode = ShopMode.Selling;
    }

    // ======================
    // HELPERS
    // ======================
    void SetGroup(CanvasGroup cg, bool value)
    {
        if (cg == null) return;

        cg.alpha = value ? 1 : 0;
        cg.interactable = value;
        cg.blocksRaycasts = value;
    }

    // ======================
    // CONSULTA GLOBAL
    // ======================
    public bool IsCraftingMode()
    {
        return currentMode == ShopMode.Crafting;
    }

    public bool IsSellingMode()
    {
        return currentMode == ShopMode.Selling;
    }
}
