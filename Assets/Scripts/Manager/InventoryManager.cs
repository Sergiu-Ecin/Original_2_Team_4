using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{


    [Header("shop")]
    [SerializeField] public float money;

    [Header("Artefatto")]
    [SerializeField] GameObject GridArtefatto;
    [SerializeField] GameObject _Artefatto;
    [HideInInspector] public int countArt = 4;
    GameObject art1, art2, art3, art4;

    [Header("Armi")]
    [SerializeField] GameObject GridArmi;
    [SerializeField] GameObject Cannone, Balestra, Catapulta;
    [HideInInspector] public int countArmi = 4;
    public List<GameObject> ArmiLista = new List<GameObject>();
    int index;


    void Start()
    {

    }

    void Update()
    {
        RemoveArmi();
    }


    public void AddArtefatto()
    {
        if (countArt == 1)
        {
            art1 = Instantiate(_Artefatto, GridArtefatto.transform);
            countArt--;
        }
        if (countArt == 2)
        {
            art2 = Instantiate(_Artefatto, GridArtefatto.transform);
            countArt--;
        }
        if (countArt == 3)
        {
            art3 = Instantiate(_Artefatto, GridArtefatto.transform);
            countArt--;
        }
        if (countArt == 4)
        {
            art4 = Instantiate(_Artefatto, GridArtefatto.transform);
            countArt--;
        }
    }

    public void RemoveArtefatto()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (countArt == 0)
            {
                Destroy(art1);
                countArt++;
            }
            else if (countArt == 1)
            {
                Destroy(art2);
                countArt++;
            }
            else if (countArt == 2)
            {
                Destroy(art3);
                countArt++;
            }
            else if (countArt == 3)
            {
                Destroy(art4);
                countArt++;
            }
        }
    }


    public void AddArma()
    {
        if (RayPlayerCamera.TypeArma.name == "Cannone")
        {
            ArmiLista.Add(Cannone);
            ArmiLista[index] = Instantiate(Cannone, GridArmi.transform); 
            index++;
            countArmi--;

        }
        if (RayPlayerCamera.TypeArma.name == "Balestra")
        {
            ArmiLista.Add(Balestra);
            ArmiLista[index] = Instantiate(Balestra, GridArmi.transform);
            index++;
            countArmi--;
        }
        if (RayPlayerCamera.TypeArma.name == "Catapulta")
        {
            ArmiLista.Add(Catapulta);
            ArmiLista[index] = Instantiate(Catapulta, GridArmi.transform);
            index++;
            countArmi--;
        }
    }

    public void RemoveArmi()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ;
    }
}
