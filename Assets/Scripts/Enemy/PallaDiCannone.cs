using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PallaDiCannone : MonoBehaviour
{
    bool dir_ = false;

    void Start()
    {

    }

    void Update()
    {
        Caduta();
    }

    float timer;
    bool stopLook;
    private void Caduta()
    {
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
        float distanzaMinima = Mathf.Infinity;
        float dist = Vector3.Distance(transform.position, playerRef.transform.position);


        if (dir_ == false)
        {
            transform.Translate((Vector3.up * 5 + Vector3.forward * 20) * Time.deltaTime);
        }
        else
        {
            if (stopLook == false)
                transform.LookAt(playerRef.transform.position);

            transform.Translate((Vector3.up * -5 + Vector3.forward * 20) * Time.deltaTime);
        }


        if (dist < distanzaMinima)
        {
            if (transform.position.y > playerRef.transform.position.y * 3)
                dir_ = true;

        }
        if (transform.position.y < 15 && dir_ == true)
        {
            stopLook = true;
        }

        timer += Time.deltaTime;
        if (timer > 10)
            Destroy(gameObject);

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
            Debug.Log("Colpito");
        }
    }

}
