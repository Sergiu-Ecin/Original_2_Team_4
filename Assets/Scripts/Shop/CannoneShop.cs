using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannoneShop : MonoBehaviour
{
    [SerializeField] float costo;
    [Tooltip("Scrivi una descrizione per l'arma")]
    [SerializeField] string cannone;
    [SerializeField] TextMeshProUGUI DesCannone;
    [SerializeField] GameObject CannoneText;
    public static GameObject _Text;

    public static float _costo;
    public static string _armi;
    public static TextMeshProUGUI _DesArmi;


    void Start()
    {
        _costo = costo;
        _Text = CannoneText;
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);

        DesCannone.text = cannone + _costo;
    }



}
