using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int baseHealth = 100;
    public int currentHealth;
    public Slider slider;
    public TextMeshPro healthText;
    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public static GameStatus gameStatus = GameStatus.gameRunning;

    void Start()
    {
        currentHealth = baseHealth;
        slider.value = baseHealth;
    }

    void Update()
    {
        slider.value = currentHealth;
        if (currentHealth <= 0)
            EndGame();
        
    }


    public void StartGame()
    {
        gameStatus = GameStatus.gameRunning;
        SceneManager.LoadScene("FortIsland", LoadSceneMode.Single);
    }

    public static void Exit()
    {
        Application.Quit();
    }

    public static void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
        UIManager.gameOver.SetActive(true);
    }


}
