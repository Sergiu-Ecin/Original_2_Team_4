using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyText;

    InventoryManager Im;
    void Start()
    {
        Im = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        MoneyText.text = Im.money.ToString();
    }
}
