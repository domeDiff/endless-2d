using TMPro;
using UnityEngine;

public class charButton : MonoBehaviour
{
    [SerializeField] private charData CharData;
    [SerializeField] private TMP_Text statusText;

    public void Start()
    {
        if (charManager.instance.isUnlocked(CharData))
        {
            charManager.instance.SelectCharacter(CharData);
            statusText.text = "select";
        }

        else
        {
            if (charManager.instance.PurchaseCharacter(CharData))
            {
                statusText.text = "owned";
            }

            else
            {
                statusText.text = CharData.unlockCost + "C";
            }
        }
    }
    public void OnClick()
    {
        if (charManager.instance.isUnlocked(CharData))
        {
            charManager.instance.SelectCharacter(CharData);
            statusText.text = "Selected";
        }

        else
        {
            if (charManager.instance.PurchaseCharacter(CharData))
            {
                statusText.text = "owned";
            }

            else
            {
                statusText.text = CharData.unlockCost + "coins";
            }
        }

        charManager.instance.RefreshButtons();
    }

    public void UpdateStatus()
    {
        if(!charManager.instance.isUnlocked(CharData))
        {
            statusText.text = CharData.unlockCost + "coins";
            return;
        }

        else if (charManager.instance.GetSelectedCharacter() == CharData.charName)
        {
            statusText.text = "selected";
        }

        else
        {
            statusText.text = "select";
        }
    }
}
