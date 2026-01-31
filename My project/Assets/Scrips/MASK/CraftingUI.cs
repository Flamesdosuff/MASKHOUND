using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public static CraftingUI Instance;

    public CraftingSlotUI slotA;
    public CraftingSlotUI slotB;
    public CraftingSlotUI slotResultado;

    public CraftingTable craftingLogic;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectItem(ItemData item)
    {
        if (slotA.item == null)
        {
            slotA.SetItem(item);
            return;
        }

        if (slotB.item == null)
        {
            slotB.SetItem(item);
            return;
        }
    }

    public void OnCombine()
    {
        craftingLogic.slotA = slotA.item;
        craftingLogic.slotB = slotB.item;

        craftingLogic.Combine();

        if (craftingLogic.resultado != null)
        {
            slotResultado.SetItem(craftingLogic.resultado);
            slotA.Clear();
            slotB.Clear();
        }
    }
}
