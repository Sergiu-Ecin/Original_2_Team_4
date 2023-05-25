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
    [SerializeField] public GameObject Comandi;
    [SerializeField] public GameObject GameOver;

    public static GameObject gameOver;
    bool opzioni;
    private void Awake()
    {
        gameOver = GameOver;
        Im = FindObjectOfType<InventoryManager>();
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

        if (Input.GetKeyDown("escape") && GameManager.gameStatus == GameStatus.gameRunning)
        {
            GameManager.gameStatus = GameStatus.gamePaused;
            Pausa.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && GameManager.gameStatus == GameStatus.gamePaused)
        {
            GameManager.gameStatus = GameStatus.gameRunning;
            Pausa.SetActive(false);
        }
    }

    public void Continua()
    {
        Pausa.SetActive(false);
        GameManager.gameStatus = GameStatus.gameRunning;
    }

    public void Ricomincia()
    {
        gameStatus = GameStatus.gameRunning;
        SceneManager.LoadScene("StartCanvas", LoadSceneMode.Single);
    }

    public void ComandiB()
    {
        Pausa.SetActive(false);
        Comandi.SetActive(true);
        opzioni = true;
    }

    public void ExitComandi()
    {
        Pausa.SetActive(true);
        Comandi.SetActive(false);
        opzioni = false;
    }



    

}
