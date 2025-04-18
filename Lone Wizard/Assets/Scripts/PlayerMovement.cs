using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick Joystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public float hp;
    private int HpNum;
    public GameObject[] Hearts = new GameObject[3];
    public Sprite[] HeartQuarts = new Sprite[3];
    public bool Alive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Alive = true;
        HpNum = 3;
        hp = 1;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CurrentHP();
        WhichHeart();
    }
    private void FixedUpdate()
    {
        if(Joystick.joystickVec.y != 0)
        {
            rb.linearVelocity = new Vector2(Joystick.joystickVec.x * playerSpeed, Joystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {
            --hp;
        }
    }
    public void CurrentHP()
    {
        if (HpNum <= 0)
        {
            Alive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(this.gameObject);
        }
    }
    public void HeartDecrease(GameObject currentHeart)
    {
        if(hp >= .75 && hp < 1)
        {
            currentHeart.GetComponent<SpriteRenderer>().sprite = HeartQuarts[0];
        }
        else if (hp >= .50 && hp < .75)
        {
            currentHeart.GetComponent<SpriteRenderer>().sprite = HeartQuarts[1];
        }
        else if(hp >= .25 && hp < .50)
        {
            currentHeart.GetComponent<SpriteRenderer>().sprite = HeartQuarts[2];
        }
        else if(hp < .25)
        {
            currentHeart.active = false;
            HpNum--;
        }
    }
    public void WhichHeart()
    {
        if (HpNum == 3)
        {
            HeartDecrease(Hearts[2]);
        }
        else if (HpNum == 2) 
        {
            HeartDecrease(Hearts[1]);
        }
        else if(HpNum == 1)
        {
            HeartDecrease(Hearts[0]);
        }
    }
}
