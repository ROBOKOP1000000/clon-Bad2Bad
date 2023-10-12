using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int numberOfZombiesToSpawn = 10;
    public float spawnRadius = 10f; // Радиус для спавна зомби
    public float innerCircleRadius = 3f; // Радиус внутреннего круга

    private void Start()
    {
        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        Vector3 randomSpawnPosition = RandomPointInCircle();
        Instantiate(zombiePrefab, randomSpawnPosition, Quaternion.identity);
    }

    private Vector3 RandomPointInCircle()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * (spawnRadius - innerCircleRadius);
        return new Vector3(randomPoint.x + transform.position.x, randomPoint.y + transform.position.y, 0f);
    }
}






