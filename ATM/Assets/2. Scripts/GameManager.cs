using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }

    }
    public UserData userData;
    public AccountInfo accountInfo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            if (instance == this)
            {
                Destroy(gameObject);
            }
        }

    }

    public void SaveUserData()
    {
        if (userData != null)
        { 
            UserData existingUser = accountInfo.userDatas.Find(u => u.id == userData.id);
            if (existingUser != null)
            {
                existingUser.balance = userData.balance;
                existingUser.cash = userData.cash;
            }
        }

        string jsonData = JsonUtility.ToJson(accountInfo);
        string path = Path.Combine(Application.dataPath, "userData.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("저장 완료: " + jsonData);

    }

    public void LoadUserData()
    {
        string path = Path.Combine(Application.dataPath, "userData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            accountInfo = JsonUtility.FromJson<AccountInfo>(jsonData);

            if (accountInfo.userDatas == null)
            {
                accountInfo.userDatas = new List<UserData>();
            }
        }
        else
        {
            Debug.Log("파일 없음, 기본 데이터 생성");
            accountInfo = new AccountInfo();
        }
    }

    public UserData FindUserByName(string name)
    {
        return accountInfo.userDatas.FirstOrDefault(user => user.name == name);
    }

}