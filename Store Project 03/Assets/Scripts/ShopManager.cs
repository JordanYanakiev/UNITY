using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager shopManager;
    [SerializeField] private int money;
    public Text txtMoney;
    public int currentSkinID = 0;


    public void AddMoney (int amount)
    {
        money += amount;
        UpdateUI();

    }


    public void ReduceMoney(int amount)
    {
        money -= amount;
        UpdateUI();

    }

    public bool RequestMoney (int amount)
    {
        if (money >= amount)
        {
            return true;
        }

        else

        if (amount > money)
        {
          return false;
        }

        return false;
    }

    public void UpdateUI()
    {
        txtMoney.text = "Coins: " + money.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        shopManager = this;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
