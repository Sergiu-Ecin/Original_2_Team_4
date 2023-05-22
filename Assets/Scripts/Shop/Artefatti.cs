using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Artefatti : MonoBehaviour
{

    [SerializeField] float costo;
    public static float _costo;

    [Tooltip("Scrivi una descrizione per l'artefatto")]
    [SerializeField] string artefatto;

    [SerializeField] TextMeshProUGUI DesArtefatto;

    [SerializeField] GameObject ArtefattoText;
    public static GameObject _ArtefattoText;

    void Start()
    {
        _costo = costo;
        _ArtefattoText = ArtefattoText;
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);
        DesArtefatto.text = artefatto + costo;
    }

}
