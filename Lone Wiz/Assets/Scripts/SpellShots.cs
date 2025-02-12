using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SpellShots : MonoBehaviour
{
    TouchPhase touch;
    public GameObject fireBall;
    public GameObject lighting;
    public GameObject iceSpike1;
    public GameObject iceSpike2;
    public GameObject fireRadius;
    public GameObject lightingRadius;
    public GameObject iceRadius;
    public float firedis = 4;
    public float icedis = 3.5f;
    public float ligthdis = 5f;
    public int fireNum = 1;
    public int iceNum = 2;
    public int ligthNum = 1;
    public float fireTime;
    public int iceTime;
    public int ligthTime;
    public float fireSpeed;
    public Vector2 playerPos;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if (touch == 0)
        {
            
        }
    }
    public void SpawnFireball(int fireNum)
    {
        float angleStep = 360f / fireNum;
        float angle = 0f;
        for (int i = 0; i < fireNum; i++) 
        {
            float fireDirXpos = playerPos.x + Mathf.Sin((angle * Mathf.PI) / 180) * firedis;
            float fireDirYpos = playerPos.y + Mathf.Sin((angle * Mathf.PI) / 180) * firedis;
            Vector2 projectileVec = new Vector2(fireDirXpos, fireDirYpos);
            Vector2 projectileMoveDir = (projectileVec - playerPos).normalized * fireSpeed;
            var proj = Instantiate(fireBall, playerPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
            angle += angleStep;
        }
    }
    public void SpawnIceShot(int iceNum)
    {
        float angleStep = 360f / iceNum;
        float angle = 0f;
        for (int i = 0; i < iceNum; i++)
        {
            float iceDirXpos = playerPos.x + Mathf.Sin((angle * Mathf.PI) / 180) * icedis;
            float iceDirYpos = playerPos.y + Mathf.Sin((angle * Mathf.PI) / 180) * icedis;
            Vector2 projectileVec = new Vector2(iceDirXpos, iceDirYpos);
            Vector2 projectileMoveDir = (projectileVec - playerPos).normalized * fireSpeed;
            var proj = Instantiate(iceSpike2, playerPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
            angle += angleStep;
        }
    }
    public void SpawnLighting(int lightingNum)
    {

    }
    public void iceShot()
    {
        if (iceNum == 2)
        {
            Instantiate(iceSpike1);
        }
        else if (iceNum == 4) 
        {

        }
        else if (iceNum == 6)
        {

        }
        else if (iceNum == 8)
        {

        }
    }
}
