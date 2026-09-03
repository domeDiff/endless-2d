using UnityEngine;
using UnityEngine.Rendering;

public class coinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float minSpawnTime = 1.5f;
    [SerializeField] private float maxSpawnTime = 3f;
    [SerializeField] private float minSpawnY = 0.5f;
    [SerializeField] private float maxSpawnY = 1.5f;

    private float spawnTimer;
    private float nextSpawnTime;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        if(GameManager.Instance.isGameOver)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnCoin();
            spawnTimer = 0f;
            SetNextSpawnTime();
        }
    }

    private void SpawnCoin()
    {
        float randomY = Random.Range(minSpawnY, maxSpawnY);

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
