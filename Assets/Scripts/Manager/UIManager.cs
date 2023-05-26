using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;
    [SerializeField] TextMeshProUGUI ScoreText;
    InventoryManager Im;

    public static float score;
    [SerializeField] public GameObject Pausa;
    [SerializeField] public GameObject GameOver;

    public static GameObject gameOver;
    bool opzioni;

    GameManager gm;
    private void Awake()
    {
        gameOver = GameOver;
        Im = FindObjectOfType<InventoryManager>();
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {


        ScoreText.text = score.ToString();
        MoneyText.text = Im.money.ToString();
        if (opzioni == false)
        {
            PausaOn();
        }
    }
    void PausaOn()
    {

        if (Input.GetKeyDown("escape") && gm.gameStatus == GameStatus.gameRunning)
        {
            gm.gameStatus = GameStatus.gamePaused;
            Pausa.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && gm.gameStatus == GameStatus.gamePaused)
        {
            gm.gameStatus = GameStatus.gameRunning;
            Pausa.SetActive(false);
        }
    }

    public void Continua()
    {
        Pausa.SetActive(false);
        gm.gameStatus = GameStatus.gameRunning;
    }

    public void Ricomincia()
    {
        gm.gameStatus = GameStatus.gameRunning;
        SceneManager.LoadScene("StartCanvas", LoadSceneMode.Single);
    }






}
