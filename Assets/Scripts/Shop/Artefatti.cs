using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefatti : MonoBehaviour
{
    Player_Controller pC;

    [SerializeField] float costo;
    bool wait;
    void Start()
    {
        pC = FindObjectOfType<Player_Controller>();
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);

        Descrizione();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && pC.money >= costo && wait == false)
        {
            InventoryManager.Artefatti.Add(gameObject);
            pC.money -= costo;
            Debug.Log(InventoryManager.Artefatti);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wait = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wait = false;
        }
    }


    void Descrizione()
    {

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                if (hit.collider.name == "Artefatto")
                    Debug.Log("Artefatto costo: " + costo);
            }
        }

    }
}
