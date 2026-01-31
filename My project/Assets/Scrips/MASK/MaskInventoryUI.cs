using UnityEngine;

public class MaskInventoryUI : MonoBehaviour
{
    public Transform content;
    public GameObject itemButtonPrefab;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform c in content)
            Destroy(c.gameObject);

        foreach (ItemData item in InventoryManager.Instance.items)
        {
            if (item.isSelected)
                continue; // no mostrar

            GameObject go = Instantiate(itemButtonPrefab, content);
            go.GetComponent<InventoryItemUI>().Setup(item);
        }
    }

}
