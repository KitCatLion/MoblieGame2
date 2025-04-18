using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : BaseEnemy
{
    public float speed = 2f;
    public float maxHealth = 60f; // Higher health than Green Slime
    private Transform player;
    private float currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FireBall"))
        {
            TakeDamage(10f);
        }
        else if (other.CompareTag("Ice"))
        {
            TakeDamage(20f);
        }
        else if (other.CompareTag("Lightning"))
        {
            TakeDamage(30f);
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
