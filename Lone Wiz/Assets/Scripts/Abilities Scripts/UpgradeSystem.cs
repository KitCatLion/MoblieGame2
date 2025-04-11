using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.Windows;

public class UpgradeSystem : MonoBehaviour
{
    public int score;

    int wave = 1;
    public string option1, option2, option3;
    public UpgradeUI_Txt UI;

    #region Abilities
    Ability Fireball = new Ability();
    Ability IceShard = new Ability();
    Ability Lightning = new Ability();
    //Ability Shield = new Ability();
    #endregion
    List<Upgrade> upgrades = new List<Upgrade>();
    List<Upgrade> upgradeChoices = new List<Upgrade>();
    private void Awake()
    {
        resetUpgrades();
        Debug.Log("Total Upgrades: " + upgrades.Count);
    }
    private void resetUpgrades()
    {
        upgrades.Clear();
        upgradeChoices.Clear();

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
        Upgrade l_a1 = new Upgrade("Lightning", "amount", 150, 400);
        Upgrade l_a2 = new Upgrade("Lightning", "amount", 100, 800);
        //ice speed
        Upgrade l_s1 = new Upgrade("Lightning", "speed", 1.5f, 200);
        Upgrade l_s2 = new Upgrade("Lightning", "speed", 1, 700);

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
        upgrades.Add(l_s1);
        upgrades.Add(l_s2);

        //Add all upgrades to list
    }
    public void upgradePanel()
    {
        /*
         * Before open upgrade UI, run this method to update and set all UI elements
         */

        newUpgradeSelection(); //select upgrade options


    }
    public void newUpgradeSelection()
    {
        /*
         * Takes remaining upgrades and the player's score to seperate which upgrades the player can afford...
         * Then randomly selects 3 from the upgrades remaining to present to the player...
         */

        List<Upgrade> canAfford = new List<Upgrade>();
        Debug.Log("Upgrades Left: " + upgrades.Count);
        foreach (Upgrade upgrade in upgrades)
        {
            if (upgrade.Cost <= score) //&& upgrade.Cost > score - 400 //Shouldn't need as the player will need to upgrade as game progresses or they will lose, shouldn't be saving up score.
            {
                canAfford.Add(upgrade);
            }
        }
        Debug.Log("Wave " + wave + " | Amount of Avaliable Upgrades: " + canAfford.Count + " | Score: " + score);
        if (canAfford.Count > 0) //must be able to afford one upgrade to show anything...
        {
            int maxChoices = 3;
            string[] choiceTxt = new string[maxChoices+1]; // +1 so code doesn't flake out for some reason
            for (int i = 0; i < maxChoices; i++)
            {
                int r;
                if (canAfford.Count > 3)
                    r = Random.Range(0, canAfford.Count);
                else if(canAfford.Count == 0)
                {
                    break;
                }
                else r = canAfford.Count-1;

                Upgrade temp = canAfford[r];
                string tempStr = i+1 + ") " + temp.AbilityName + " " + temp.Cost.ToString();

                choiceTxt[i] = tempStr;

                upgradeChoices.Add(temp);
                
                canAfford.RemoveAt(r);
            }
            
            
            Debug.Log("Wave " + wave + " | " + choiceTxt[0] + " | " + choiceTxt[1] + " | " + choiceTxt[2] + " |");

            setUpgradeUI(choiceTxt);
        }
        else
        {
            Debug.Log("Wave " + wave + " | " + "Cannot Afford Any Upgrades...");
        }
        wave++;
        UI.updateOptionTxt();
    }
    public void setUpgradeUI(string[] str) 
    {
        //Effects UI
        option1 = null; option2 = null; option3 = null;
        if (!string.IsNullOrEmpty(str[0])) 
        {
            option1 = str[0];
        }
        if (!string.IsNullOrEmpty(str[1]))
        {
            option2 = str[1];
        }
        if (!string.IsNullOrEmpty(str[2]))
        {
            option3 = str[2];
        }
    }
    public void selectInput(string str)
    {
        //In responce to UI buttons when selected
        Upgrade selected;
        switch (str)
        {
            case "1":
                selected = upgradeChoices[0];
                removeFromList(selected);
                removeLesserElements(selected);
                updateAbility(selected);
                score -= selected.Cost;
                break;
            case "2":
                selected = upgradeChoices[1];
                removeFromList(selected);
                removeLesserElements(selected);
                updateAbility(selected);
                score -= selected.Cost;
                break; 
            case "3":
                selected = upgradeChoices[2];
                removeFromList(selected);
                removeLesserElements(selected);
                updateAbility(selected);
                score -= selected.Cost;
                break;
        }
        
    }
    public void removeFromList(Upgrade selected)
    {
        //Match selected ID to remove from main list of upgrades...
        int c = 0;
        foreach(Upgrade upgrade in upgrades)
        {
            if (upgrade.ID == selected.ID)
            {
                //Debug.Log(upgrade.ID + "|" + selected.ID);
                
                Debug.Log("Removing|" + upgrade.displayAll());
                clearUI();
                upgrades.RemoveAt(c);
                upgradeChoices.Clear();
                return;
            }
            c++;
        }
    }
    public void removeLesserElements(Upgrade selected)
    {
        List<Upgrade> deleteList = new List<Upgrade>();
        foreach(Upgrade upgrade in upgrades)
        {
            if(upgrade.AbilityName == selected.AbilityName)
            {
                if (upgrade.UpgradeType == selected.UpgradeType)
                {
                    if(upgrade.Change < selected.Change)
                    {
                        deleteList.Add(upgrade);
                    }
                }
            }
                
        }
        foreach(Upgrade upgrade in deleteList)
        {
            removeFromList(upgrade);
        }
    }
    public void clearUI()
        {
            option1 = null;
            option2 = null;
            option3 = null;

            upgradeChoices.Clear();
            UI.updateOptionTxt();
        }
    public void dislpayUpgList()
    {
        //button UI to display all upgrades left...
        foreach(Upgrade upgrade in upgrades)
            Debug.Log(upgrade.displayAll());
    }
    public void updateAbility(Upgrade selected)
    {
        switch(selected.AbilityName)
        {
            case "Fireball":
                switch (selected.UpgradeType)
                {
                    case "dps":
                        Fireball.Dps = (int)selected.Change;
                        return;
                    case "amount":
                        Fireball.Amount = (int)selected.Change;
                        return;
                    case "speed":
                        Fireball.Speed = selected.Change;
                        return;
                }
                break;
            case "IceShard":
                switch (selected.UpgradeType)
                {
                    case "dps":
                        IceShard.Dps = (int)selected.Change;
                        return;
                    case "amount":
                        IceShard.Amount = (int)selected.Change;
                        return;
                    case "speed":
                        IceShard.Speed = selected.Change;
                        return;
                }
                break;
            case "Lightning":
                switch (selected.UpgradeType)
                {
                    case "dps":
                        Lightning.Dps = (int)selected.Change;
                        return;
                    case "amount":
                        Lightning.Amount = (int)selected.Change;
                        return;
                    case "speed":
                        Lightning.Speed = selected.Change;
                        return;
                }
                break;
        }
    }
        /*
         * ----Notes-----
         * Button UI includes: selection of upgrade for each button, button txt has to be ablt to change
         * What I need: Methods that can return upgrade name and txt....
         */
    }
