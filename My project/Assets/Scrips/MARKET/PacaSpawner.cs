using UnityEngine;
using System.Collections.Generic;

public class PacaSpawner : MonoBehaviour
{
    public List<GameObject> clothingPrefabs;
    public List<GameObject> basePrefabs;
    public List<GameObject> inkPrefabs;
    public List<GameObject> extraPrefabs;

    public Transform spawnArea;
    public float spawnInterval = 0.3f;
    public int maxObjects = 15;
    public float maxTime = 8f;

    int objectsSpawned = 0;
    float timer = 0f;
    float spawnTimer = 0f;
    bool spawning = true;

    void Update()
    {
        if (!spawning) return;

        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (timer >= maxTime || objectsSpawned >= maxObjects)
        {
            spawning = false;
            Debug.Log("Paca ended");
            return;
        }

        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomItem();
            spawnTimer = 0f;
        }
    }

    void SpawnRandomItem()
    {
        objectsSpawned++;

        GameObject prefabToSpawn = null;
        int roll = Random.Range(0, 100);

        if (roll < 50 && clothingPrefabs.Count > 0)
            prefabToSpawn = clothingPrefabs[Random.Range(0, clothingPrefabs.Count)];
        else if (roll < 70 && basePrefabs.Count > 0)
            prefabToSpawn = basePrefabs[Random.Range(0, basePrefabs.Count)];
        else if (roll < 90 && inkPrefabs.Count > 0)
            prefabToSpawn = inkPrefabs[Random.Range(0, inkPrefabs.Count)];
        else if (extraPrefabs.Count > 0)
            prefabToSpawn = extraPrefabs[Random.Range(0, extraPrefabs.Count)];

        if (prefabToSpawn == null) return;

        Vector3 pos = new Vector3(
            Random.Range(-0.5f, 0.5f) + spawnArea.position.x,
            spawnArea.position.y,
            0f
        );

        GameObject go = Instantiate(prefabToSpawn, pos, Quaternion.identity);
        go.name = prefabToSpawn.name + "(Clone)";
        Debug.Log($"{go.name} spawned");
    }
}
