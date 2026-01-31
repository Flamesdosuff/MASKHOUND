using UnityEngine;

public class PacaItemController : MonoBehaviour
{
    public ItemData itemData; // Esto ya existe
    public SpriteRenderer outlineRenderer;

    void Start()
    {
        if (itemData != null)
            Debug.Log($"{gameObject.name} spawned, type: {itemData.tipo}");

        if (outlineRenderer == null)
            Debug.LogWarning($"{gameObject.name} no tiene Outline asignado");

        UpdateOutline();
    }

    void UpdateOutline()
    {
        if (outlineRenderer == null || itemData == null) return;

        // Verde si seleccionable (Base o Color), rojo si no seleccionable (Clothing/Extra)
        if (itemData.tipo == ItemType.Base || itemData.tipo == ItemType.Color)
            outlineRenderer.color = Color.green;
        else
            outlineRenderer.color = Color.red;
    }

    void OnMouseDown()
    {
        if (itemData == null) return;

        // Solo seleccionables: Base o Color
        if (itemData.tipo == ItemType.Base || itemData.tipo == ItemType.Color)
        {
            InventoryManager.Instance.AddItem(itemData);
            Destroy(gameObject);
            Debug.Log($"{itemData.nombre} agregado al inventario");
        }
        else
        {
            Debug.Log($"{itemData.nombre} no seleccionable");
        }
    }
}
