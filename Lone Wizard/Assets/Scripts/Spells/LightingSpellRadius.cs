using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpellRadius : MonoBehaviour
{
    public GameObject ligthing;
    public GameObject radius;
    public Vector2 center;
    public Vector2 size;
    public int time;
    public int amountTime;
    public float deathTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        size = new Vector2(2,2);
        amountTime = 200;
        deathTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        center = radius.transform.position;
        time += 1;
        NowSpawn();
    }
    public void SpawnLighting()
    {
        Vector2 pos = center + new Vector2(Random.Range(size.x - 4,size.x), Random.Range(size.y - 4, size.y));
        GameObject lighting = Instantiate(ligthing, pos, Quaternion.identity);
        Disapate(lighting);
    }
    public void NowSpawn()
    {
        if(time == amountTime)
        {
            SpawnLighting();
            time = 0;
        }
    }
    public void Disapate(GameObject light)
    {
        Destroy(light, deathTime);
    }
}
