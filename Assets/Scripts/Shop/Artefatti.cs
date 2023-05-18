using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Artefatti : MonoBehaviour
{
    Player_Controller pC;
    InventoryManager iM;

    [SerializeField] float costo;

    [Tooltip("Scrivi una descrizione per l'artefatto")]
    [SerializeField] string artefatto;

    [SerializeField] GameObject textArtefatto;
    [SerializeField] TextMeshProUGUI DesArtefatto;

    bool wait;
    
    void Start()
    {
        pC = FindObjectOfType<Player_Controller>();
        iM = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);

        Timer();
        Descrizione();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && pC.money >= costo && wait == false && iM.countArt > 0 && timer == false)
        {
            iM.Artefatti.Add(gameObject);
            pC.money -= costo;
            iM.AddArtefatto();
            iM.countArt--;
            timer = true;
        }
    }

    float time;
    bool timer;
    void Timer()
    {
        if(timer == true)
        {
            time += Time.deltaTime;
            if(time >= 1)
            {
                time = 0;
                timer = false;
            }
        }
    }



    void Descrizione()
    {
        DesArtefatto.text = artefatto + costo;

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                if (hit.collider.name == "Artefatto")
                    textArtefatto.SetActive(true);
                else
                    textArtefatto.SetActive(false);
            }

        }

    }
}
