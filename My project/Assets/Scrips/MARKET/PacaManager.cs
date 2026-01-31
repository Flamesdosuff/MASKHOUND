using UnityEngine;

public class PacaManager : MonoBehaviour
{
    public float pacaDuration = 15f;
    float timer;

    public PacaSpawner spawner;

    void Start()
    {
        timer = pacaDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            EndPaca();
    }

    void EndPaca()
    {
        spawner.enabled = false;

        Debug.Log("Paca ended");
        enabled = false;
    }
}

