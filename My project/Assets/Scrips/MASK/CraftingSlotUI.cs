using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlotUI : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item == null) return;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("CLICK DERECHO DETECTADO");
            SellManager.Instance.SelectItem(item);
        }
    }

}
