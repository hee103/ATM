using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI balance;


    void Start()
    {
        balance = GetComponent<TextMeshProUGUI>();

        UpdateBalance();
    }
    private void Update()
    {
        
    }

    public void UpdateBalance()
    {
        balance.text = string.Format("{0:N0}", GameManager.Instance.userData.balance);
    }
}
