using TMPro;
using UnityEngine;

public class UpgradeUI_Txt : MonoBehaviour
{
    public TextMeshProUGUI Option1, Option2, Option3;

    public UpgradeSystem UpgradeUI;

    private void Start()
    {
        updateOptionTxt();
    }
    public void updateOptionTxt()
    {
        Option1.text = UpgradeUI.option1;
        Option2.text = UpgradeUI.option2;
        Option3.text = UpgradeUI.option3;
    }

    bool existingOptions()
    {
        if (!string.IsNullOrEmpty(Option1.text))
        {
            return true;
        }
        return false;
    }

    public void option1()
    {
        if (!existingOptions())
        {
            Debug.Log("Nothing there...");
            return;
        }
            
        UpgradeUI.selectInput("1");
    }
    public void option2()
    {
        if (!existingOptions())
        {
            Debug.Log("Nothing there...");
            return;
        }
        UpgradeUI.selectInput("2");
    }
    public void option3()
    {
        if (!existingOptions())
        {
            Debug.Log("Nothing there...");
            return;
        }
        UpgradeUI.selectInput("3");
    }
}
