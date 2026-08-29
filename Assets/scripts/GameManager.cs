using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver {  get; private set; }

    [Header("World Speed")]
    [SerializeField] private float worldSpeed = 5f;
    [SerializeField] private float maxWorldSpeed = 10f;
    [SerializeField] private float speedIncreaseRate = 0.1f;

    public float WorldSpeed => worldSpeed;

    private void Awake()
    {
        Instance = this;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
            return;

        IncreaseWorldSpeed();
    }

    private void IncreaseWorldSpeed()
    {
        worldSpeed += speedIncreaseRate * Time.deltaTime;

        worldSpeed = Mathf.Clamp(worldSpeed, 5f, maxWorldSpeed);
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        Debug.Log("GAME OVER");
    }
}
