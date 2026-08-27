using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "SCORE: " + scoreManager.Instance.score.ToString("D4");
    }
}
