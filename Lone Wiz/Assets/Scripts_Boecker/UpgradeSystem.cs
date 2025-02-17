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
            //sr.readline()

        }

    }
    #endregion
    #region Upgrades
    float[] fireDPS = { 1, 2, 3 };
    float[] iceDPS = { 1, 2, 3 };
    float[] lightingDPS = { 1, 2, 3 };
    #endregion

    int New_Level;
    float New_Dps, New_Amount, New_Speed;
    void Start()
    {        
        Fireball = new Ability("Fireball", 0);//Example
        upgrade_Fire();

        IceShard = new Ability("Ice Shard", 0);
        upgrade_Ice();

        Lightning = new Ability("Lightning", 0);
        upgrade_Lightning();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //reset temps
        New_Level = 0;
        New_Dps = 0;
        New_Amount = 0;
        New_Speed = 0;
    }

    public void upgrade_Fire()  //use buttons
    {
        int level = Fireball.level++;
        ReadFile("Fireball", level, readFileName);
        Fireball.level = New_Level;
        Fireball.dps = New_Dps;
        Fireball.amount = New_Amount;
        Fireball.speed = New_Speed;
    }
    public void upgrade_Ice()
    {
        int level = IceShard.level++;
        ReadFile("Ice Shard", level, readFileName);
        IceShard.level = New_Level;
        IceShard.dps = New_Dps;
        IceShard.amount = New_Amount;
        IceShard.speed = New_Speed;
    }
    public void upgrade_Lightning()
    {
        int level = Lightning.level++;
        ReadFile("Lightning", level, readFileName);
        Lightning.level = New_Level;
        Lightning.dps = New_Dps;
        Lightning.amount = New_Amount;
        Lightning.speed = New_Speed;
    }
}
