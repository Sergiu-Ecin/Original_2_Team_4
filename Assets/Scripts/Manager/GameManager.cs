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


    void Update()
    {
        

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

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
    }
}
