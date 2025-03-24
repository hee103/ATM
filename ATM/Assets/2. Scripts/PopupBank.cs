using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{

    public Cash cashUI;
    public Balance balanceUI;
    public Name name;

    public GameObject atmBtn;
    public GameObject deposit;
    public GameObject withdraw;
    public GameObject send;
    public GameObject popup1;
    public GameObject popup2;
    public GameObject popupNull;
    public GameObject popupError;

    public TMP_InputField DepMoneyInput;
    public TMP_InputField WitMoneyInput;
    public TMP_InputField SendMoneyInput;
    public TMP_InputField sendToNameInput;
    private int money;

    private bool isDep = false;
    private bool isWit = false;

    public void Start()
    {
        GameManager.Instance.LoadUserData();
    }

    public void Refresh()
    {
        cashUI.UpdateCash();
        balanceUI.UpdateBalance();
        name.UpdateName();
    }

    public void ClickDepositBtn()
    {
        atmBtn.SetActive(false);
        deposit.SetActive(true);
        isDep = true;
    }

    public void ClickWithdrawBtn()
    {
        atmBtn.SetActive(false);
        withdraw.SetActive(true);
        isWit = true;
    }
    public void ClickSendMoneyBtn()
    {
        atmBtn.SetActive(false);
        send.SetActive(true);
    }

    public void Deposit(int amount)
    {
        if (GameManager.Instance.userData.cash >= amount) 
        {
            GameManager.Instance.userData.cash -= amount;
            GameManager.Instance.userData.balance += amount;
            GameManager.Instance.SaveUserData();
            Refresh(); 
        }
        else
        {
            popup1.SetActive(true);
        }
    }
   
    public void Withdraw(int amount)
    {
        if (GameManager.Instance.userData.balance >= amount) 
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.userData.cash += amount;
            GameManager.Instance.SaveUserData();
            Refresh(); 
        }
        else
        {
            Debug.Log("ffff");
            popup1.SetActive(true);
        }
    }
    public void SendMoney(string recipientName, int amount)
    {
        UserData sender = GameManager.Instance.userData;

        UserData recipient = GameManager.Instance.FindUserByName(recipientName);

        if (recipient == null)
        {
            popupNull.SetActive(true);
            return;
        }

        if (sender.balance >= amount)
        {
            sender.balance -= amount;
            recipient.balance += amount;

            GameManager.Instance.SaveUserData();
            Refresh();
        }
        else
        {
            popup1.SetActive(true); 
        }
    }
    public void SendMoneyButton()
    {
        string recipientName = sendToNameInput.text.Trim(); 
        bool isAmountValid = int.TryParse(SendMoneyInput.text, out money);

        if (string.IsNullOrEmpty(recipientName) || !isAmountValid)
        {
            popupError.SetActive(true);
            return;
        }

        SendMoney(recipientName, money);

        sendToNameInput.text = "";
        SendMoneyInput.text = "";
    }

    public void InputMoney()
    {
        if (int.TryParse(DepMoneyInput.text, out money) )
        {
            if (isDep)
            {
                Deposit(money);
                
            }

        }
        else if (int.TryParse(WitMoneyInput.text, out money))
        {
            if (isWit)
            {
                Withdraw(money);
                
            }
        }
        else if (int.TryParse(SendMoneyInput.text, out money))
        {
            SendMoney(sendToNameInput.text, money); 
        }

        else
        {
            popup2.SetActive(true);
        }


        DepMoneyInput.text = "";
        WitMoneyInput.text = "";
    }

    public void Popupclose()
    {
        popup1.SetActive(false);
        popup2.SetActive(false);
        popupNull.SetActive(false);
    }

    public void BackToMenu()
    {
        isDep = false;
        isWit = false;
        atmBtn.SetActive(true);
        deposit.SetActive(false);
        withdraw.SetActive(false);
        send.SetActive(false);
    }
}
