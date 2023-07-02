using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   
    [SerializeField]
    private TMP_Text _livestext;

    [SerializeField]
    private TMP_Text _coinstext;

    // Function to update Perrys lives
    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "lives: " + health;
    }

    //Function to update the collected coins
    public void UpdateCoins(int money)
    {
        _coinstext.text = "coins: " + money;
    }
}
