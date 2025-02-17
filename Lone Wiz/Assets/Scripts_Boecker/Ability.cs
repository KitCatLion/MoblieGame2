using UnityEngine;

public class Ability : MonoBehaviour
{
    private string Name;
    private float Level, Dps, Range, Amount, Speed;

    /// <summary>
    /// An ability is upgrade by the user after death and evolve in strengh 
    /// the more they are upgraded...
    /// Maybe add range, speed, durabiliy/strength, splash
    /// </summary>
    public Ability(string name, int level)
    {
        Name = name;
        Level = level;
        //Dps = dps;
        //Range = range;
        //ProjectileNum = projectileNum;
        //Speed = speed;
    }

    //get/set name, lvl, dps, range, projectile#, speed...
    public int level
    {
        get { return level; }
        set { level = value; }
    }

    public float dps
    {
        get { return dps; }
        set { dps = value; }
    }

    public float amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public float speed
    {
        get { return speed; }
        set { speed = value; }
    }

}
