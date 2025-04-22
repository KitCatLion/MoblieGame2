using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
//using UnityEngine.Windows;

public class UpgradeSystem : MonoBehaviour
{
    FileStream fs = null;
    StreamWriter sw = null;

    public string UpgradeTxt;
    public string uDirectory;

    public string readFileName;
    public string readDirectory;

    Ability Fireball, IceShard, Lightning; 

    #region Updrage Txt
    void WriteToFile(string file = "")
    {
        print("received message write flat");
        if (file != "")
            UpgradeTxt = file;

        if (!Directory.Exists(uDirectory))
        {
            Directory.CreateDirectory(uDirectory);
            Debug.Log("A folder called " + uDirectory + " has been created.");
        }

        //Problem? Reuse streamwriter?
        /*using(StreamWriter alt_sw = new StreamWriter(new FileStream(sDirectory + @"\Alt_" + sFileName, FileMode.CreateNew)))
  //using(StreamWriter alt_sw = new StreamWriter(sDirectory + @"\Alt_" + sFileName))
  {
      for(int i = 0; i < stat.ScreenItemsName.Length; i++){
          alt_sw.WriteLine(stat.ScreenItemsName[i] + ": " + stat.ScreenItemsValue[i].ToString());
          //alt_sw.WriteLine(transform.position.x.ToString());
          //alt_sw.WriteLine(transform.position.y.ToString());
          //alt_sw.WriteLine(transform.position.z.ToString());
      }
  }
   */


        fs = new FileStream(uDirectory + @"\" + UpgradeTxt, FileMode.Create);

        /*
  if(File.Exists(sDirectory + @"\" + sFileName))
  {
      DeleteFile(sFileName);
  }
  */

        sw = new StreamWriter(fs);


        sw.Flush();
        sw.Close();
    }
    void ReadFile(string ability, int level, string file = "")
    {
        print("Reading Flat");
        if (file != "")
            readFileName = file;


        using (StreamReader sr = new StreamReader(readDirectory + @"\" + readFileName))

        {
            //sr.readline() // read name, >, correct , , close <
            while(sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if(line == ability)
                {
                    
                }
            }
        }

    }
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
    private float score;

    void Start()
    {        
        Fireball = new Ability("Fireball", 1);
        Fireball.dps = fireball_DPS[Fireball.level - 1];
        Fireball.radius = fireball_Radius[Fireball.level - 1];
        Fireball.amount = fireball_Amount[Fireball.level - 1];
        Fireball.speed = fireball_Speed[Fireball.level - 1];

        IceShard = new Ability("Ice Shard", 1);
        IceShard.dps = iceShard_DPS[IceShard.level - 1];
        IceShard.radius = iceShard_Radius[IceShard.level - 1];
        IceShard.amount = iceShard_Amount[IceShard.level - 1];
        IceShard.speed = iceShard_Speed[IceShard.level - 1];

        Lightning = new Ability("Lightning", 1);
        Lightning.dps = lightning_DPS[Lightning.level - 1];
        Lightning.radius = lightning_Radius[Lightning.level - 1];
        Lightning.amount = lightning_Amount[Lightning.level - 1];
        Lightning.speed = lightning_Speed[Lightning.level - 1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //reset temps
        //New_Level = 0;
        //New_Dps = 0;
        //New_Amount = 0;
        //New_Speed = 0;
    }
    public void upgrade_Fireball()
    {
        if (Fireball.level >= 13)
        {
            Debug.Log("Fireball is Maxed out...");
            return;
        }
        if (score >= fireball_UpgradeCost[Fireball.level - 1])
        {
            Fireball.level++;
            score -= fireball_UpgradeCost[Fireball.level - 1];

            Fireball.dps = fireball_DPS[Fireball.level - 1];
            Fireball.radius = fireball_Radius[Fireball.level - 1];
            Fireball.amount = fireball_Amount[Fireball.level - 1];
            Fireball.speed = fireball_Speed[Fireball.level - 1];
        }
        else
        {
            Debug.Log("Not enough Score...");
        }
    }

    public void upgrade_IceShard()
    {
        if (IceShard.level >= 13)
        {
            Debug.Log("Ice Shard is Maxed out...");
            return;
        }
        if (score >= iceShard_UpgradeCost[IceShard.level - 1])
        {
            IceShard.level++;
            score -= iceShard_UpgradeCost[IceShard.level - 1];

            IceShard.dps = iceShard_DPS[IceShard.level - 1];
            IceShard.radius = iceShard_Radius[IceShard.level - 1];
            IceShard.amount = iceShard_Amount[IceShard.level - 1];
            IceShard.speed = iceShard_Speed[IceShard.level - 1];
        }
        else
        {
            Debug.Log("Not enough Score...");
        }
    }

    public void upgrade_Lightning()
    {
        if (Lightning.level >= 13)
        {
            Debug.Log("Lightning is Maxed out...");
            return;
        }
        if (score >= lightning_UpgradeCost[Lightning.level - 1])
        {
            Lightning.level++;
            score -= lightning_UpgradeCost[Lightning.level - 1];

            Lightning.dps = lightning_DPS[Lightning.level - 1];
            Lightning.radius = lightning_Radius[Lightning.level - 1];
            Lightning.amount = lightning_Amount[Lightning.level - 1];
            Lightning.speed = lightning_Speed[Lightning.level - 1];
        }
        else
        {
            Debug.Log("Not enough Score...");
        }
    }
}
