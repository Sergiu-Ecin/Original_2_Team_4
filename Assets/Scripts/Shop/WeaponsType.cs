using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponsType : MonoBehaviour
{
    [SerializeField] float costo;
    [Tooltip("Scrivi una descrizione per l'arma")]
    [SerializeField] string armi;
    [SerializeField] TextMeshProUGUI DesArma;


    [Header("Cannon")]
    [SerializeField] bool _Cannon;

    [Header("Balestra")]
    [SerializeField] bool _Balestra;

    [Header("Catapulta")]
    [SerializeField] bool _Catapulta;


    public static float _costo;
    public static string _armi;
    public static TextMeshProUGUI _DesArmi;


    void Start()
    {
        if (_Cannon == true)
            CannoneType();
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);
       
        _DesArmi.text = _armi + _costo;
    }



    void CannoneType()
    {
        _costo = costo;
        _armi = armi;
        _DesArmi = DesArma;
    }

}
