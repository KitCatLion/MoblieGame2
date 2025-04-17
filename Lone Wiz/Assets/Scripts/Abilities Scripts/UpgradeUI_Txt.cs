using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI_Txt : MonoBehaviour
{
    public TextMeshProUGUI Option1, Option2, Option3;

    public Image Card1, Card2, Card3;

    //public Sprite sFire, mFire, lFire, sIceShard, mIceShard, lIceShard, sLightning, mLightning, lLightning;
    public Sprite[] UpgradeImages;

    public UpgradeSystem UpgradeUI;

    public string upgradeRemoved;
    public TextMeshProUGUI removedTxt;
    public GameObject GO_removedText;

    [SerializeField]
    private float timer = 0;


    private void Start()
    {
        updateOptionTxt();
        removedTxt.text = "";

    }

    private void Update()
    {
        removedTxt.text = upgradeRemoved;
        if(timer > 0)
        {
            GO_removedText.SetActive(true);
            timer -= Time.deltaTime;
            return;
        }
        removedTxt.text = "";
        GO_removedText.SetActive(false);
    }
    public void updateOptionTxt()
    {
        Option1.text = UpgradeUI.option1;
        if (UpgradeUI.option1 != null)
        {
            updateImage(1, UpgradeUI.option1);
        }
        else Card1 = null;

        Option2.text = UpgradeUI.option2;
        //if (UpgradeUI.option1 != null)
        //{
        //    updateImage(2, UpgradeUI.option2);
        //}
        //else Card1 = null;

        Option3.text = UpgradeUI.option3;
        //if (UpgradeUI.option1 != null)
        //{
        //    updateImage(3, UpgradeUI.option3);
        //}
        //else Card1 = null;
    }

    bool existingOptions(TextMeshProUGUI txt)
    {
        if (!string.IsNullOrEmpty(txt.text))
        {
            return true;
        }
        return false;
    }

    public void updateImage(int option, string str)
    {
        
        
        string name, editedCost;
        int cost = 0;
        string[] arr = str.Split('\n');
        name = arr[0];
        
        //cost = int.Parse(arr[2]);
        

        Sprite[] tempSprites = new Sprite[3];
        switch (name)
        {
            case "Fireball":
                tempSprites[0] = UpgradeImages[0]; //small
                tempSprites[1] = UpgradeImages[1]; //medium
                tempSprites[2] = UpgradeImages[2]; //large
                break;
            case "Ice Shard":
                tempSprites[0] = UpgradeImages[3];
                tempSprites[1] = UpgradeImages[4];
                tempSprites[2] = UpgradeImages[5];
                break;
            case "Lightning":
                tempSprites[0] = UpgradeImages[6];
                tempSprites[1] = UpgradeImages[7];
                tempSprites[2] = UpgradeImages[8];
                break;
        }

        Sprite sprite;
        if (cost > 1500)
        {
            sprite = tempSprites[2];
        }
        else if(cost > 700)
        {
            sprite = tempSprites[1];
        }
        else sprite = tempSprites[0];

        switch(option)
        {
            case 1: 
                Card1.sprite = sprite;
                break;
            case 2:
                Card2.sprite = sprite;
                break;
            case 3:
                Card3.sprite = sprite;
                break;
        }
    }

    public void option1()
    {
        if (!existingOptions(Option1))
        {
            Debug.Log("Nothing there...");
            return;
        }
        UpgradeUI.selectInput("1");
        timer = 5;
    }
    public void option2()
    {
        if (!existingOptions(Option2))
        {
            Debug.Log("Nothing there...");
            return;
        }
        UpgradeUI.selectInput("2");
        timer = 5;
    }
    public void option3()
    {
        if (!existingOptions(Option3))
        {
            Debug.Log("Nothing there..."); //fix
            return;
        }
        UpgradeUI.selectInput("3");
        timer = 5;
    }
}
