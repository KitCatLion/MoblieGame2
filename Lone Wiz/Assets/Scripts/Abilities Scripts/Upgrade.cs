using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string AbilityName { get; set; }
    public string UpgradeType { get; set; }
    public int Change { get; set; }
    public int Cost { get; set; }
    public Upgrade(string name, string type, int change, int cost)
    {
        AbilityName = name;
        UpgradeType = type;
        Change = change;
        Cost = cost;
    }
}
