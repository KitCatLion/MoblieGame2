using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SpellShots : MonoBehaviour
{
    public GameObject fireBall;
    public int fireNum = 1;
    public float fireSpeed;
    public Vector2 pointerPos;
    Rigidbody2D rb;
    public Vector2 pos;
    public Vector2 speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireSpeed = 1;
        fireNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            NumFire(fireNum);
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
