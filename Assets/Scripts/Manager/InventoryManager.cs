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
    public static GameObject TypeArma;
    [HideInInspector] public int countArmi = 4;
    public List<GameObject> ArmiLista = new List<GameObject>();
    int index = 4;


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
        if (switchCount == 1)
        {
            index--;
            countArmi++;
            TypeArma = ArmiLista[0];
            Debug.Log(TypeArma);
            if (Input.GetKeyDown(KeyCode.L))
            {
                Destroy(ArmiLista[0]);
                ArmiLista.Remove(ArmiLista[0]);
            }

        }
        if (switchCount == 2)
        {
            index--;
            countArmi++;
            TypeArma = ArmiLista[1];
            if (Input.GetKeyDown(KeyCode.L))
            {
                Destroy(ArmiLista[1]);
                ArmiLista.Remove(ArmiLista[1]);
            }
            Debug.Log(TypeArma);
        }
        if (switchCount == 3)
        {
            Destroy(ArmiLista[2]);

            index--;
            countArmi++;
            TypeArma = ArmiLista[2];
            if (Input.GetKeyDown(KeyCode.L))
            {
                Destroy(ArmiLista[2]);
                ArmiLista.Remove(ArmiLista[2]);
            }
        }
        if (switchCount == 4)
        {
            index--;
            countArmi++;
            TypeArma = ArmiLista[3];
            if (Input.GetKeyDown(KeyCode.L))
            {
                Destroy(ArmiLista[3]);
                ArmiLista.Remove(ArmiLista[3]);
            }
        }

    }

    int switchCount;
    void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            switchCount = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            switchCount = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            switchCount = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            switchCount = 4;
    }
}
