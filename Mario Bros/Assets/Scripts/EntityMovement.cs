using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = Vector2.left;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;

    [SerializeField] private LayerMask platformLayerMask;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        enabled = false;
    }

    //enable script when gumba is in the camera view
    private void OnBecameVisible()
    {
        enabled = true;
    }

    //disable script if gumba is not in the camera view
    private void OnBecameInvisible()
    {
        enabled = false;
    }

    //if script is enabled, wake gumba up
    private void OnEnable()
    {
        rigidbody.WakeUp();
    }

    //is disabled, set velocity to zero and let gumba sleep
    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    //check if gumba collides with a platform
    private bool Collision()
    {
        float epsilon = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, direction, circleCollider.bounds.extents.x + epsilon, platformLayerMask);
        return (raycastHit.collider != null);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, rigidbody.velocity.y);

        //flip direction when gumba collides with a platform
        if (Collision()) {
            direction = -direction;
        }
    }
}
