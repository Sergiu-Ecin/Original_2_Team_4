using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float vitaMax = 10;
    private float vitaAttuale;
    [SerializeField] float costoMet‡Vita;
    [SerializeField] float costoFullVita;
    bool rotto;

    [SerializeField] public GameObject shieldFull;
    [SerializeField] public GameObject shieldMid;
    [SerializeField] public GameObject shieldDown;

    InventoryManager iM;
    // Start is called before the first frame update
    void Start()
    {
        shieldFull.SetActive(true);
        shieldMid.SetActive(false);
        shieldDown.SetActive(false);

        vitaAttuale = vitaMax;

        iM = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {






    }

    private void OnMouseOver()
    {
        if (rotto == true && Input.GetKeyDown(KeyCode.E))
        {
            Ripara();
            vitaAttuale += 5f;
            Debug.Log("Hai riparato");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAmmo" && rotto == false)
        {
            RimuoviVita();
            Destroy(other.gameObject);
            Debug.Log("Scudo danneggiato");


        }
    }



    public void RimuoviVita()
    {


        vitaAttuale -= 2;

        if (vitaAttuale == 10)
        {
            shieldFull.SetActive(true);
            shieldMid.SetActive(false);
            shieldDown.SetActive(false);
            Debug.Log("La vita attuale Ë di: " + vitaAttuale);
        }
        if (vitaAttuale == 4)
        {
            shieldFull.SetActive(false);
            shieldMid.SetActive(true);
            shieldDown.SetActive(false);
            Debug.Log("La vita attuale Ë di: " + vitaAttuale);
        }
        if (vitaAttuale <= 0)
        {
            shieldFull.SetActive(false);
            shieldMid.SetActive(false);
            shieldDown.SetActive(true);
            rotto = true;
            Debug.Log("La vita attuale Ë di: " + vitaAttuale);
        }

    }

    public void Ripara()
    {


        if (vitaAttuale > 0 && iM.money >= costoMet‡Vita)
        {
            iM.money -= costoMet‡Vita;
            shieldFull.SetActive(false);
            shieldMid.SetActive(true);
            shieldDown.SetActive(false);
            Debug.Log("Hai Curato di 5, la vita Ë di: " + vitaAttuale);
        }
        if (vitaAttuale > 5 && vitaAttuale <= 10 && iM.money >= costoFullVita)
        {
            iM.money -= costoFullVita;
            shieldFull.SetActive(true);
            shieldMid.SetActive(false);
            shieldDown.SetActive(false);
            rotto = false;
            Debug.Log("Hai Curato di 5, la vita Ë di: " + vitaAttuale);
        }



    }

}
