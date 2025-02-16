using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Shotgun }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;
    public int shotgunPellets = 5;
    public float spreadAngle = 15f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);

        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            if (spawnerType == SpawnerType.Shotgun)
            {
                float startAngle = -spreadAngle * (shotgunPellets - 1) / 2;
                for (int i = 0; i < shotgunPellets; i++)
                {
                    float angle = startAngle + (spreadAngle * i);
                    Quaternion rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + angle);
                    GameObject spawnedBullet = Instantiate(bullet, transform.position, rotation);
                    Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();
                    bulletScript.speed = speed;
                    bulletScript.bulletLife = bulletLife;
                }
            }
            else
            {
                GameObject spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
                Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();
                bulletScript.speed = speed;
                bulletScript.bulletLife = bulletLife;
            }
        }
    }
}
