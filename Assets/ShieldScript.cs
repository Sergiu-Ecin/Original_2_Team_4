using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public int vitaMax = 10;
    private int vitaAttuale;

    [SerializeField] public GameObject shieldFull;
    [SerializeField] public GameObject shieldMid;
    [SerializeField] public GameObject shieldDown;

    // Start is called before the first frame update
    void Start()
    {
        shieldFull.SetActive(true);
        shieldMid.SetActive(false);
        shieldDown.SetActive(false);

        vitaAttuale = vitaMax;

        
    }

    // Update is called once per frame
    void Update()
    {
        

       
        
           
        
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    PlayerMovement player = other.GetComponent<PlayerMovement>();
    //    if (player != null)
    //    {
    //        RimuoviVita();
    //    }
    //}

    public void OnTriggerStay(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null && Input.GetKeyDown(KeyCode.N))
        {
            RimuoviVita();
            Debug.Log("Hai danneggiato");

        }
        if(player != null && Input.GetKeyDown(KeyCode.M))
        {
            Ripara();
            Debug.Log("Hai riparato");
        }
    }




    public void RimuoviVita()
    {
       
        
         vitaAttuale -= 2;

        if(vitaAttuale == 10)
        {
            shieldFull.SetActive(true);
            shieldMid.SetActive(false);
            shieldDown.SetActive(false);
            Debug.Log("La vita attuale è di: " +  vitaAttuale);
        }
        if (vitaAttuale == 4)
        {
            shieldFull.SetActive(false);
            shieldMid.SetActive(true);
            shieldDown.SetActive(false);
            Debug.Log("La vita attuale è di: " + vitaAttuale);
        }
        if(vitaAttuale <= 0)
        {
            shieldFull.SetActive(false);
            shieldMid.SetActive(false);
            shieldDown.SetActive(true);
            Debug.Log("La vita attuale è di: " + vitaAttuale);
        }
        
    }

    public void Ripara()
    {
        vitaAttuale += 5;

        if (vitaAttuale <= 0)
        {
            vitaAttuale += 5;
            shieldFull.SetActive(false);
            shieldMid.SetActive(true);
            shieldDown.SetActive(false);
            Debug.Log("Hai Curato di 5, la vita è di: " + vitaAttuale);
        }
        else if (vitaAttuale >= 4 && vitaAttuale < 10)
        {
            vitaAttuale += 5;
            shieldFull.SetActive(true);
            shieldMid.SetActive(false);
            shieldDown.SetActive(false);
            Debug.Log("Hai Curato di 5, la vita è di: " + vitaAttuale);
        }



    }

}
