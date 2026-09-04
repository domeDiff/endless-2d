using TMPro;
using UnityEngine;

public class charButton : MonoBehaviour
{
    [SerializeField] private charData CharData;
    [SerializeField] private TMP_Text statusText;

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
    }
}
