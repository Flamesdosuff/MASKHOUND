using UnityEngine;

public class TestInventorySpawner : MonoBehaviour
{
    public Sprite spriteBlanco;

    void Start()
    {
        InventoryManager inv = InventoryManager.Instance;

        ItemData rojo = ItemData.CrearColor(
            ItemName.Rojo,
            spriteBlanco,
            Color.red
        );

        ItemData azul = ItemData.CrearColor(
            ItemName.Azul,
            spriteBlanco,
            Color.blue
        );

        inv.AddItem(rojo);
        inv.AddItem(azul);
    }
}
