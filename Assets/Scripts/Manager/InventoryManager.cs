using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
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
    GameObject cannone, balestra, catapulta;
    [HideInInspector] public int countArmi = 4;
    public List<GameObject> ArmiLista = new List<GameObject>();
    int index = 4;
    int currentIndex;


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


    public void AddCannone()
    {
        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = cannone;
        }

        if (RayPlayerCamera.countType == 1)
        {
            cannone = Instantiate(Cannone, GridArmi.transform);
            ArmiLista.Add(cannone);
            countArmi--;
            Debug.Log(index);

        }
    }

    public void AddBalestra()
    {

        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = balestra;
        }

        if (RayPlayerCamera.countType == 2)
        {
            balestra = Instantiate(Balestra, GridArmi.transform);
            ArmiLista.Add(balestra);
            countArmi--;
        }
    }

    public void AddCatapulta()
    {
        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = catapulta;
        }

        if (RayPlayerCamera.countType == 3)
        {
            catapulta = Instantiate(Catapulta, GridArmi.transform);
            ArmiLista.Add(catapulta);
            countArmi--;
        }
    }

    public void RemoveArmi()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(ArmiLista[0]);
            ArmiLista.Remove(ArmiLista[0]);
            index--;
            countArmi++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(ArmiLista[1]);
            ArmiLista.Remove(ArmiLista[1]);
            index--;
            countArmi++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(ArmiLista[2]);
            ArmiLista.Remove(ArmiLista[2]);
            index--;
            countArmi++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Destroy(ArmiLista[3]);
            ArmiLista.Remove(ArmiLista[3]);
            index--;
            countArmi++;
        }
    }
}
