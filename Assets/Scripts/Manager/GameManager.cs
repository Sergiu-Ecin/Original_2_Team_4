using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float baseHealth = 100;
    public float currentHealth;
    public Slider slider;
    public TextMeshProUGUI healthText;
    [SerializeField]
    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public GameStatus gameStatus = GameStatus.gameRunning;

    void Start()
    {
        currentHealth = baseHealth;
        slider.value = baseHealth;
    }

    void Update()
    {
        healthText.text = currentHealth.ToString() + " /100";
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

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
        UIManager.gameOver.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAmmo")
        {
            baseHealth -= EnemyController.takeDanno;
            Destroy(other.gameObject);
        }
    }
}
