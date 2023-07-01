using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumba : MonoBehaviour
{
    public Sprite flatGumba;

    [SerializeField] private LayerMask playerLayerMask;
    private CircleCollider2D circleCollider;

    private void Awake() {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    //if the player collides with the enemy from the top -> destroy enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (CollideOnTop()) {
                Kill();
            }
        }
    }

    //check if collision occurs on the top of the object
    private bool CollideOnTop() {

        float epsilon = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0f, Vector2.up, epsilon, playerLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(circleCollider.bounds.center + new Vector3(circleCollider.bounds.extents.x, 0), Vector2.up * (circleCollider.bounds.extents.y + epsilon), rayColor);
        return (raycastHit.collider != null);
    }

    //destroy gumba and disable all components
    private void Kill() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatGumba;
        Destroy(gameObject, 0.5f);
    }
}


