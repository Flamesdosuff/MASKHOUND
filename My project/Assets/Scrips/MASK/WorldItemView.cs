using UnityEngine;

public class WorldItemView : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetItem(ItemData item)
    {
        sr.sprite = item.sprite;

        if (item.tipo == ItemType.Color)
            sr.color = item.rgb;
        else
            sr.color = Color.white;
    }
}
