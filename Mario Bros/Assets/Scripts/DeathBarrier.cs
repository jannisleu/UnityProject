using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
   
   //Function to trigger level reset when player is falling down 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //once for the player falling down
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(3f);
        }
        //and for other game objects falling down
        else
        {
            Destroy(other.gameObject);
        }
    }

}
