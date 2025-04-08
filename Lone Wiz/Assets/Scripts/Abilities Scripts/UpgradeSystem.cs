using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.Windows;

public class UpgradeSystem : MonoBehaviour
{
    public int score = 0;

    int x = 1;

    #region Abilities
    Ability Fireball = new Ability();
    Ability IceShard = new Ability();
    Ability Lightning = new Ability();
    Ability Shield = new Ability();
    #endregion
    List<Upgrade> upgrades = new List<Upgrade>();
    #region Upgrades
    //fire dps
    Upgrade f_d1 = new Upgrade("Fireball", "dps", 2, 200);
    Upgrade f_d2 = new Upgrade("Fireball", "dps", 3, 500);
    Upgrade f_d3 = new Upgrade("Fireball", "dps", 4, 900);
    Upgrade f_d4 = new Upgrade("Fireball", "dps", 5, 1300);
    Upgrade f_d5 = new Upgrade("Fireball", "dps", 6, 1700);
    //fire amount
    Upgrade f_a1 = new Upgrade("Fireball", "amount", 2, 500);
    Upgrade f_a2 = new Upgrade("Fireball", "amount", 3, 1000);
    Upgrade f_a3 = new Upgrade("Fireball", "amount", 4, 1500);
    Upgrade f_a4 = new Upgrade("Fireball", "amount", 5, 2000);
    //fire speed
    Upgrade f_s1 = new Upgrade("Fireball", "speed", 2, 200);
    Upgrade f_s2 = new Upgrade("Fireball", "speed", 3, 700);
    Upgrade f_s3 = new Upgrade("Fireball", "speed", 4, 1200);

    //ice dps
    Upgrade i_d1 = new Upgrade("IceShard", "dps", 2, 300);
    Upgrade i_d2 = new Upgrade("IceShard", "dps", 3, 700);
    Upgrade i_d3 = new Upgrade("IceShard", "dps", 4, 1300);
    Upgrade i_d4 = new Upgrade("IceShard", "dps", 5, 1700);
    Upgrade i_d5 = new Upgrade("IceShard", "dps", 6, 2100);
    //ice amount
    Upgrade i_a1 = new Upgrade("IceShard", "amount", 4, 400);
    Upgrade i_a2 = new Upgrade("IceShard", "amount", 6, 800);
    Upgrade i_a3 = new Upgrade("IceShard", "amount", 8, 1400);
    //ice speed
    Upgrade i_s1 = new Upgrade("IceShard", "speed", 2, 200);
    Upgrade i_s2 = new Upgrade("IceShard", "speed", 3, 700);
    Upgrade i_s3 = new Upgrade("IceShard", "speed", 4, 1200);

    //light dps
    Upgrade l_d1 = new Upgrade("Lightning", "dps", 2, 300);
    Upgrade l_d2 = new Upgrade("Lightning", "dps", 3, 700);
    Upgrade l_d3 = new Upgrade("Lightning", "dps", 4, 1300);
    Upgrade l_d4 = new Upgrade("Lightning", "dps", 5, 1700);
    Upgrade l_d5 = new Upgrade("Lightning", "dps", 6, 2100);
    //light amount
    Upgrade l_a1 = new Upgrade("Lightning", "amount", 2, 400);
    Upgrade l_a2 = new Upgrade("Lightning", "amount", 3, 800);
    Upgrade l_a3 = new Upgrade("Lightning", "amount", 4, 1400);
    //ice speed
    Upgrade l_s1 = new Upgrade("Lightning", "speed", 2, 200);
    Upgrade l_s2 = new Upgrade("Lightning", "speed", 3, 700);
    Upgrade l_s3 = new Upgrade("Lightning", "speed", 4, 1200);
    #endregion
    private void Start()
    {
        upgrades.Add(f_d1);
        upgrades.Add(f_d2);
        upgrades.Add(f_d3);
        upgrades.Add(f_d4);
        upgrades.Add(f_d5);
        upgrades.Add(f_a1);
        upgrades.Add(f_a2);
        upgrades.Add(f_a3);
        upgrades.Add(f_a4);
        upgrades.Add(f_s1);
        upgrades.Add(f_s2);
        upgrades.Add(f_s3);

        upgrades.Add(i_d1);
        upgrades.Add(i_d2);
        upgrades.Add(i_d3);
        upgrades.Add(i_d4);
        upgrades.Add(i_d5);
        upgrades.Add(i_a1);
        upgrades.Add(i_a2);
        upgrades.Add(i_a3);
        upgrades.Add(i_s1);
        upgrades.Add(i_s2);
        upgrades.Add(i_s3);

        upgrades.Add(l_d1);
        upgrades.Add(l_d2);
        upgrades.Add(l_d3);
        upgrades.Add(l_d4);
        upgrades.Add(l_d5);
        upgrades.Add(l_a1);
        upgrades.Add(l_a2);
        upgrades.Add(l_a3);
        upgrades.Add(l_s1);
        upgrades.Add(l_s2);
        upgrades.Add(l_s3);
        //Add all upgrades to list
    }

    public void upgradeSelection()
    {
        List<Upgrade> canAfford = new List<Upgrade>();
        foreach(Upgrade upgrade in upgrades)
        {
            if(upgrade.Cost < score && upgrade.Cost > score - 300)
            {
                canAfford.Add(upgrade);
            }
        }


        string finalStr = "Upgrade Options: " + x + " |";
        for (int i = 0; i < 3; i++)
        {
            string s = "|";
            foreach(Upgrade upgrade in canAfford)
            {
                s += upgrade.AbilityName + ", " + upgrade.UpgradeType + "->" +  upgrade.Change + ": " + upgrade.Cost.ToString() + "|";
            }
            Debug.Log(x + s);

            int r = Random.Range(0, canAfford.Count);
            Upgrade temp = canAfford[r];
            string tempStr = temp.AbilityName + ": " + temp.Cost.ToString() + "|" ;
            Debug.Log(x + "|" + temp.AbilityName + ", " + temp.UpgradeType + ": " + temp.Cost.ToString());
            finalStr += tempStr;
            canAfford.RemoveAt(r);
        }

        Debug.Log(finalStr);
        x++;

        
        //Check if any values in canAfford list, and the random roll aspect. 
        //Debug.Log(canAfford.ToArray().Length);
        //int r = Random.Range(1, canAfford.Count);
        //Upgrade temp = canAfford[r];
        //Debug.Log(temp.AbilityName + ": " + temp.Cost.ToString());
        
    }
}
