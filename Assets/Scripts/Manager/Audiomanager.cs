using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static AudioSource cannone;
    public static AudioSource balestra;
    public static AudioSource catapulta;


    public AudioSource _cannone;
    public AudioSource _balestra;
    public AudioSource _catapulta;
    public AudioSource sottofondo;

    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm.gameStatus == GameManager.GameStatus.gameRunning)
        {   
            cannone = _cannone;
            balestra = _balestra;
            catapulta = _catapulta;
            sottofondo.Play();

        }
    }

}
