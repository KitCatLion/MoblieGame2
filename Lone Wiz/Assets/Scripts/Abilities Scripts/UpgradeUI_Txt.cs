using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI_Txt : MonoBehaviour
{
    public TextMeshProUGUI Option1, Option2, Option3;

    public Image Card1, Card2, Card3;

    //public Sprite sFire, mFire, lFire, sIceShard, mIceShard, lIceShard, sLightning, mLightning, lLightning;
    //public List<Sprite> UpgradeImages;

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
        Option2.text = UpgradeUI.option2;
        Option3.text = UpgradeUI.option3;
    }

    bool existingOptions(TextMeshProUGUI txt)
    {
        if (!string.IsNullOrEmpty(txt.text))
        {
            return true;
        }
        return false;
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
