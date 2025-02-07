using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Vector2 JoystickSize = new Vector2(300, 300);
    private FloatingJoystick Joystick;
    private Finger MovementFinger;
    private Vector2 MovementAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector2 scaledMovement = new Vector2(MovementAmount.x, MovementAmount.y);
        player.transform.LookAt(scaledMovement, Vector2.up);
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
        ETouch.Touch.onFingerUp += Touch_onFingerUp;
        ETouch.Touch.onFingerMove += Touch_onFingerMove;
    }
    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= Touch_onFingerDown;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
        ETouch.Touch.onFingerMove -= Touch_onFingerMove;
        EnhancedTouchSupport.Disable();
    }
    private void Touch_onFingerDown(Finger obj)
    {
        if(MovementFinger == null && obj.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = obj;
            MovementAmount = Vector2.zero;
            Joystick.rectTransform.sizeDelta = JoystickSize;
            Joystick.rectTransform.anchoredPosition = ClampStartPosition(obj.screenPosition);
        }
    }
    private void Touch_onFingerUp(Finger obj)
    {
        if(obj == MovementFinger)
        {
            MovementFinger = null;
            Joystick.knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }
    private void Touch_onFingerMove(Finger obj)
    {
        if(obj == MovementFinger)
        {
            Vector2 knobPos;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = obj.currentTouch;
            if(Vector2.Distance(currentTouch.screenPosition, Joystick.rectTransform.anchoredPosition) > maxMovement)
            {
                knobPos = (currentTouch.screenPosition - Joystick.rectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPos = currentTouch.screenPosition - Joystick.rectTransform.anchoredPosition;
            }
            Joystick.knob.anchoredPosition = knobPos;
            MovementAmount = knobPos / maxMovement;
        }
    }
    private Vector2 ClampStartPosition(Vector2 startpos)
    {
        if(startpos.x < JoystickSize.x / 2)
        {
            startpos.x = JoystickSize.x / 2;
        }
        if (startpos.y < JoystickSize.y / 2)
        {
            startpos.y = JoystickSize.y / 2;
        }
        else if (startpos.y > Screen.height - JoystickSize.y / 2)
        {
            startpos.y = Screen.height - JoystickSize.y / 2;
        }
        return startpos;
    }
    */
}
