using System;
using UnityEngine;

public class SalmonSpawner : MonoBehaviour
{
    public GameObject salmonPrefab; // Assign your salmon prefab here
    public float spawnInterval = 2f; // Time between spawns
    public float spawnRangeY = 10f; // Horizontal spawn range
    public float spawnX = -5f; // Y position for spawning

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSalmon();
            timer = 0f;
        }
    }

    void SpawnSalmon()
    {
        // Random horizontal spawn position
        float spawnY = UnityEngine.Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        GameObject salmon = Instantiate(salmonPrefab, spawnPosition, Quaternion.identity);

        // Set fixed speed moving to the left
        float speed = UnityEngine.Random.Range(20f, 40f);
        int direction = -1; // Always to the left

        // Assign speed and direction in the Salmon script
        var salmonScript = salmon.GetComponent<SalmonMovement>();
        if (salmonScript != null)
        {
            salmonScript.SetSpeed(speed, direction);
        }
    }
}
