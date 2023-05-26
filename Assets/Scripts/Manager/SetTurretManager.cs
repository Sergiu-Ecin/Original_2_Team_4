using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetTurretManager : MonoBehaviour
{
    InventoryManager iM;
    GameObject arm;
    public bool off;

    Rigidbody rb;
    void Start()
    {
        iM = FindObjectOfType<InventoryManager>();
    }


    void Update()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && off == false && iM.countArmi < 4)
        {
            arm = Instantiate(InventoryManager.TypeArma);
            arm.transform.position = transform.position;
            arm.transform.rotation = transform.rotation;
            InventoryManager.TypeArma = null;
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
