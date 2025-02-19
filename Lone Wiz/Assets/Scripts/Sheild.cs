using UnityEngine;

public class Sheild : MonoBehaviour
{
    public GameObject player;
    public int tapAmount;
    public Touch touch;
    public int active;
    public int coolDown;
    int time;
    int coolTime;
    bool on;
    private void Start()
    {
        on = false;
        time= 0;
        tapAmount = 2;
        active = 5;
        coolDown = 15;
        coolTime = coolDown;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
        Count();
    }

    public void OnMouseDown()
    {
        touch = Input.GetTouch(0);
        if (touch.tapCount == tapAmount && coolTime <= 0)
        {
            on = true;
            gameObject.SetActive(true);
        }
    }
    public void Count()
    {
        if (on == true)
        {
            ++time;
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
