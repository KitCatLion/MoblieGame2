using UnityEngine;

public class Ability : MonoBehaviour
{
    public int Dps { get; set; }
    public int Amount { get; set; }
    public int Speed { get; set; }

    /// <summary>
    /// An ability is upgrade by the user after death and evolve in strengh 
    /// the more they are upgraded...
    /// Maybe add range, speed, durabiliy/strength, splash
    /// </summary>
    public Ability()
    {
        Dps = 1;
        Amount = 1;
        Speed = 1;
    }

}
