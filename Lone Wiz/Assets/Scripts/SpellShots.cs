using UnityEngine;

public class SpellShots : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject lighting;
    public GameObject iceSpike1;
    public GameObject iceSpike2;
    public GameObject iceRadius;
    public GameObject lightingRadius;
    public GameObject fireRadius;
    public float firedis = 4;
    public float icedis = 3.5f;
    public float ligthdis = 5f;
    public int fireNum = 1;
    public int iceNum = 2;
    public int ligthNum = 1;
    public float fireTime;
    public int iceTime;
    public int ligthTime;
    private Vector3 firePos;
    private Vector3 lightPos;
    private Vector3 icePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        iceRadius.transform.localScale = new Vector3(icedis, icedis, icedis);
        fireRadius.transform.localScale = new Vector3(firedis, firedis, firedis);
        lightingRadius.transform.localScale = new Vector3(ligthdis, ligthdis, ligthdis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fireShot()
    {
        if (fireNum == 1)
        {
            firePos = gameObject.transform.position;
            Instantiate(fireBall);
        }
        else if (fireNum == 2)
        {

        }
        else if (fireNum == 3)
        {

        }
        else if (fireNum == 4)
        {

        }
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
    public void lightingShot()
    {
        if (ligthNum == 1)
        {
            Instantiate(lighting);
        }
        else if (ligthNum == 2)
        {

        }
        else if (ligthNum == 3)
        {

        }
        else if (ligthNum == 4)
        {

        }
    }
}
