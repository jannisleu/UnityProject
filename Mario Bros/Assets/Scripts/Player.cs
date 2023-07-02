using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public PlayerSpriteRenderer fireRenderer;
    public PlayerSpriteRenderer iceRenderer;
    public PlayerSpriteRenderer starRenderer;

    private CapsuleCollider2D capsuleCollider;
    private PlayerSpriteRenderer activeRenderer;

    private DeathAnimation deathAnimation;

    //shooting
    [SerializeField]
    private GameObject iceBullet;
    [SerializeField]
    private GameObject fireBullet;
    private float nextFire = 0.5f;
    private float shootCooldown = 0.2f;

    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;
    public bool fire => fireRenderer.enabled;
    public bool ice => iceRenderer.enabled;
    public bool star => starRenderer.enabled;
    public bool dead => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        bigRenderer.enabled = false;
        fireRenderer.enabled = false;
        iceRenderer.enabled = false;
        starRenderer.enabled = false;
        deathAnimation.enabled = false;

    }

    void Update() {
        //shooting
        if(ice) {
            if (Input.GetKeyDown(KeyCode.E) && nextFire < Time.time) {
                Instantiate(iceBullet, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.identity);
                nextFire = Time.time + shootCooldown;
            }
        } else if(fire) {
            if (Input.GetKeyDown(KeyCode.E) && nextFire < Time.time) {
                Instantiate(fireBullet, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.identity);
                nextFire = Time.time + shootCooldown;
            }
        }
    }

    public void Hit()
    {
        if (!dead && !star)
        {
            if (big) {
                Shrink();
            } else if (small) {
                Death();
            } else if (fire) {
                FireShrink();
            } else if (ice) {
                IceShrink();
            }
            
        }
    }

    public void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;

        activeRenderer = smallRenderer;

        capsuleCollider.size = new Vector2(1f, 1f);
        capsuleCollider.offset = new Vector2(0f, -0.5f);

        StartCoroutine(ScaleAnimation());
    }

    public void Grow()
    {
        bigRenderer.enabled = true;
        smallRenderer.enabled = false;
        fireRenderer.enabled = false;
        iceRenderer.enabled = false;
        starRenderer.enabled = false;

        activeRenderer = bigRenderer;

        capsuleCollider.size = new Vector2(1,1.7f);
        capsuleCollider.offset = new Vector2(0, -0.15f);

        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                smallRenderer.enabled = !smallRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        activeRenderer.enabled = true;
    }

    public void Ice()
    {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        fireRenderer.enabled = false;
        iceRenderer.enabled = true;
        starRenderer.enabled = false;

        activeRenderer = iceRenderer;

        capsuleCollider.size = new Vector2(1,1.7f);
        capsuleCollider.offset = new Vector2(0, -0.15f);

        StartCoroutine(IceScaleAnimation());
    }

    public void Fire()
    {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        fireRenderer.enabled = true;
        iceRenderer.enabled = false;
        starRenderer.enabled = false;

        activeRenderer = fireRenderer;

        capsuleCollider.size = new Vector2(1,1.7f);
        capsuleCollider.offset = new Vector2(0, -0.15f);

        StartCoroutine(IceScaleAnimation());
    }

    public void IceShrink()
    {
        bigRenderer.enabled = true;
        iceRenderer.enabled = false;

        activeRenderer = bigRenderer;

        StartCoroutine(IceScaleAnimation());
    }

    public void FireShrink()
    {
        bigRenderer.enabled = true;
        fireRenderer.enabled = false;

        activeRenderer = bigRenderer;

        StartCoroutine(IceScaleAnimation());
    }


    public void Star()
    {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        fireRenderer.enabled = false;
        iceRenderer.enabled = false;
        starRenderer.enabled = true;

        activeRenderer = starRenderer;

        capsuleCollider.size = new Vector2(1,1.7f);
        capsuleCollider.offset = new Vector2(0, -0.15f);

        StartCoroutine(StarScaleAnimation());
    }

    private IEnumerator IceScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                iceRenderer.enabled = !iceRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
        }

        iceRenderer.enabled = false;
        bigRenderer.enabled = false;
        activeRenderer.enabled = true;
    }

    private IEnumerator FireScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                fireRenderer.enabled = !fireRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
        }

        fireRenderer.enabled = false;
        bigRenderer.enabled = false;
        activeRenderer.enabled = true;
    }

    private IEnumerator StarScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                starRenderer.enabled = !starRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
        }

        starRenderer.enabled = false;
        bigRenderer.enabled = false;
        activeRenderer.enabled = true;
    }

    private void Death()
    {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        fireRenderer.enabled = false;
        iceRenderer.enabled = false;
        starRenderer.enabled = false;

        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3f);   
    }


}

