using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    PlayerMovement status;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(status.Alive == false)
        {
            Instantiate(player);
        }
        WherePlayer();
    }
    public void WherePlayer()
    {
        if (player.transform.position.x == 4.5f)
        {
            cam.transform.position = new Vector3(2f, 0, -10);
        }
        else if(player.transform.position.x == -4f)
        {
            cam.transform.position = new Vector3(-2, 0, -10);
        }
        if(player.transform.position.y == 2f)
        {
            cam.transform.position = new Vector3(0, 1, -10);
        }
        else if(player.transform.position.y == -1.5)
        {
            cam.transform.position = new Vector3(0, -0.5f, -10);
        }
    }
}
