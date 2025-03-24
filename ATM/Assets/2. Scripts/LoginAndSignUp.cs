using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoginAndSignUp : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField pw;
    public TMP_InputField newID;
    public TMP_InputField newName;
    public TMP_InputField newPW;
    public TMP_InputField newPWConfirm;

    public GameObject popupLogin;
    public GameObject popupSign;
    public GameObject popupBank;
    public GameObject popupError;

    public void Login()
    {
        GameManager.Instance.LoadUserData(); 

        string inputID = id.text;
        string inputPW = pw.text;

        UserData user = GameManager.Instance.accountInfo.userDatas.Find(u => u.id == inputID && u.password == inputPW);

        if (user != null)
        {
            GameManager.Instance.userData = user;
            popupLogin.SetActive(false);
            popupBank.SetActive(true);
        }
        else
        {
            popupError.SetActive(true);
        }
    }

    public void SignUpBtn()
    {
        popupSign.SetActive(true);
    }

    public void SignUp()
    {
        string inputID = newID.text;
        string inputName = newName.text;
        string inputPW = newPW.text;
        string inputPWConfirm = newPWConfirm.text;

        if (!string.IsNullOrEmpty(inputID) && !string.IsNullOrEmpty(inputName) && !string.IsNullOrEmpty(inputPW) && !string.IsNullOrEmpty(inputPWConfirm))
        {
            if (inputPW == inputPWConfirm)
            {
                GameManager.Instance.LoadUserData(); 

                UserData newUser = new UserData(inputID, inputPW, inputName, 50000, 100000);
                GameManager.Instance.accountInfo.userDatas.Add(newUser);
                GameManager.Instance.SaveUserData();

                Debug.Log("회원가입 성공");
                popupSign.SetActive(false);
            }
            else
            {
                Debug.Log("비밀번호가 일치하지 않습니다.");
                popupError.SetActive(true);
            }
        }
        else
        {
            popupError.SetActive(true);
        }
    }
    public void OkBtn()
    {
        popupError.SetActive(false);
    }
    public void CancelBtn()
    {
        popupSign.SetActive(false);
    }
}
