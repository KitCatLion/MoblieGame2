using UnityEngine;

public class IceSpellRadius : MonoBehaviour
{
    public GameObject iceShot;
    public GameObject player;
    public Vector2 playerPos;
    public Vector2 startPos1;
    public Vector2 startPos2;
    public Vector2 startPos3;
    public Vector2 startPos4;
    public Vector2 startPos5;
    public Vector2 startPos6;
    public Vector2 startPos7;
    public Vector2 startPos8;
    public Vector2[] startPosions;
    public Vector2[] speeds;
    float speed;
    public int rotation;
    public int IceNum;
    public int time;
    public int amountTime;
    public float deathTime;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IceNum = 2;
        speed = 2;
        startPosions = new Vector2[8];
        startPosions[0] = startPos1;
        startPosions[1] = startPos2;
        startPosions[2] = startPos3;
        startPosions[3] = startPos4;
        startPosions[4] = startPos5;
        startPosions[5] = startPos6;
        startPosions[6] = startPos7;
        startPosions[7] = startPos8;
        speeds = new Vector2[8];
        amountTime = 250;
        deathTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        SetPosition();
        SetSpeed();
        time += 1;
        IceTime(IceNum);
    }
    public void NumsIce(int Nums)
    {
        if(Nums == 2)
        {
            NowSpawn(startPos1,0, speeds[0]);
            NowSpawn(startPos2, 180, speeds[1]);
        }
        else if (Nums == 4)
        {
            NowSpawn(startPos5, 45, speeds[4]);
            NowSpawn(startPos6, 45, speeds[5]);
            NowSpawn(startPos7, -45, speeds[6]);
            NowSpawn(startPos8, -45, speeds[7]);
        }
        else if (Nums == 6)
        {
            NowSpawn(startPos1, 0, speeds[0]);
            NowSpawn(startPos2, 180, speeds[1]);
            NowSpawn(startPos5, 45, speeds[4]);
            NowSpawn(startPos6, 45, speeds[5]);
            NowSpawn(startPos7, -45, speeds[6]);
            NowSpawn(startPos8, -45, speeds[7]);
        }
        else if (Nums == 8)
        {
            NowSpawn(startPos1, 0, speeds[0]);
            NowSpawn(startPos2, 180, speeds[1]);
            NowSpawn(startPos3, 90, speeds[2]);
            NowSpawn(startPos4, -90, speeds[3]);
            NowSpawn(startPos5, 45, speeds[4]);
            NowSpawn(startPos6, 45, speeds[5]);
            NowSpawn(startPos7, -45, speeds[6]);
            NowSpawn(startPos8, -45, speeds[7]);
        }
    }
    void IceTime(int Nums)
    {
        if (time == amountTime)
        {
            NumsIce(Nums);
            time = 0;
        }
    }
    public void NowSpawn(Vector2 pos, float rotation, Vector2 speed)
    {
        GameObject ice = Instantiate(iceShot, pos, Quaternion.Euler(0,0,rotation));
        rb = ice.GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed;
        Disapate(ice);
    }
    public void Disapate(GameObject icey)
    {
        Destroy(icey, deathTime);
    }
    public void SetPosition()
    {
        startPos1 = new Vector2 (playerPos.x + 1, playerPos.y);
        startPos2 = new Vector2(playerPos.x - 1, playerPos.y);
        startPos3 = new Vector2(playerPos.x, playerPos.y - 1);
        startPos4 = new Vector2(playerPos.x, playerPos.y + 1);
        startPos5 = new Vector2(playerPos.x + 0.5f, playerPos.y + 0.5f);
        startPos6 = new Vector2(playerPos.x - 0.5f, playerPos.y - 0.5f);
        startPos7 = new Vector2(playerPos.x + 0.5f, playerPos.y - 0.5f);
        startPos8 = new Vector2(playerPos.x - 0.5f, playerPos.y + 0.5f);
    }
    public void SetSpeed()
    {
        speeds[0] = new Vector2(speed,0);
        speeds[1] = new Vector2(speed - 4, 0);
        speeds[2] = new Vector2(0, speed - 4);
        speeds[3] = new Vector2(0, speed);
        speeds[4] = new Vector2(speed, speed);
        speeds[5] = new Vector2(speed - 4, speed - 4);
        speeds[6] = new Vector2(speed, speed - 4);
        speeds[7] = new Vector2(speed - 4, speed);
    }
}
