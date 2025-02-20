using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.InputSystem;

public class SpellShots : MonoBehaviour
{
    public GameObject fireBall;
    public FloatingJoystick Joystick;
    public int fireNum = 1;
    Touch touch;
    public float fireSpeed;
    public Vector2 pointerPos;
    Rigidbody2D rb;
    public Vector2 pos;
    public Vector2 speed;
    public float waiting;
    public GameObject shield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireSpeed = 1;
        fireNum = 1;
        waiting = 0;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shield.transform.position = gameObject.transform.position;
        waiting += Time.deltaTime;
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (waiting >= 2 && Joystick.moving == false)
            {
                NumFire(fireNum);
                waiting = 0;
            }
        }
        else if (Input.touchCount == 2)
        {
            shield.SetActive(true);
        }
        else if(Input.touchCount == 0)
        {
            shield.SetActive(false);
        }
        if(waiting > 10)
        {
            waiting = 0;
        }
    }
    public void NowSpawn(Vector2 pos, Vector2 speed)
    {
        GameObject fire = Instantiate(fireBall, pos, Quaternion.identity);
        rb = fire.GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed;
        Disapate(fire);
    }
    public void Disapate(GameObject flame)
    {
        Destroy(flame, 0.5f);
    }
    public void NumFire(int Nums)
    {
        if (Nums == 1)
        {
            pos = new Vector2(pointerPos.x + 1, pointerPos.y);
            speed = new Vector2(fireSpeed ,0);
            NowSpawn(pos,speed);
        }
        else if (Nums == 2)
        {
            pos = new Vector2(pointerPos.x + 1, pointerPos.y);
            speed = new Vector2(fireSpeed, 0);
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x - 1, pointerPos.y);
            speed = new Vector2(fireSpeed - 2, 0);
            NowSpawn(pos, speed);
        }
        else if (Nums == 3)
        {
            pos = new Vector2(pointerPos.x + 0.5f, pointerPos.y + 0.5f);
            speed = new Vector2(fireSpeed, fireSpeed);
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x - 0.5f, pointerPos.y - 0.5f);
            speed = new Vector2(fireSpeed - 2,fireSpeed - 2 );
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x, pointerPos.y + 1);
            speed = new Vector2(0,fireSpeed);
            NowSpawn(pos, speed);
        }
        else if (Nums == 4)
        {
            pos = new Vector2(pointerPos.x + 1, pointerPos.y);
            speed = new Vector2(fireSpeed, 0);
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x - 1, pointerPos.y);
            speed = new Vector2(fireSpeed - 2, 0);
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x, pointerPos.y + 1);
            speed = new Vector2(0, fireSpeed);
            NowSpawn(pos, speed);
            pos = new Vector2(pointerPos.x, pointerPos.y - 1);
            speed = new Vector2(0, fireSpeed - 2);
            NowSpawn(pos, speed);
        }
    }
}
