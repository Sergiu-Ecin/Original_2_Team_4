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

    [SerializeField] float buffDanno;
    [SerializeField] float buffShootingPower;
    [SerializeField] float buffCooldownShoot;

    public static float _buffDanno;
    public static float _buffShootingPower;
    public static float _buffCooldownShoot;

    void Start()
    {
        _costo = costo;
        _ArtefattoText = ArtefattoText;
        _buffDanno = buffDanno;
        _buffCooldownShoot = buffCooldownShoot;
        _buffShootingPower = buffShootingPower;

        void Update()
        {
            transform.Rotate(0, 2, 0);
            DesArtefatto.text = artefatto + costo;
        }

    }
}
