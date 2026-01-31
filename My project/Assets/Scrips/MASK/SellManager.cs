using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellManager : MonoBehaviour
{
    public static SellManager Instance;

    public MaskInventoryUI inventoryUI;
    public Image sellSlotImage;
    public TMP_Text priceText;
    public Button sellButton;

    ItemData selectedItem;
    int precioActual;

    void Awake()
    {
        Instance = this;
        Clear();
    }

    public void SelectItem(ItemData item)
    {
        if (item.isSelected) return;

        selectedItem = item;
        item.isSelected = true;

        sellSlotImage.sprite = item.sprite;
        sellSlotImage.enabled = true;

        sellSlotImage.color = item.tipo == ItemType.Color
            ? item.rgb
            : Color.white;

        precioActual = CalcularPrecio(item);
        priceText.text = "$" + precioActual;

        sellButton.interactable = true;

        inventoryUI.Refresh(); 
    }

    public void OnSellSlotClick()
    {
        if (selectedItem == null) return;

        selectedItem.isSelected = false;
        selectedItem = null;

        sellSlotImage.sprite = null;
        sellSlotImage.enabled = false;
        sellSlotImage.color = Color.white;

        priceText.text = "";
        sellButton.interactable = false;

        inventoryUI.Refresh(); 
    }

    int CalcularPrecio(ItemData item)
    {
        switch (item.tipo)
        {
            case ItemType.Mascara: return 500;
            case ItemType.Color: return 50;
            case ItemType.Base: return 150;
            case ItemType.Extra: return 300;
            default: return 0;
        }
    }

    public void Sell()
    {
        if (selectedItem == null) return;

        string nombreVendido = selectedItem.nombre.ToString();

        InventoryManager.Instance.RemoveItem(selectedItem);
        EconomyManager.Instance.AddDinero(precioActual);

        Debug.Log("Vendido: " + nombreVendido);

        Clear();
        inventoryUI.Refresh();
    }


    void Clear()
    {
        selectedItem = null;

        sellSlotImage.sprite = null;
        sellSlotImage.enabled = false;
        sellSlotImage.color = Color.white;

        priceText.text = "";
        sellButton.interactable = false;
    }
}
