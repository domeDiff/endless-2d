
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float minSpawnTime = 1.5f;
    [SerializeField] private float maxSpawnTime = 3f;

    private float spawnTimer;
    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnObstacle();
            SetNextSpawnTime();
            spawnTimer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab,transform.position, Quaternion.identity);
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}