using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class charManager : MonoBehaviour
{
    public static charManager instance;

    private const string SelectedCharKey = "SelectedChar";
    [SerializeField] TMP_Text coinText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        coinText.text = "coins: " + PlayerPrefs.GetInt("coins", 0).ToString("D4");
    }

    public bool isUnlocked(charData character)
    {
        if (character.unlockCost == 0)
            return true;

        return PlayerPrefs.GetInt(character.charName, 0) == 1;
    }

    public bool PurchaseCharacter(charData character)
    {
        if (isUnlocked(character))
            return true;

        if (CoinManager.Instance.coins < character.unlockCost)
            return false;

        CoinManager.Instance.AddCoins(-character.unlockCost);

        PlayerPrefs.SetInt(character.charName, 1);

        PlayerPrefs.Save();
        return true;
    }
    
    public void SelectCharacter(charData character)
    {
        if (!isUnlocked(character))
            return;

        PlayerPrefs.SetString(SelectedCharKey, character.charName);
        PlayerPrefs.Save();
    }

    public string GetSelectedCharacter()
    {
        return PlayerPrefs.GetString(SelectedCharKey, "snowy");
    }
}
