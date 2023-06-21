using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;

    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    //Update Function that gets called in every frame of the game
    private void Update()
    {
        HorizontalMovement();
        Jumping();
    }

    //Function for movement on the horizontal axis (left and right) for perry
    private void HorizontalMovement()
    {
        // Get horizontal input (left/right arrow or A/D keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the player horizontally
        rigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, rigidbody.velocity.y);
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rigidbody.velocity.y >= 0)
        {
            rigidbody.gravityScale = gravityScale;
        }
        else if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallingGravityScale;
        }
    }

    //Update Function that gets called in a fixed interval (for physics to keep it consistent)
    private void FixedUpdate()
    {
        Vector2 viewPos = transform.position; 
        //position += velocity * Time.fixedDeltaTime;
        
        //make sure Perry's position stays inside the Camera view and cannot go out of Frame 
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewPos.x = Mathf.Clamp(viewPos.x, leftEdge.x + 0.5f, rightEdge.x);

        transform.position = viewPos; //provides new position for perry
    }
}
