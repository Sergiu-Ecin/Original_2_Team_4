using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTurretManager : MonoBehaviour
{
    InventoryManager iM;
    GameObject arm;
    bool off;
    void Start()
    {
        iM = FindObjectOfType<InventoryManager>();
    }


    void Update()
    {
        Debug.Log(InventoryManager.TypeArma);
        if (Input.GetKeyDown(KeyCode.L))
        {
            Destroy(arm);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && off == false)
        {
            arm = Instantiate(InventoryManager.TypeArma);
            arm.transform.position = transform.position;
            iM.RemoveArmi();
            off = true;
            Debug.Log("ciao");
        }
        if (other.gameObject.tag == "Torretta")
        {
            off = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            off = false;
        }
    }

}
