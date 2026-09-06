//using TMPro;
//using UnityEngine;

//public class charButton : MonoBehaviour
//{
//    [SerializeField] private charData CharData;
//    [SerializeField] private TMP_Text statusText;

//    public void Start()
//    {
//        if (charManager.instance.isUnlocked(CharData))
//        {
//            charManager.instance.SelectCharacter(CharData);
//            statusText.text = "select";
//        }

//        else
//        {
//            if (charManager.instance.PurchaseCharacter(CharData))
//            {
//                statusText.text = "select";
//            }

//            else
//            {
//                statusText.text = CharData.unlockCost + "C";
//            }
//        }
//    }
//    public void OnClick()
//    {
//        if (charManager.instance.isUnlocked(CharData))
//        {
//            charManager.instance.SelectCharacter(CharData);
//            statusText.text = "Selected";
//        }

//        else
//        {
//            if (charManager.instance.PurchaseCharacter(CharData))
//            {
//                statusText.text = "owned";
//            }

//            else
//            {
//                statusText.text = CharData.unlockCost + "coins";
//            }
//        }

//        charManager.instance.RefreshButtons();
//    }

//    public void UpdateStatus()
//    {
//        if(!charManager.instance.isUnlocked(CharData))
//        {
//            statusText.text = CharData.unlockCost + "coins";
//            return;
//        }

//        else if (charManager.instance.GetSelectedCharacter() == CharData.charName)
//        {
//            statusText.text = "selected";
//        }

//        else
//        {
//            statusText.text = "select";
//        }
//    }
//}


using TMPro;
using UnityEngine;

public class charButton : MonoBehaviour
{
    [SerializeField] private charData CharData;
    [SerializeField] private TMP_Text statusText;

    private void Start()
    {
        UpdateStatus();
    }

    public void OnClick()
    {
        // If character is already unlocked, select it
        if (charManager.instance.isUnlocked(CharData))
        {
            charManager.instance.SelectCharacter(CharData);
        }
        // Otherwise, try to purchase it
        else
        {
            if (charManager.instance.PurchaseCharacter(CharData))
            {
                charManager.instance.SelectCharacter(CharData);
            }
        }

        // Update all character buttons
        charManager.instance.RefreshButtons();
    }

    public void UpdateStatus()
    {
        // Character is locked
        if (!charManager.instance.isUnlocked(CharData))
        {
            statusText.text = CharData.unlockCost + " C";
            return;
        }

        // Character is currently selected
        if (charManager.instance.GetSelectedCharacter() == CharData.charName)
        {
            statusText.text = "selected";
        }
        else
        {
            statusText.text = "select";
        }
    }
}
