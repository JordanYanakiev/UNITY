using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager shopManager;
    public Text txtCoins;
    public int coinsInPurse;
    public int currentSkinID;

    public async void PurseCoins()
    {
        await Task.Delay(100);
        coinsInPurse = PlayerPrefs.GetInt("addCoins");
        txtCoins.text = "Coins: " + coinsInPurse.ToString();
    }


    public void AddCoins()
    {

    }


    public void ReduceCoins(int price)
    {
        int coins = coinsInPurse;
        coins -= price;
        coinsInPurse = coins;
        txtCoins.text = "Coins: " + coins.ToString();
    }

    public bool CheckCoins(int price)
    {
        if (price <= coinsInPurse)
        {
            return true;
        }
        return false;
    }

    public int GetMoney()
    {
        return coinsInPurse;
    }

    // Start is called before the first frame update
    void Start()
    {
        shopManager = this;
        PurseCoins();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
