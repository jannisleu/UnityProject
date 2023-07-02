using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Gumba gumba = other.gameObject.GetComponent<Gumba>();
            gumba.Kill();
            //Destroy(other.gameObject);
            Destroy(gameObject);
        } else if (other.collider.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            Destroy(gameObject);
        }
    }
}
