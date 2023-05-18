using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> Artefatti = new List<GameObject>();
    public List<GameObject> Torrette = new List<GameObject>();


    [SerializeField] GameObject Artefatto;
    [SerializeField] GameObject GridArtefatto;


    [SerializeField] public int countArt;
    void Start()
    {

    }

    void Update()
    {

    }


    public void AddArtefatto()
    {
       var art = Instantiate(Artefatto, GridArtefatto.transform);
        art.name = "Artefatto";
    }

}
