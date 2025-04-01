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
    public int hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 5;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CurrentHP();
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
        if (hp <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
