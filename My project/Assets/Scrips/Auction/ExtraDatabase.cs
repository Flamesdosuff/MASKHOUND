using UnityEngine;
using System.Collections.Generic;

public class ExtraDatabase : MonoBehaviour
{
    public static ExtraDatabase Instance;

    [Header("Extras disponibles")]
    public List<ItemData> extras = new List<ItemData>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public ItemData GetRandomExtra()
    {
        if (extras.Count == 0)
        {
            Debug.LogError("ExtraDatabase no tiene extras asignados");
            return null;
        }

        return extras[Random.Range(0, extras.Count)];
    }
}
