using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject Pausa;
    [SerializeField] public GameObject Comandi;
    //[SerializeField] public GameObject End;
    //[SerializeField] public GameObject GameOver;

    bool opzioni;
    private void Awake()
    {


    }
    private void Update()
    {
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
