using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Instance;

    public int score { get; private set; }

    [SerializeField] private float pointPerSec = 10f;

    private float scoreTimer;
    private void Awake()
    {
        Instance = this;
        score = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        scoreTimer += pointPerSec * Time.deltaTime;

        score = Mathf.FloorToInt(scoreTimer);
    }

}
