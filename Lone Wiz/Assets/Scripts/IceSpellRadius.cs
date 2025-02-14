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
    public int rotation;
    public int IceNum;
    public int time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IceNum = 2;
        startPosions = new Vector2[8];
        startPosions[0] = startPos1;
        startPosions[1] = startPos2;
        startPosions[2] = startPos3;
        startPosions[3] = startPos4;
        startPosions[4] = startPos5;
        startPosions[5] = startPos6;
        startPosions[6] = startPos7;
        startPosions[7] = startPos8;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        SetPosition();
        time += 1;
        IceTime(IceNum);
    }
    public void NumsIce(int Nums)
    {
        if(Nums == 2)
        {
            NowSpawn(startPos1,0);
            NowSpawn(startPos2, 0);
        }
        else if (Nums == 4)
        {
            NowSpawn(startPos5, 45);
            NowSpawn(startPos6, -45);
            NowSpawn(startPos7, 45);
            NowSpawn(startPos8, -45);
        }
        else if (Nums == 6)
        {
            NowSpawn(startPos1, 0);
            NowSpawn(startPos2, 0);
            NowSpawn(startPos5, 45);
            NowSpawn(startPos6, -45);
            NowSpawn(startPos7, 45);
            NowSpawn(startPos8, -45);
        }
        else if (Nums == 8)
        {
            NowSpawn(startPos1, 0);
            NowSpawn(startPos2, 0);
            NowSpawn(startPos3, 0);
            NowSpawn(startPos4, 0);
            NowSpawn(startPos5, 45);
            NowSpawn(startPos6, -45);
            NowSpawn(startPos7, 45);
            NowSpawn(startPos8, -45);
        }
    }
    void IceTime(int Nums)
    {
        if (time == 30)
        {
            NumsIce(Nums);
            time = 0;
        }
    }
    public void NowSpawn(Vector2 pos, float rotation)
    {
        GameObject ice = Instantiate(iceShot, pos, Quaternion.Euler(0,0,rotation));
        Disapate(ice);
    }
    public void Disapate(GameObject icey)
    {
        Destroy(icey, 1f);
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
}
