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
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        UpdateRandomOffset();
        currentHealth = maxHealth;
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
            else if (distance < keepDistance - 1f) // Prevent getting too close
            {
                Vector3 directionAway = (transform.position - player.position).normalized;
                agent.SetDestination(transform.position + directionAway * keepDistance);
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