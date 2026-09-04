using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetCoins();
        }

        if(Keyboard.current.gKey.wasPressedThisFrame)
        {
            GetCoins();
        }
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

    public void ResetCoins()
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.Save();

        coins = 0;
        UpdateUI();
    }

    public void GetCoins()
    {
        coins = 2000;
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.Save();

        UpdateUI();
    }

    //fox dislock

    [MenuItem("Game/Reset_Clem")]
    public static void ResetClem()
    {
       PlayerPrefs.DeleteKey("clem");
        PlayerPrefs.Save();

        Debug.Log("Clem character unlocked status reset.");
    }
}
