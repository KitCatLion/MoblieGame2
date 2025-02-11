using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick Joystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
