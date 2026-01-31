using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemData> items = new List<ItemData>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // =====================
    // INVENTARIO
    // =====================
    public void AddItem(ItemData item)
    {
        items.Add(item);
        Debug.Log("Agregado: " + item.nombre);
    }

    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }

    public List<ItemData> GetItems(ItemType tipo)
    {
        return items.FindAll(i => i.tipo == tipo);
    }

    // =====================
    // COMBINAR COLORES
    // =====================
    public ItemData CombineColors(ItemData a, ItemData b)
    {
        if (a.tipo != ItemType.Color || b.tipo != ItemType.Color)
            return null;

        Color mezcla = new Color(
            (a.rgb.r + b.rgb.r) / 2f,
            (a.rgb.g + b.rgb.g) / 2f,
            (a.rgb.b + b.rgb.b) / 2f
        );

        ItemData nuevoColor = ItemData.CrearColor(
            ItemName.ColorMixto,
            a.sprite,
            mezcla
        );

        RemoveItem(a);
        RemoveItem(b);
        AddItem(nuevoColor);

        return nuevoColor;
    }
    public void RefreshInks()
    {
        foreach (ItemData item in items)
        {
            if (item.tipo == ItemType.Color) // o ItemType.Ink si lo llamas así
            {
                // Asegurarse que tenga sprite y color asignados
                if (item.sprite == null)
                {
                    Debug.LogWarning("Item sin sprite: " + item.nombre);
                    continue;
                }

                // Si quieres recalcular color dinámicamente, puedes hacerlo aquí
                // Por ahora dejamos el color que ya tiene
                // item.rgb = item.rgb;

                Debug.Log("Item listo en inventario: " + item.nombre + " con color " + item.rgb);
            }
        }
    }

}
