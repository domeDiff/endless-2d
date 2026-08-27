using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver {  get; private set; }

    private void Awake()
    {
        Instance = this;
        isGameOver = false;
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        Debug.Log("GAME OVER");
    }
}
