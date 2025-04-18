using UnityEngine;

public class PlayerARMovement : MonoBehaviour
{
    Vector2 movement;
    public float speed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        movement = Vector2.zero;
        movement = new Vector2(-Input.acceleration.y, Input.acceleration.x);
        GetComponent<Rigidbody2D>().AddForce(movement * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
