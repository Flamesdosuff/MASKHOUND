using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public ItemData slotA;
    public ItemData slotB;
    public ItemData resultado;

    public Sprite mascaraBaseSprite;
    public Sprite mascaraExtraSprite;

    public void Combine()
    {
        if (slotA == null || slotB == null) return;

        // COLOR + COLOR
        if (EsColor(slotA) && EsColor(slotB))
        {
            resultado = InventoryManager.Instance.CombineColors(slotA, slotB);
            return;
        }

        // BASE + COLOR
        if (EsBase(slotA) && EsColor(slotB))
        {
            resultado = CrearMascara(slotA, slotB);
            return;
        }

        if (EsColor(slotA) && EsBase(slotB))
        {
            resultado = CrearMascara(slotB, slotA);
            return;
        }

        // MÁSCARA + EXTRA
        if (EsMascara(slotA) && EsExtra(slotB))
        {
            resultado = CrearMascaraPlus(slotA, slotB);
            return;
        }

        if (EsExtra(slotA) && EsMascara(slotB))
        {
            resultado = CrearMascaraPlus(slotB, slotA);
            return;
        }

        Debug.Log("Combinación no válida");
    }

    // =====================
    // CREACIONES
    // =====================
    ItemData CrearMascara(ItemData baseItem, ItemData color)
    {
        ItemData nueva = ItemData.CrearMascara(
            ItemName.MascaraSimple,
            mascaraBaseSprite,
            baseItem,
            color
        );

        InventoryManager.Instance.RemoveItem(baseItem);
        InventoryManager.Instance.RemoveItem(color);
        InventoryManager.Instance.AddItem(nueva);

        return nueva;
    }

    ItemData CrearMascaraPlus(ItemData mascara, ItemData extra)
    {
        ItemData nueva = ItemData.CrearMascaraPlus(
            ItemName.MascaraPlus,
            mascaraExtraSprite,
            mascara,
            extra
        );

        InventoryManager.Instance.RemoveItem(mascara);
        InventoryManager.Instance.RemoveItem(extra);
        InventoryManager.Instance.AddItem(nueva);

        return nueva;
    }


    // =====================
    // HELPERS
    // =====================
    bool EsColor(ItemData i) => i.tipo == ItemType.Color;
    bool EsBase(ItemData i) => i.tipo == ItemType.Base;
    bool EsMascara(ItemData i) => i.tipo == ItemType.Mascara;
    bool EsExtra(ItemData i) => i.tipo == ItemType.Extra;
}
