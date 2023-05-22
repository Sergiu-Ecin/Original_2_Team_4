using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalestraShop : MonoBehaviour
{
    [SerializeField] float costo;
    [Tooltip("Scrivi una descrizione per l'arma")]
    [SerializeField] string balestra;
    [SerializeField] TextMeshProUGUI DesBalestra;
    [SerializeField] GameObject BalestraText;

    public static GameObject _Text;
    public static float _costo;
    public static string _armi;
    public static TextMeshProUGUI _DesArmi;


    void Start()
    {
        _costo = costo;
        _Text = BalestraText;
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);

        DesBalestra.text = balestra + _costo;
    }



}
