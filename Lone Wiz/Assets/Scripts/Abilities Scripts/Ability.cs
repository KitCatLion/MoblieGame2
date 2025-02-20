using UnityEngine;

public class Ability : MonoBehaviour
{
    private string Name;
    public int DpsLvl { get; set; }
    public int DpsMaxLvl { get; set; }
    public float Dps { get; set; }
    public string NextDps { get; set; }
    public int AmountLvl { get; set; }
    public int AmountMaxLvl { get; set; }
    public float Amount { get; set; }
    public string NextAmount { get; set; }

    /// <summary>
    /// An ability is upgrade by the user after death and evolve in strengh 
    /// the more they are upgraded...
    /// Maybe add range, speed, durabiliy/strength, splash
    /// </summary>
    public Ability(string name)
    {
        Name = name;
        DpsLvl = 1;
        AmountLvl = 1;
    }
}
