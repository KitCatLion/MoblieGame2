using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Eyeball : MonoBehaviour
{
    public float shootingRange = 5f;
    public BulletSpawner bulletSpawner;
    public float fireCooldown = 1.5f;
    private Transform player;
    private float fireTimer = 0f;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
    }

    void Update()
    {
        MoveStrategically();
        AimAndShoot();
    }

    void MoveStrategically()
    {
        if (player)
        {
            Vector3 offset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
            agent.SetDestination(player.position + offset);
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
