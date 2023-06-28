using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deathSprite;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    //insert the sprite that is used when perry gets killed
    private void UpdateSprite()
    {
        spriteRenderer.enabled = true; 
        spriteRenderer.sortingOrder = 10;

        if (deathSprite != null)
        {
            spriteRenderer.sprite = deathSprite;
        }
    }

    //disable the physics so the death animation can fall through the objects and in front of the scene 
    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        //Check if Player or Enemy should be disabled 
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        //EntityMovement entityMovement = GetComponent<EntityMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        //if (entityMovement != null)
        //{
        //    entityMovement.enabled = false;
        //}
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;


        while (elapsed < duration)
        {
            float t = elapsed/duration;

            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime; 
            elapsed += Time.deltaTime;
            
            yield return null;
        }
    }
}
