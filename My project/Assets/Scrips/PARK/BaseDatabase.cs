using UnityEngine;
using System.Collections.Generic;

public class BaseDatabase : MonoBehaviour
{
    public static BaseDatabase Instance;
    public List<ItemData> bases = new List<ItemData>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public ItemData GetRandomBase()
    {
        if (bases.Count == 0)
        {
            Debug.LogError("BaseDatabase: no hay bases cargadas");
            return null;
        }

        return bases[Random.Range(0, bases.Count)];
    }

}
