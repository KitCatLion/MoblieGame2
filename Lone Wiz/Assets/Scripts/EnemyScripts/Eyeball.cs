using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Eyeball : MonoBehaviour
{
    public float shootingRange = 5f;
    public float keepDistance = 5f;
    public float spasmRadius = 1.5f;
    public BulletSpawner bulletSpawner;
    public float fireCooldown = 1.5f;
    private Transform player;
    private float fireTimer = 0f;
    private NavMeshAgent agent;
    private Vector3 randomOffset;
    private float spasmTimer = 0f;
    private float spasmChangeTime = 0.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        UpdateRandomOffset();
    }

    void Update()
    {
        MaintainDistanceWithSpasm();
        AimAndShoot();

        //lock rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void MaintainDistanceWithSpasm()
    {
        if (player)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > keepDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                spasmTimer += Time.deltaTime;
                if (spasmTimer >= spasmChangeTime)
                {
                    UpdateRandomOffset();
                    spasmTimer = 0f;
                }
                agent.SetDestination(player.position + randomOffset);
            }
        }
    }

    void UpdateRandomOffset()
    {
        randomOffset = new Vector3(Random.Range(-spasmRadius, spasmRadius), Random.Range(-spasmRadius, spasmRadius), 0);
    }

    void AimAndShoot()
    {
        if (player && bulletSpawner && Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireCooldown)
            {
                bulletSpawner.Fire();
                fireTimer = 0f;
            }
        }
    }
}