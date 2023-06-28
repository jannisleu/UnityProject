using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject item;
    public Sprite emptyBlock;
    public int maxHits = 1; //how often can it be hit (1 for once or -1 for infinity )

    //function for collision detection of player and the game object (brick or block)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }


    //function for hitting the game object and exchanging it to another sprite (empty Brick)
    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        maxHits--;

        if (maxHits == 0) 
        {
            spriteRenderer.sprite = emptyBlock;
        }

        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
