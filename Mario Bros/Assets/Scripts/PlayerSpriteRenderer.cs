using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;

    //animation states
    public Sprite idle;
    public Sprite jump;
    public AnimatedSprite run;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
        
    }
    
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }
    
    private void LateUpdate()
    {
        //enable AnimatedSprite for the running animation if GameObject is running
        run.enabled = movement.running;
        //if jumping set sprite to jump
        if (movement.jumping)
        {
            spriteRenderer.sprite = jump;
        //if Gameobject is not moving, set sprite to idle
        } else if (!movement.running)
        {
            spriteRenderer.sprite = idle;
        }

    }

}
