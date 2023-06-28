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
                //GameManager.AddCoin(); Function in GameManager Script
                break;

            case Type.ExtraLife:
                //GameManager.AddLife(); Function in GameManager Script
                break;
            
            case Type.MagicMushroom:

                break;

            case Type.FireFlower:

                break;

            case Type.IceFlower:

                break;

            case Type.Starpower:

                break;
        }

        Destroy(gameObject);
    }

}
