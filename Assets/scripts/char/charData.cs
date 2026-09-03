using UnityEngine;

[CreateAssetMenu(fileName = "charData", menuName = "Game/charData")]
public class charData : ScriptableObject
{
   
    public string charName;
    public GameObject charPrefab;
    public int unlockCost;

}
