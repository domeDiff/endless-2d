using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins { get; private set;  }

    [SerializeField] private TMP_Text coinText;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void Start()
    {
        UpdateUI();
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.Save();

        UpdateUI();
    }

    private void UpdateUI()
    {
        if(coinText != null)
        {
            coinText.text = "coins: " + coins;
        }
    }
}
