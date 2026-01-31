using UnityEngine;

[System.Serializable]
public class ItemData
{
    public ItemType tipo;
    public ItemName nombre;
    public Sprite sprite;
    public bool isSelected = false;


    public Color color = Color.white;

    // SOLO si es color
    public Color rgb;

    // SOLO si es máscara
    public ItemData baseItem;
    public ItemData colorItem;
    public ItemData extraItem;

    // =========================
    // BASE o EXTRA
    // =========================
    public static ItemData CrearSimple(ItemType tipo, ItemName nombre, Sprite sprite)
    {
        return new ItemData
        {
            tipo = tipo,
            nombre = nombre,
            sprite = sprite,
            rgb = Color.white
        };
    }

    // =========================
    // COLOR
    // =========================
    public static ItemData CrearColor(ItemName nombre, Sprite sprite, Color color)
    {
        return new ItemData
        {
            tipo = ItemType.Color,
            nombre = nombre,
            sprite = sprite,
            rgb = color
        };
    }

    // =========================
    // MÁSCARA
    // =========================
    public static ItemData CrearMascara(
        ItemName nombre,
        Sprite sprite,
        ItemData baseItem,
        ItemData colorItem
    )
    {
        return new ItemData
        {
            tipo = ItemType.Mascara,
            nombre = nombre,
            sprite = sprite,
            baseItem = baseItem,
            colorItem = colorItem,
            rgb = colorItem.rgb
        };
    }

    // =========================
    // MÁSCARA +
    // =========================
    public static ItemData CrearMascaraPlus(
        ItemName nombre,
        Sprite sprite,
        ItemData mascara,
        ItemData extra
    )
    {
        return new ItemData
        {
            tipo = ItemType.Mascara,
            nombre = nombre,
            sprite = sprite,
            baseItem = mascara.baseItem,
            colorItem = mascara.colorItem,
            extraItem = extra,
            rgb = mascara.rgb
        };
    }
}
