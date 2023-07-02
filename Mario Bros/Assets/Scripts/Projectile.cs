using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(1,0);
    

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = direction * projectileSpeed;
        //rb.AddForce(transform.forward * projectileSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //check if colliding object is an enemy -> destroy projectile and enemy
        if (other.gameObject.CompareTag("Enemy")) {
            Gumba gumba = other.gameObject.GetComponent<Gumba>();
            gumba.Kill();
            Destroy(gameObject);
        //check for collision with a platform -> destroy projectile
        } else if (other.collider.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            Destroy(gameObject);
        }
    }
}
