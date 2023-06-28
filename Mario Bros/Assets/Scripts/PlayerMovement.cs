using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    public float moveSpeed = 8f;

    //jumping
    public float gravityScale = 10;
    public float fallingGravityScale = 15;
    public float buttonTime = 0.5f;
    public float jumpHeight = 20;
    public float cancelRate = 50;
    float jumpTime;
    bool jumpCancelled;

    public bool jumping;
    public bool running; 

    public bool FacingRight = true;

    //Groundcheck
    [SerializeField] private LayerMask platformLayerMask;
    //private BoxCollider2D boxCollider2d;
    private CapsuleCollider2D capsuleCollider2d;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        capsuleCollider2d = transform.GetComponent<CapsuleCollider2D>();
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
        if (moveHorizontal > 0 && !FacingRight)
        {
            Flip();
        } else if (moveHorizontal < 0 && FacingRight)
        {
            Flip();
        }
        if (moveHorizontal == 0)
        {
            running = false;
        } else
        {
            running = true;
        }

        // Move the player horizontally
        rigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, rigidbody.velocity.y);
    }
    //Function for vertical movement(jump)
    private void Jumping()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //calculate jump force to keep jump height within the specified boundaries
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rigidbody.gravityScale));
            //apply force to Perry to move up
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            //add up air time
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //cancel jump if released early
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                //stop jumping after maximum allowed jump time
                jumping = false;
            }
        }
        //control gravity to be a bit higher on the way down
        if (rigidbody.velocity.y >= 0)
        {
            rigidbody.gravityScale = gravityScale;
        }
        else if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallingGravityScale;
        }
    }
    private bool isGrounded()
    {
        //check if Perry is grounded by using a BoxCast which checks for collision with all blocks of the platform layer
        float epsilon = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size, 0f, Vector2.down, epsilon, platformLayerMask);
        return (raycastHit.collider != null);
    }
    //Flip local scale of Perry(important for the animation)
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        //flip local scale
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        FacingRight = !FacingRight;
    }

    //Update Function that gets called in a fixed interval (for physics to keep it consistent)
    private void FixedUpdate()
    {
        //if jump is over, reduce the velocity slowly to zero
        if (jumpCancelled && jumping && rigidbody.velocity.y > 0)
        {
            rigidbody.AddForce(Vector2.down * cancelRate);
        }

        Vector2 viewPos = transform.position;

        //make sure Perry's position stays inside the Camera view and cannot go out of Frame 
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewPos.x = Mathf.Clamp(viewPos.x, leftEdge.x + 0.5f, rightEdge.x);

        transform.position = viewPos; //provides new position for perry
    }
}
