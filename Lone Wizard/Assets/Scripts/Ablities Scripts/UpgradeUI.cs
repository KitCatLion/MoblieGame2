using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject upgradeUI;
    void Start()
    {
        //upgradeUI.SetActive(false);
    }
    public void open()
    {
        upgradeUI.SetActive(true);
    }
    public void close()
    {
        upgradeUI.SetActive(false);
    }
}
