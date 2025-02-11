using System;
using System.IO;
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

    Ability A1, A2, A3, A4;

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
    void ReadFile(string file = "")
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
    void Start()
    {
        UpgradeTxt = "Ability_Txt";
        
        A1 = new Ability("Fire Ball", 1); //Example
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
