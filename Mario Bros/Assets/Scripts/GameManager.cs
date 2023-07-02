using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    public int world {get; private set;}
    public int _lives {get; private set;}
    public int coins {get; private set;}

    [SerializeField]
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        NewGame();
        
    }    

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

 

    private void NewGame()
    {
        _lives = 3;

        LoadLevel(1);

        _uiManager.UpdateLives(_lives);
    }

    public void LoadLevel( int world)
    {
        this.world = world;

        SceneManager.LoadScene($"Level {world}");
    }

    public void NextLevel()
    {
        LoadLevel(world+1);
    }


    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        _lives--;

        _uiManager.UpdateLives(_lives);
        

        if (_lives > 0)
        {
            LoadLevel(world);

        }else{
            GameOver();
        }


    }

    public void AddCoin()
    {
        coins++;
        //_uiManager.UpdateCoins(coins);

        if (coins == 15)
        {
            AddLife();
            coins=0;
             _uiManager.UpdateLives(_lives);
        }
        
    }

    public void AddLife()
    {
        _lives++;
    }

    private void GameOver()
    {
        //maybe GameOver Screen??
       Invoke(nameof(NewGame), 2f);

    }
}
