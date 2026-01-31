using UnityEngine;
using TMPro;

public class EconomyUI : MonoBehaviour
{
    public TextMeshProUGUI dineroText;
    public TextMeshProUGUI deudaText;

    void Start()
    {
        UpdateUI();
        EconomyManager.OnEconomyChanged += UpdateUI;
    }

    void OnDestroy()
    {
        EconomyManager.OnEconomyChanged -= UpdateUI;
    }

    void UpdateUI()
    {
        var eco = EconomyManager.Instance;

        dineroText.text = "Money: $ " + eco.dinero;
        deudaText.text = "Debt: $ " + eco.deuda;
    }
}
