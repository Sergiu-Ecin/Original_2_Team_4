using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlayerCamera : MonoBehaviour
{
    InventoryManager iM;


    [SerializeField] GameObject TextShop;
    public static GameObject TypeArma;
    public static int countType;
    [HideInInspector] public bool wave;

    void Start()
    {
        iM = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (wave == false)
            ShopObj();
    }

    void ShopObj()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1.2f))
        {
            if (hit.transform != null)
            {
                if (hit.collider.name == "Artefatto")
                {
                    TextShop.SetActive(true);
                    Artefatti._ArtefattoText.SetActive(true);
                    CannoneShop._Text.SetActive(false);
                    BalestraShop._Text.SetActive(false);
                    CatapultaShop._Text.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.F) && iM.money >= Artefatti._costo && iM.countArt > 0)
                    {
                        iM.money -= Artefatti._costo;
                        iM.AddArtefatto();
                        Debug.Log("ciao");
                    }
                }
            }

            if (hit.collider.name == "CannoneShop")
            {
                TextShop.SetActive(true);
                CannoneShop._Text.SetActive(true);
                BalestraShop._Text.SetActive(false);
                CatapultaShop._Text.SetActive(false);
                Artefatti._ArtefattoText.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F) && iM.money >= CannoneShop._costo && iM.countArmi > 0)
                {
                    iM.money -= CannoneShop._costo;
                    countType = 1;
                    iM.AddCannone();
                }
            }

            if (hit.collider.name == "BalestraShop")
            {
                TextShop.SetActive(true);
                BalestraShop._Text.SetActive(true);
                Artefatti._ArtefattoText.SetActive(false);
                CannoneShop._Text.SetActive(false);
                CatapultaShop._Text.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F) && iM.money >= BalestraShop._costo && iM.countArmi > 0)
                {
                    iM.money -= BalestraShop._costo;
                    countType = 2;
                    iM.AddBalestra();
                }
            }

            if (hit.collider.name == "CatapultaShop")
            {
                TextShop.SetActive(true);
                CatapultaShop._Text.SetActive(true);
                Artefatti._ArtefattoText.SetActive(false);
                CannoneShop._Text.SetActive(false);
                BalestraShop._Text.SetActive(false);
                if (Input.GetKeyDown(KeyCode.F) && iM.money >= CatapultaShop._costo && iM.countArmi > 0)
                {
                    iM.money -= CatapultaShop._costo;
                    countType = 3;
                    iM.AddCatapulta();
                }
            }


        }
        else
        {
            TextShop.SetActive(false);
        }



    }
}
