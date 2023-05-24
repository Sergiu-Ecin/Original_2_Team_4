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
    GameObject artefatto;
    [HideInInspector] public int countArt = 4;
    public List<GameObject> ArtefattoLista = new List<GameObject>();
    int indexA = 4;

    [Header("Armi")]
    [SerializeField] GameObject GridArmi;
    [SerializeField] GameObject Cannone, Balestra, Catapulta;
    GameObject cannone, balestra, catapulta;
    [SerializeField] GameObject cannoneArma, balestraArma, catapultaArma;
    public static GameObject TypeArma;
    [HideInInspector] public int countArmi = 4;
    public List<GameObject> ArmiLista = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> ArmiListaObj = new List<GameObject>();
    int index;


    void Start()
    {

    }

    void Update()
    {
        Switch();
        // RemoveArmi();
    }

    bool remuve;
    public void AddArtefatto()
    {
        for (indexA = 0; indexA < ArtefattoLista.Count - 4; indexA++)
        {
            ArtefattoLista[0] = artefatto;
        }

        artefatto = Instantiate(_Artefatto, GridArtefatto.transform);
        ArtefattoLista.Add(artefatto);
        countArt--;

        if (countArt > 0)
        {
            remuve = true;
        }
        else if (countArt <= 0)
        {
            remuve = false;
        }

    }

    public void RemoveArtefatto()
    {
        if (remuve == true)
        {
            ArtefattoLista.Remove(ArtefattoLista[0]);
            Destroy(ArtefattoLista[0]);
            countArt++;
            indexA--;
        }
    }


    public void AddCannone()
    {
        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = cannoneArma;
            ArmiListaObj[0] = cannone;
        }

        if (RayPlayerCamera.countType == 1)
        {
            cannone = Instantiate(Cannone, GridArmi.transform);
            ArmiLista.Add(cannoneArma);
            ArmiListaObj.Add(cannone);
            countArmi--;
            Debug.Log("ciao" + ArmiLista[0]);
            Debug.Log(ArmiListaObj[0]);

        }
    }

    public void AddBalestra()
    {

        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = balestraArma;
            ArmiListaObj[0] = balestra;
        }

        if (RayPlayerCamera.countType == 2)
        {
            balestra = Instantiate(Balestra, GridArmi.transform);
            ArmiLista.Add(balestraArma);
            ArmiListaObj.Add(balestra);
            countArmi--;
        }
    }

    public void AddCatapulta()
    {
        for (index = 0; index < ArmiLista.Count - 4; index++)
        {
            ArmiLista[0] = catapultaArma;
            ArmiListaObj[0] = catapulta;
        }

        if (RayPlayerCamera.countType == 3)
        {
            catapulta = Instantiate(Catapulta, GridArmi.transform);
            ArmiLista.Add(catapultaArma);
            ArmiListaObj.Add(catapulta);
            countArmi--;
        }
    }

    public void RemoveArmi()
    {
        if (switchCount == 1)
        {
            index--;
            countArmi++;
            Debug.Log(TypeArma);
            Destroy(ArmiListaObj[0]);
            ArmiLista.Remove(ArmiLista[0]);
            ArmiListaObj.Remove(ArmiListaObj[0]);


        }

        if (switchCount == 2)
        {
            index--;
            countArmi++;

            Destroy(ArmiLista[1]);
            Destroy(ArmiListaObj[1]);
            ArmiLista.Remove(ArmiLista[1]);
            ArmiListaObj.Remove(ArmiListaObj[1]);

            Debug.Log(TypeArma);
        }

        if (switchCount == 3)
        {
            Destroy(ArmiLista[2]);

            index--;
            countArmi++;

            Destroy(ArmiLista[2]);
            Destroy(ArmiListaObj[2]);
            ArmiLista.Remove(ArmiLista[2]);
            ArmiListaObj.Remove(ArmiListaObj[2]);

        }

        if (switchCount == 4)
        {
            index--;
            countArmi++;

            Destroy(ArmiLista[3]);
            Destroy(ArmiListaObj[3]);
            ArmiLista.Remove(ArmiLista[3]);
            ArmiListaObj.Remove(ArmiListaObj[3]);

        }

    }

    int switchCount = 1;
    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            switchCount = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            switchCount = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            switchCount = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            switchCount = 4;
        }

        if (countArmi < 4 )
        {

            if (switchCount == 1)
            {
                TypeArma = ArmiLista[0];
            }

            if (switchCount == 2)
            {
                TypeArma = ArmiLista[1];
            }

            if (switchCount == 3)
            {
                TypeArma = ArmiLista[2];
            }

            if (switchCount == 4)
            {
                TypeArma = ArmiLista[3];
            }
        }
    }
}
