using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PallaDiCannone : MonoBehaviour
{
    bool dir_ = false;
    float parabola = 5;
    float timer, timerParabola;
    bool stopLoock;

    void Update()
    {
        Caduta();
    }

    private void Caduta()
    {
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
        float distanzaMinima = Mathf.Infinity;
        float dist = Vector3.Distance(transform.position, playerRef.transform.position);
        Vector3 dir = transform.position - playerRef.transform.position;



        transform.Translate((Vector3.up * parabola + Vector3.forward * 5) * Time.deltaTime);

        if(dir_ == true)
        {
            parabola -= timerParabola * Time.deltaTime;
            if (stopLoock == false)
                transform.LookAt(playerRef.transform.position);
        }


        if (dist < distanzaMinima)
        {
            if (transform.position.y > playerRef.transform.position.y * 3.5f)
            {
                dir_ = true;
                timerParabola = 1;
            }
            else if (transform.position.y < playerRef.transform.position.y * 3 && dir_ == true)
            {
                stopLoock = true;
            }
            else if (transform.position.y < playerRef.transform.position.y * 2 && dir_ == true)
            {
                timerParabola = 1.5f;
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Colpito00");
        }
        if (other.gameObject.tag == "Fortezza")
        {
            Destroy(gameObject);
        }
    }

}
