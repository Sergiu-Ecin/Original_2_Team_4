using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;

    Player_Controller pC;
    void Start()
    {
        pC = FindObjectOfType<Player_Controller>();
    }

    void Update()
    {
        MoneyText.text = pC.money.ToString();
    }
}
