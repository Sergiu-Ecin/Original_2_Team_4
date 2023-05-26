using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PallaDiCannone : MonoBehaviour
{
    bool dir_, stopLoock;
    [HideInInspector] public float parabolaZ, parabolaY, dirY, dirZ;
    float calcoloDisciesa;
    float timerParabola;
    Vector3 playerRef;
    GameManager gm;
    [HideInInspector] public float precisione;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").transform.position;

        dirY = parabolaY;
        dirZ = parabolaZ;
        calcoloDisciesa = parabolaY / 2f;
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm.gameStatus == GameManager.GameStatus.gameRunning)
            Caduta();
    }

    private void Caduta()
    {
        float distanzaMinima = Mathf.Infinity;
        float dist = Vector3.Distance(transform.position, playerRef);



        transform.Translate((Vector3.up * dirY + Vector3.forward * dirZ) * Time.deltaTime);

        if (dir_ == true)
        {
            dirY -= timerParabola * Time.deltaTime;
            if (stopLoock == false)
                transform.LookAt(playerRef);
        }


        if (dist < distanzaMinima)
        {
            if (transform.position.y > playerRef.y * 3.5f)
            {
                dir_ = true;
                timerParabola = calcoloDisciesa;
            }
            else if (transform.position.y < playerRef.y * precisione && dir_ == true)
            {
                stopLoock = true;
            }
            else if (transform.position.y < playerRef.y * 2 && dir_ == true)
            {
                timerParabola = calcoloDisciesa + 0.5f;
            }
        }

        if (-dirY < -parabolaY)
        {
            dirY = -parabolaY;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fortezza")
        {
            Destroy(gameObject);
        }

        //if (other.gameObject.tag =="Scudo")
        //{
        //    ShieldScript shield = other.GetComponent<ShieldScript>();
        //    if (shield != null)
        //    {
        //        shield.RimuoviVita(2);
        //    }

        //}    
    }

}
