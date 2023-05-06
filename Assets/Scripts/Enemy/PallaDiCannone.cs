using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaDiCannone : MonoBehaviour
{

   

    void Start()
    {
       
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Fortezza")
        {
            Destroy(gameObject);
        }
    }

}
