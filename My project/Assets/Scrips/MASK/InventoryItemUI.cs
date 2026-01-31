using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public Image icon;
    public ItemData item;

    public void Setup(ItemData data)
    {
        item = data;

        // si hay sprite, úsalo
        if (data.sprite != null)
            icon.sprite = data.sprite;

        // si es color, pintamos el icono
        if (data.tipo == ItemType.Color)
            icon.color = data.rgb;
        else
            icon.color = Color.white;

        icon.enabled = true;
    }

    public void OnClick()
    {
        MaskCraftingController.Instance.SelectItem(item);
    }

}
