using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SpellShots : MonoBehaviour
{
    public GameObject fireBall;
    public float firedis = 4;
    public int fireNum = 1;
    public float fireTime;
    public float fireSpeed = 10;
    public Vector2 playerPos;
    public Vector2 pointerPos;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnFireball(fireNum);
        }
        
    }
    public void SpawnFireball(int fireNum)
    {
        float angleStep = 360f / fireNum;
        float angle = 0f;
        for (int i = 0; i < fireNum; i++) 
        {
            float fireDirXpos = pointerPos.x + Mathf.Sin((angle * Mathf.PI) / 180) * firedis;
            float fireDirYpos = pointerPos.y + Mathf.Sin((angle * Mathf.PI) / 180) * firedis;
            Vector2 projectileVec = new Vector2(fireDirXpos, fireDirYpos);
            Vector2 projectileMoveDir = (projectileVec - pointerPos).normalized * fireSpeed;
            var proj = Instantiate(fireBall, pointerPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
            angle += angleStep;
        }
    }
}
