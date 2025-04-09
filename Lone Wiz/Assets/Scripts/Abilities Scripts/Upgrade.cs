using UnityEngine;

public class Upgrade : MonoBehaviour
{
    /*
    /Add incrementing node to find upgrade in list...
    */
    static int counter = 0;
    public int ID { get; set; }
    public string AbilityName { get; set; }
    public string UpgradeType { get; set; }
    public float Change { get; set; }
    public int Cost { get; set; }
    public Upgrade(string name, string type, float change, int cost)
    {
        ID = counter;
        AbilityName = name;
        UpgradeType = type;
        Change = change;
        Cost = cost;

        counter++;
    }

    public string displayAll()
    {
        return "ID: " +ID + "|Ability: " + AbilityName + "\n|Upgrade: " + UpgradeType + "|Increase to: " + Change + "|Cost:" + Cost;
    }
}
