using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlayerCamera : MonoBehaviour
{
    Player_Controller pC;
    InventoryManager iM;


    [SerializeField] GameObject TextShop;
    public static GameObject TypeArma;

    void Start()
    {
        pC = FindObjectOfType<Player_Controller>();
        iM = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        ShopObj();
    }

    void ShopObj()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.transform != null)
            {
                if (hit.collider.name == "Artefatto")
                {
                    TextShop.SetActive(true);
                    
                    if (Input.GetKeyDown(KeyCode.F) && iM.money >= Artefatti._costo && iM.countArt > 0)
                    {
                        iM.money -= Artefatti._costo;
                        iM.AddArtefatto();
                    }
                }
            }

            if (hit.collider.name == "CannoneShop")
            {
                TextShop.SetActive(true);
                WeaponsType._DesArmi.text = WeaponsType._armi + WeaponsType._costo;
                if (Input.GetKeyDown(KeyCode.F) && iM.money >= WeaponsType._costo && iM.countArmi > 0)
                {
                    iM.money -= WeaponsType._costo;
                    iM.AddArma();
                }
            }

        }
        else
            TextShop.SetActive(false);

    }
}
