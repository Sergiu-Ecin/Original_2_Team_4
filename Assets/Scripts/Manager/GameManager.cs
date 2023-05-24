using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public static GameStatus gameStatus = GameStatus.gameRunning;

    UIManager UI;

    void Update()
    {
        

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
