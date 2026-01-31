using UnityEngine;

[CreateAssetMenu(menuName = "SpritesOriginales")]
public class ItemDefinition : ScriptableObject
{
    public ItemType tipo;
    public ItemName nombre;
    public Sprite sprite;

    // solo si es color
    public Color color;
}
