using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Name : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameUI;
    private void Start()
    {
        nameUI = GetComponent<TextMeshProUGUI>();

        UpdateName();
    }
    public void UpdateName()
    {
        nameUI.text = GameManager.Instance.userData.name;
    }
}
