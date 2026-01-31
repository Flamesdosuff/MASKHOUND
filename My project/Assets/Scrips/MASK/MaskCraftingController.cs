using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MaskCraftingController : MonoBehaviour
{
    public static MaskCraftingController Instance;

    [Header("Slots UI")]
    public Image slotAImage;
    public Image slotBImage;
    public Image slotCImage;
    public Image resultImage;

    [Header("Logic")]
    public CraftingTable craftingTable;
    private List<ItemData> lockedItems = new List<ItemData>();

    private ItemData slotA = null;
    private ItemData slotB = null;

    public MaskInventoryUI inventoryUI;

    void Awake()
    {
        Instance = this;
    }

    // =====================
    // SELECCIÓN
    // =====================
    public void SelectItem(ItemData item)
    {
        // limpiar resultado
        if (resultImage != null)
        {
            resultImage.sprite = null;
            resultImage.enabled = false;
        }

        // Slot A
        if (slotA == null)
        {
            slotA = item;
            item.isSelected = true;
            SetSlotUI(slotAImage, item);
            inventoryUI.Refresh();
            return;
        }

        // Slot B
        if (slotB == null)
        {
            slotB = item;
            item.isSelected = true;
            SetSlotUI(slotBImage, item);
            inventoryUI.Refresh();
            return;
        }


    }

    public void OnSlotClick(int slotIndex)
    {
        // limpiar resultado siempre
        if (resultImage != null)
        {
            resultImage.sprite = null;
            resultImage.enabled = false;
        }

        // Slot A
        if (slotIndex == 0 && slotA != null)
        {
            slotA.isSelected = false;
            slotA = null;
            slotAImage.enabled = false;
            inventoryUI.Refresh();
            return;
        }

        // Slot B
        if (slotIndex == 1 && slotB != null)
        {
            slotB.isSelected = false;
            slotB = null;
            slotBImage.enabled = false;
            inventoryUI.Refresh();
            return;
        }
    }

    void SetSlotUI(Image img, ItemData item)
    {
        img.sprite = item.sprite;
        img.color = item.tipo == ItemType.Color ? item.rgb : Color.white;
        img.enabled = true;
    }

    // =====================
    // COMBINAR
    // =====================
    public void Combine() 
    { if (slotA == null || slotB == null)
      return; 
      craftingTable.slotA = slotA; 
      craftingTable.slotB = slotB; 
      craftingTable.Combine();
      ItemData result = craftingTable.resultado; 
      if (result == null) 
      { 
            Debug.Log("Combinación inválida"); 
            return; 
      } if (resultImage != null) 
        { 
            resultImage.sprite = result.sprite; 
            resultImage.color = result.tipo == ItemType.Color ? result.rgb : Color.white; 
            resultImage.enabled = true; 
        } 
    ClearSlots(); inventoryUI.Refresh(); }

    void ClearSlots()
    {
        if (slotA != null) slotA.isSelected = false;
        if (slotB != null) slotB.isSelected = false;
        slotA = null;
        slotB = null;
        slotAImage.enabled = false;
        slotBImage.enabled = false;
        inventoryUI.Refresh();
    }

    public bool IsLocked(ItemData item)
    {
        return lockedItems.Contains(item);
    }
}
