using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
//using UnityEngine.Windows;

public class UpgradeSystem : MonoBehaviour
{
    //FileStream fs = null;
    //StreamWriter sw = null;

    //public string UpgradeTxt;
    //public string uDirectory;

    //public string readFileName;
    //public string readDirectory;

    

    #region Updrage Txtfile
  //  void WriteToFile(string file = "")
  //  {
  //      print("received message write flat");
  //      if (file != "")
  //          UpgradeTxt = file;

  //      if (!Directory.Exists(uDirectory))
  //      {
  //          Directory.CreateDirectory(uDirectory);
  //          Debug.Log("A folder called " + uDirectory + " has been created.");
  //      }

  //      //Problem? Reuse streamwriter?
  //      /*using(StreamWriter alt_sw = new StreamWriter(new FileStream(sDirectory + @"\Alt_" + sFileName, FileMode.CreateNew)))
  ////using(StreamWriter alt_sw = new StreamWriter(sDirectory + @"\Alt_" + sFileName))
  //{
  //    for(int i = 0; i < stat.ScreenItemsName.Length; i++){
  //        alt_sw.WriteLine(stat.ScreenItemsName[i] + ": " + stat.ScreenItemsValue[i].ToString());
  //        //alt_sw.WriteLine(transform.position.x.ToString());
  //        //alt_sw.WriteLine(transform.position.y.ToString());
  //        //alt_sw.WriteLine(transform.position.z.ToString());
  //    }
  //}
  // */


  //      fs = new FileStream(uDirectory + @"\" + UpgradeTxt, FileMode.Create);

  //      /*
  //if(File.Exists(sDirectory + @"\" + sFileName))
  //{
  //    DeleteFile(sFileName);
  //}
  //*/

  //      sw = new StreamWriter(fs);


  //      sw.Flush();
  //      sw.Close();
  //  }
  //  void ReadFile(string ability, int level, string file = "")
  //  {
  //      print("Reading Flat");
  //      if (file != "")
  //          readFileName = file;


  //      using (StreamReader sr = new StreamReader(readDirectory + @"\" + readFileName))

  //      {
  //          //sr.readline() // read name, >, correct , , close <
  //          while(sr.EndOfStream)
  //          {
  //              string line = sr.ReadLine();
  //              if(line == ability)
  //              {
                    
  //              }
  //          }
  //      }

  //  }
    #endregion

    #region Upgrades
    //int fireball_Level = 1;       //1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
    float[] fireball_UpgradeCost =   {20,50,100,130,160,300,320,360,450,550,600,700,800};
    float[] fireball_DPS =       { 1, 2, 2, 2, 2, 2, 3, 3, 3,  4,  4,  4,  5};
    float[] fireball_Radius =    { 0.5f, 0.5f, 1f, 1f, 1f, 1f, 1.5f, 1.5f, 1.5f, 1.5f, 2f, 2f, 2f};
    float[] fireball_Amount =    { 1, 1, 1, 1, 2, 2, 2, 3, 3,  3,  4,  4,  4};
    float[] fireball_Speed =     { 1, 1, 2, 2, 2, 2, 3, 3, 3,  3,  4,  4,  4};

    //int iceShard_Level = 1;       //1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
    int[] iceShard_UpgradeCost =   { 20, 50, 100, 130, 160, 300, 320, 360, 450, 550, 600, 700, 800 };
    float[] iceShard_DPS =       { 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 };
    float[] iceShard_Radius =    { 0.5f, 0.5f, 1f, 1f, 1f, 1f, 1.5f, 1.5f, 1.5f, 1.5f, 2f, 2f, 2f };
    float[] iceShard_Amount =    { 2, 2, 2, 4, 4, 4, 4, 4, 6, 6, 6, 6, 8 };
    float[] iceShard_Speed =     { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4 };

    //int lightning_Level = 1;      //1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
    int[] lightning_UpgradeCost =  { 20, 50, 100, 130, 160, 300, 320, 360, 450, 550, 600, 700, 800 };
    float[] lightning_DPS =      { 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 };
    float[] lightning_Radius =   { 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 8, 10 };
    float[] lightning_Amount =   { 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 }; //Change later
    float[] lightning_Speed =    { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4 }; //Change later
    #endregion

    //int New_Level;
    //float New_Dps, New_Amount, New_Speed;
    [SerializeField]
    private float score;

    List <Ability> abilities;
    List<TextMeshProUGUI> Stats;

    Ability Fire, Fira, Firaga, Blizzard, Blizzara, Blizzaga,
        Thunder, Thundara, Thundaga, Shield;

    public TextMeshProUGUI fire_t, fira_t, firaga_t, blizzard_t, blizzara_t, blizzaga_t,
        thunder_t, thundara_t, thundaga_t, shield_t;

    void upgradeAbility(string buttonName)
    {
        string[] temp = buttonName.Split("_");
        string name = temp[0];
        string upgrade = temp[1];
        foreach(Ability ability in abilities)
        {
            if (ability.name == name)
            {
                if(upgrade.ToLower() == "dps")
                {
                    ability.DpsLvl++;
                }
                else if(upgrade.ToLower() == "amount")
                {
                    ability.AmountLvl++;
                }
                return;
            }
        }        
    }

    int[] cost = { 100, 200, 300 };

    float[] fire_Dps = { 1f, 2f, 3f };
    float[] fire_Amount = { 1f, 2f, 3f };

    float[] fira_Dps = { 2f, 4f, 6f };
    float[] fira_Amount = { 2f, 4f, 6f };

    float[] firaga_Dps = { 3f, 6f, 9f };
    float[] firaga_Amount = { 3f, 6f, 9f };

    public void updateAbilities()
    {
        foreach(Ability ability in abilities)
        {
            switch (ability.name)
            {
                case "Fire":
                    ability.DpsMaxLvl = fire_Dps.Length;
                    ability.Dps = fire_Dps[ability.DpsLvl - 1];
                    if (ability.DpsLvl == ability.DpsMaxLvl)
                        ability.NextDps = fire_Dps[ability.DpsLvl].ToString();
                    else ability.NextDps = "MAXED";
                    ability.Amount = fire_Amount[ability.AmountLvl - 1];
                    if (ability.AmountLvl == ability.AmountMaxLvl)
                        ability.NextAmount = fire_Amount[ability.AmountLvl].ToString();
                    else ability.NextAmount = "MAXED";
                    break;
                case "Fira":
                    ability.DpsMaxLvl = fira_Dps.Length; //change
                    ability.Dps = fira_Dps[ability.DpsLvl - 1]; //change
                    if (ability.DpsLvl == ability.DpsMaxLvl)
                        ability.NextDps = fira_Dps[ability.DpsLvl].ToString(); //change
                    else ability.NextDps = "MAXED";
                    ability.Amount = fira_Amount[ability.AmountLvl - 1]; //change
                    if (ability.AmountLvl == ability.AmountMaxLvl)
                        ability.NextAmount = fira_Amount[ability.AmountLvl].ToString(); //change
                    else ability.NextAmount = "MAXED";
                    break;
                case "Firaga":
                    ability.DpsMaxLvl = firaga_Dps.Length; //change
                    ability.Dps = firaga_Dps[ability.DpsLvl - 1]; //change
                    if (ability.DpsLvl == ability.DpsMaxLvl)
                        ability.NextDps = firaga_Dps[ability.DpsLvl].ToString(); //change
                    else ability.NextDps = "MAXED";
                    ability.Amount = firaga_Amount[ability.AmountLvl - 1]; //change
                    if (ability.AmountLvl == ability.AmountMaxLvl)
                        ability.NextAmount = firaga_Amount[ability.AmountLvl].ToString(); //change
                    else ability.NextAmount = "MAXED";
                    break;
            }

        }
    }

    public void updateText() 
    {
        foreach (TextMeshProUGUI statTxt in Stats)
        {
            string[] text = statTxt.text.Split('\n');
            string name = text[0];
            foreach (Ability ability in abilities)
            {
                if (ability.name == name)
                {
                    string dps = "DPS: " + ability.Dps;
                    string nextDps = "Next Lvl: " + ability.NextDps;
                    string amount = "Amount: " + ability.Amount;
                    string nextAmount = "Next Lvl: " + ability.NextAmount;
                    statTxt.text = name + '\n' + dps + '\n' + nextDps 
                        + '\n' + amount + '\n' + nextAmount;
                    break;
                }
            }
        }
    }
    private void Start()
    {
        Fire = new Ability("Fire");
        Fira = new Ability("Fira");
        Firaga = new Ability("Firaga");
        //Blizzard = new Ability("Blizzard");
        //Blizzara = new Ability("Blizzara");
        //Blizzaga = new Ability("Blizzaga");
        //Thunder = new Ability("Thunder");
        //Thundara = new Ability("Thundara");
        //Thundaga = new Ability("Thundaga");

        abilities.Add(Fire);
        abilities.Add(Fira);
        abilities.Add(Firaga);
        //abilities.Add(Blizzard);
        //abilities.Add(Blizzara);
        //abilities.Add(Blizzaga); 
        //abilities.Add(Thunder);
        //abilities.Add(Thundara); 
        //abilities.Add(Thundaga);

        Stats.Add(fire_t);
        Stats.Add(fira_t);
        Stats.Add(firaga_t);
        //Stats.Add(blizzard_t);
        //Stats.Add(blizzara_t);
        //Stats.Add(blizzaga_t);
        //Stats.Add(thunder_t);
        //Stats.Add(thundara_t);
        //Stats.Add(thundaga_t);
    }

    #region ButtonUI
    public void upFire_button()
    {

    }
    #endregion



    //void Start()
    //{        
    //    //Fireball = new Ability("Fireball", 1);
    //    //Fireball.dps = fireball_DPS[Fireball.level - 1];
    //    //Fireball.radius = fireball_Radius[Fireball.level - 1];
    //    //Fireball.amount = fireball_Amount[Fireball.level - 1];
    //    //Fireball.speed = fireball_Speed[Fireball.level - 1];

    //    //IceShard = new Ability("Ice Shard", 1);
    //    //IceShard.dps = iceShard_DPS[IceShard.level - 1];
    //    //IceShard.radius = iceShard_Radius[IceShard.level - 1];
    //    //IceShard.amount = iceShard_Amount[IceShard.level - 1];
    //    //IceShard.speed = iceShard_Speed[IceShard.level - 1];

    //    //Lightning = new Ability("Lightning", 1);
    //    //Lightning.dps = lightning_DPS[Lightning.level - 1];
    //    //Lightning.radius = lightning_Radius[Lightning.level - 1];
    //    //Lightning.amount = lightning_Amount[Lightning.level - 1];
    //    //Lightning.speed = lightning_Speed[Lightning.level - 1];
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        //reset temps
        //New_Level = 0;
        //New_Dps = 0;
        //New_Amount = 0;
        //New_Speed = 0;
    }
    //public void upgrade_Fireball()
    //{
    //    if (Fireball.level >= 13)
    //    {
    //        Debug.Log("Fireball is Maxed out...");
    //        return;
    //    }
    //    if (score >= fireball_UpgradeCost[Fireball.level - 1])
    //    {
    //        Fireball.level++;
    //        score -= fireball_UpgradeCost[Fireball.level - 1];

    //        Fireball.dps = fireball_DPS[Fireball.level - 1];
    //        Fireball.radius = fireball_Radius[Fireball.level - 1];
    //        Fireball.amount = fireball_Amount[Fireball.level - 1];
    //        Fireball.speed = fireball_Speed[Fireball.level - 1];
    //    }
    //    else
    //    {
    //        Debug.Log("Not enough Score...");
    //    }
    //}

    //public void upgrade_IceShard()
    //{
    //    if (IceShard.level >= 13)
    //    {
    //        Debug.Log("Ice Shard is Maxed out...");
    //        return;
    //    }
    //    if (score >= iceShard_UpgradeCost[IceShard.level - 1])
    //    {
    //        IceShard.level++;
    //        score -= iceShard_UpgradeCost[IceShard.level - 1];

    //        IceShard.dps = iceShard_DPS[IceShard.level - 1];
    //        IceShard.radius = iceShard_Radius[IceShard.level - 1];
    //        IceShard.amount = iceShard_Amount[IceShard.level - 1];
    //        IceShard.speed = iceShard_Speed[IceShard.level - 1];
    //    }
    //    else
    //    {
    //        Debug.Log("Not enough Score...");
    //    }
    //}

    //public void upgrade_Lightning()
    //{
    //    if (Lightning.level >= 13)
    //    {
    //        Debug.Log("Lightning is Maxed out...");
    //        return;
    //    }
    //    if (score >= lightning_UpgradeCost[Lightning.level - 1])
    //    {
    //        Lightning.level++;
    //        score -= lightning_UpgradeCost[Lightning.level - 1];

    //        Lightning.dps = lightning_DPS[Lightning.level - 1];
    //        Lightning.radius = lightning_Radius[Lightning.level - 1];
    //        Lightning.amount = lightning_Amount[Lightning.level - 1];
    //        Lightning.speed = lightning_Speed[Lightning.level - 1];
    //    }
    //    else
    //    {
    //        Debug.Log("Not enough Score...");
    //    }
    //}
}
