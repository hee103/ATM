using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class UserData
{
    public string id;
    public string password;
    public string name;
    public int balance;
    public int cash;
   

    public UserData(string id, string password, string name, int balance, int cash)
    {
        this.id = id;
        this.password = password;
        this.name = name;
        this.balance = balance;
        this.cash = cash;
    }
}

[Serializable]
public class AccountInfo
{
    public List<UserData> userDatas = new List<UserData>();
}