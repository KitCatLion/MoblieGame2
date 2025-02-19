using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{
    public float shootingRange = 7f;
    public float keepDistance = 5f;
    public BulletSpawner bulletSpawner;
    public float fireCooldown = 2f;
    private Transform player;
    private float fireTimer = 0f;
    private NavMeshAgent agent;
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;
        currentHealth = maxHealth;
    }

    void Update()
    {
        MaintainDistance();
        AimAndShoot();

        //lock rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void MaintainDistance()
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
                agent.ResetPath();
            }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball"))
        {
            TakeDamage(10f); // Fireball does least damage
        }
        else if (other.CompareTag("IceSpell"))
        {
            TakeDamage(20f); // Ice does more damage
        }
        else if (other.CompareTag("Lightning"))
        {
            TakeDamage(30f); // Lightning does the most damage
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Destroy enemy when health reaches zero
    }

}