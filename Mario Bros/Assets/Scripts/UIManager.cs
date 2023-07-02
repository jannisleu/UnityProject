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

    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "lives: " + health;
    }

    public void UpdateCoins(int money)
    {
        _coinstext.text = "coins: " + money;
    }
}
