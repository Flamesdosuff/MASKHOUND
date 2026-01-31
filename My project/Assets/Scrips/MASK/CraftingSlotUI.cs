using UnityEngine;
using UnityEngine.UI;

public class CraftingSlotUI : MonoBehaviour
{
    public Image icon;
    public ItemData item;

    public void SetItem(ItemData data)
    {
        item = data;
        icon.enabled = true;
        icon.sprite = data.sprite;

        if (data.tipo == ItemType.Color)
            icon.color = data.rgb;
        else
            icon.color = Color.white;
    }

    public void Clear()
    {
        item = null;
        icon.enabled = false;
    }
}
