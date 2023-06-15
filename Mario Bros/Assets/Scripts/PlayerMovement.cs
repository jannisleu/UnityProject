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

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //Update Function that gets called in every frame of the game
    private void Update()
    {
        HorizontalMovement();
        camera = Camera.main;
    }

    //Function for movement on the horizontal axis (left and right) for perry
    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime); //velocity is getting higher when running longer 

    }

    //Update Function that gets called in a fixed interval (for physics to keep it consistent)
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position; 
        position += velocity * Time.fixedDeltaTime;

        //make sure Perry's position stays inside the Camera view and cannot go out of Frame 
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        rigidbody.MovePosition(position); //provides new position for perry
    }
}
