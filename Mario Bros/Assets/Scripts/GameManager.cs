using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //game manager as instance
    public static GameManager Instance {get; private set; }


    public int world {get; private set;}
    public int _lives {get; private set;}
    public int coins {get; private set;}

    //import UIManager Script
    //[SerializeField]
    //private UIManager _uiManager;

    //Start Function to start new game
    private void Start()
    {
        //_uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        NewGame();
        
    }    

    //Awake function making sure that not more than one instance exists
    private void Awake()
    {
    
        if (Instance != null) 
        {
            DestroyImmediate(gameObject);

        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

 
    //New Game Function to to start new game with 3 new lives
    private void NewGame()
    {
        _lives = 3;

        LoadLevel(1);

        //_uiManager.UpdateLives(_lives);
    }

    //Load Level Function to load a level from the 3 given levels
    public void LoadLevel( int world)
    {
        this.world = world;

        SceneManager.LoadScene($"Level {world}");
    }

    //Next Level Function to load new level
    public void NextLevel()
    {
        if(world < 3) {
            LoadLevel(world+1);
        } else {
            GameOver();
        }
    }

    //Reset Level to reset level after a few seconds of delay
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    //Reset Level Function reducing lives by one and ending the game after losing all 3 lives 
    public void ResetLevel()
    {
        _lives--;

        //_uiManager.UpdateLives(_lives);
        

        if (_lives > 0)
        {
            LoadLevel(world);

        }else{
            GameOver();
        }


    }

    //Add Coin Function to add coins after collecting them and adding one life after 15 coins 
    public void AddCoin()
    {
        coins++;
        //_uiManager.UpdateCoins(coins);

        if (coins == 15)
        {
            AddLife();
            coins=0;
            //_uiManager.UpdateLives(_lives);
        }
        
    }

    //Add Life Function adding one life
    public void AddLife()
    {
        _lives++;
    }

    //Game over Function ending the game after 2 seconds
    private void GameOver()
    {
        //maybe GameOver Screen??
       Invoke(nameof(NewGame), 2f);

    }
}
