using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    void Start()
    {
        //GameManager.AddCoin() Function in GameMangerScript 
        StartCoroutine(Animate());
    }

    //Animation for the Coin to come out of the bricks or blocks 
    private IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        Destroy(gameObject);
    }

    //Movement function for the coins that defines that the coin "jumps" upwards out of th blocks/bricks
    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.25f;

        while (elapsed < duration)
        {
            float t = elapsed/duration;

            transform.localPosition = Vector3.Lerp(from, to, t);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = to;
    }
}
