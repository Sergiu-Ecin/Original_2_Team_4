using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject Pausa;


    private void Awake()
    {


    }
    private void Update()
    {


        PausaOn();


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
}
