using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class Sheild : MonoBehaviour
{
    public GameObject player;
    public int active;
    public int tapAmount;
    public int coolDown;
    Touch touch;
    public int time;
    public int coolTime;
    bool on;
    private void Start()
    {
        on = false;
        time= 0;
        tapAmount = 2;
        active = 5;
        coolDown = 15;
        coolTime = coolDown;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (touch.tapCount == tapAmount && coolTime <= 0)
        {
            touch = Input.GetTouch(0);
            on = true;
            gameObject.SetActive(true);
        }
    }
    public void Count()
    {
        if (on == true)
        {
            ++time;
            coolTime = coolDown;
        }
        else
        {
            --coolTime;
        }
        if (time == active)
        {
            on = false;
            gameObject.SetActive(false);
            time = 0;
        }
    }

}
