
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;

    [Header("Spawn Timing")]
    [SerializeField] private float startMinSpawnTime = 2f;
    [SerializeField] private float startMaxSpawnTime = 3.5f;

    [Header("Difficulty")]
    [SerializeField] private float difficultyIncreaseRate = 0.01f;
    [SerializeField] private float maxDifficulty = 1f;


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
        Instantiate(obstaclePrefab,transform.position, Quaternion.identity);
    }

    private void SetNextSpawnTime()
    {
        float minSpawnTime = Mathf.Lerp(startMinSpawnTime, 1f, difficulty);
        float maxSpawnTime = Mathf.Lerp(startMaxSpawnTime, 2f, difficulty);
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void IncreaseDifficulty()
    {
        difficulty += difficultyIncreaseRate * Time.deltaTime;

        difficulty = Mathf.Clamp(difficulty, 0f, maxDifficulty);
    }
}