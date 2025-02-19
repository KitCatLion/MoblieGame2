using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : BaseEnemy
{
    public float speed = 2f;
    public float stopDistance = 3f;
    public float shootingRange = 5f;
    public BulletSpawner bulletSpawner;
    public float fireCooldown = 1f;
    private Transform player;
    private float fireTimer = 0f;
    private bool canShoot = false;
    public float maxHealth = 50;
    public float currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        MoveTowardsPlayer();
        CheckShootingRange();
        AimAndShoot();
    }


    void MoveTowardsPlayer()
    {
        if (player)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }

    void CheckShootingRange()
    {
        if (player)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            canShoot = distance <= shootingRange;
        }
    }

    void AimAndShoot()
    {
        if (player && bulletSpawner && canShoot)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireCooldown)
            {
                Vector2 playerVelocity = player.GetComponent<Rigidbody2D>()?.linearVelocity ?? Vector2.zero;
                Vector2 directionToPlayer = (player.position - transform.position).normalized;

                bool predictMovement = Random.value > 0.5f;
                if (predictMovement)
                {
                    Vector2 predictedPosition = (Vector2)player.position + playerVelocity * 0.5f;
                    directionToPlayer = (predictedPosition - (Vector2)transform.position).normalized;
                }

                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, angle);

                bulletSpawner.Fire();
                fireTimer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireBall"))
        {
            TakeDamage(10f); // Fireball does least damage
        }
        else if (other.CompareTag("Ice"))
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
