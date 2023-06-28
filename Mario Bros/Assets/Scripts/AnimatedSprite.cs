using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script for the animation of a sprite
public class AnimatedSprite : MonoBehaviour
{
    //array to store all sprites
    public Sprite[] sprites;
    //6 frames per second
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //If enabled, run Animate()
    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    //if disabled, cancel Animate()
    private void OnDisable()
    {
        CancelInvoke();
    }

    //iterate through the sprites array
    private void Animate()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
    }
}
