using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int baseHealth = 100;
    public int currentHealth;
    public Slider slider;
    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public static GameStatus gameStatus = GameStatus.gameRunning;

    UIManager UI;

    void Start()
    {
        currentHealth = baseHealth;
        slider.value = baseHealth;
    }

    void Update()
    {
        slider.value = currentHealth;

    }


    public void StartGame()
    {
        gameStatus = GameManager.GameStatus.gameRunning;
        SceneManager.LoadScene("FortIsland", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
    }


}
