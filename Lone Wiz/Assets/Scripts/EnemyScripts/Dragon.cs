using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{
    public float shootingRange = 7f;
    public BulletSpawner bulletSpawner;
    public float fireCooldown = 2f;
    private Transform player;
    private float fireTimer = 0f;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;
    }

    void Update()
    {
        MoveTowardsPlayer();
        AimAndShoot();
    }

    void MoveTowardsPlayer()
    {
        if (player)
        {
            agent.SetDestination(player.position);
        }
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