using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    public int world {get; private set;}
    public int stage {get; private set;}
    public int lives {get; private set;}
    public int coins {get; private set;}

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

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;

        LoadLevel(1);
    }

    public void LoadLevel(int world)
    {
        this.world = world;

        SceneManager.LoadScene($"Level {world}");
    }




    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }
    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world);

        }else{
            GameOver();
        }

    }

    public void NextLevel() {
        LoadLevel(world+1);
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 15){
            AddLife();
            coins=0;
        }
    }

    public void AddLife()
    {
        lives++;
    }

    private void GameOver()
    {
        //maybe GameOver Screen??
       Invoke(nameof(NewGame), 3f);

    }
}
