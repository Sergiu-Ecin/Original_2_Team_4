using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatapultaShop : MonoBehaviour
{
    [SerializeField] float costo;
    [Tooltip("Scrivi una descrizione per l'arma")]
    [SerializeField] string catapulta;
    [SerializeField] TextMeshProUGUI DesCatapulta;
    [SerializeField] GameObject CatapultaText;

    public static GameObject _Text;
    public static float _costo;
    public static string _armi;
    public static TextMeshProUGUI _DesArmi;

    void Start()
    {
        _costo = costo;
        _Text = CatapultaText;
    }

    void Update()
    {
        transform.Rotate(0, 2, 0);

        DesCatapulta.text = catapulta + _costo;
    }
}
