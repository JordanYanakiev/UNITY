using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public static BuyButton buyButtonScript;
    public int skinID;
    public string strBought = "Bought";
    public Text txtButtonText;




    public void BuySkin()
    {

        for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
        {
            if (ShopItems.shopItems.skinList[i].skinID == skinID &&
               ShopItems.shopItems.skinList[i].isBought == false)
            {
                if (ShopManager.shopManager.CheckCoins(ShopItems.shopItems.skinList[i].intPrice) == true)
                {
                    ShopItems.shopItems.skinList[i].isBought = true;
                    ShopItems.shopItems.skinList[i].strPrice = "Bought";
                    ShopItems.shopItems.skinHolded[i].textField.text = ShopItems.shopItems.skinList[i].strPrice;
                    ShopManager.shopManager.currentSkinID = skinID;
                    ShopManager.shopManager.ReduceCoins(ShopItems.shopItems.skinList[i].intPrice);

                    //Update coins after buying
                    int coinsUpdate = PlayerPrefs.GetInt("addCoins");
                    coinsUpdate -= ShopItems.shopItems.skinList[i].intPrice;
                    PlayerPrefs.SetInt("addCoins", coinsUpdate);
                    UpdateButtons();
                }
            }
            else
                if (ShopItems.shopItems.skinList[i].skinID == skinID &&
               ShopItems.shopItems.skinList[i].isBought == true)
            {
                ShopManager.shopManager.currentSkinID = skinID;
                UpdateButtons();

            }

        }


    }



    public void UpdateButtons()
    {

        for (int i = 0; i < ShopItems.shopItems.buyButtonList.Count; i++)
        {
            BuyButton buttonBuy = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();

            //Use the skin when you buy it Button.text = "Using"
            if (ShopItems.shopItems.skinList[i].skinID == skinID &&
                   ShopItems.shopItems.skinList[i].isBought == true /*&& ShopManager.shopManager.currentSkinID == skinID*/)
            {
                buttonBuy.txtButtonText.text = "Using";

            }
            else
                if (ShopItems.shopItems.skinList[i].skinID != skinID &&
                   ShopItems.shopItems.skinList[i].isBought == true /*&& ShopManager.shopManager.currentSkinID != skinID*/)
            {
                buttonBuy.txtButtonText.text = "Use";
            }

            //If the skin is bought, but is not in use and now you want to use it Button.text = "Using" 
            //And the rest buttons should be Button.text = "Use";

        }








    }























    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
