
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;

    [Header("Obstacle Spacing")]
    [SerializeField] private float minObstacleDistance = 12f;
    [SerializeField] private float maxObstacleDistance = 20f;
    [SerializeField] private float recTime = 1f;


    [Header("Difficulty")]
    [SerializeField] private float difficultyIncreaseRate = 0.01f;
    [SerializeField] private float maxDifficulty = 1f;

    [SerializeField] private float groundY = 0f;


    private float spawnTimer;
    private float nextSpawnTime;
    private float difficulty;

    void Start()
    {
        SetNextSpawnTime();
    }
    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        spawnTimer += Time.deltaTime;

        IncreaseDifficulty();

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnObstacle();
            spawnTimer = 0f;
            SetNextSpawnTime();
            
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, groundY, transform.position.z);

        Instantiate(obstaclePrefab,spawnPosition, Quaternion.identity);
    }

    private void SetNextSpawnTime()
    {
        float minDistance = Mathf.Lerp(maxObstacleDistance, minObstacleDistance, difficulty);

        float distance = Random.Range(minDistance, maxObstacleDistance);

        float worldSpeed = GameManager.Instance.WorldSpeed;

        float distanceTime = distance / worldSpeed;

        nextSpawnTime = Mathf.Max(distanceTime, recTime);
    }

    private void IncreaseDifficulty()
    {
        difficulty += difficultyIncreaseRate * Time.deltaTime;

        difficulty = Mathf.Clamp(difficulty, 0f, maxDifficulty);
    }
}