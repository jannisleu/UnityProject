using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin, 
        ExtraLife,
        MagicMushroom,
        FireFlower,
        IceFlower,
        Starpower
    }

    public Type type;

    //trigger function to collect item when colliding 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }


    //create a case sensitive collect function that differentiates between different items and provides case sensitive powers for perry 
    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin(); //Function in GameManager Script
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife(); //Function in GameManager Script
                break;
            
            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                break;

            case Type.FireFlower:
                player.GetComponent<Player>().Fire();
                break;

            case Type.IceFlower:
                player.GetComponent<Player>().Ice();
                break;

            case Type.Starpower:
                player.GetComponent<Player>().Star();
                break;
        }

        Destroy(gameObject);
    }

}
