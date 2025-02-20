using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class FloatingJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriPos;
    private float joysickRadius;
    public bool moving;
    private void Start()
    {
        joystickOriPos = joystickBG.transform.position;
        joysickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        moving = true;
    }
    public void Drag(BaseEventData based)
    {
        PointerEventData pointer = based as PointerEventData;
        Vector2 dragPos = pointer.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
        if(joystickDist < joysickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joysickRadius;
        }
    }
    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriPos;
        joystickBG.transform.position = joystickOriPos;
        moving = false;
    }
}
