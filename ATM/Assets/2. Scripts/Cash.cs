using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cashText;


    // Start is called before the first frame update
    void Start()
    {
        cashText = GetComponent<TextMeshProUGUI>();
        Debug.Log(GameManager.Instance);
        UpdateCash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCash()
    {
        cashText.text = string.Format("{0:N0}", GameManager.Instance.userData.cash);
    }
}
