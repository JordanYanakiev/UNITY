using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public int skinID;
    public Text buttonText;


    public void BuySkin()  //ON CLICK
    {
        if (skinID == 0)
        {
            Debug.Log("NO SKIN ID SET!!!");
            return;
        }
        
        for (int i = 0; i < ShopItems.skinShop.skinList.Count; i++)
        {
            if (ShopItems.skinShop.skinList[i].skinID == skinID &&
                ShopItems.skinShop.skinList[i].isBought == false &&
                ShopManager.shopManager.RequestMoney(ShopItems.skinShop.skinList[i].skinPrice) == true)
            {
                //BUY THE SKIN
                ShopItems.skinShop.skinList[i].isBought = true;
                ShopManager.shopManager.ReduceMoney(ShopItems.skinShop.skinList[i].skinPrice);
                UpdateBuyButton();

                //SET THE SkinID IN YOUR SYSTEM
                ShopManager.shopManager.currentSkinID = skinID;
                    

            }
            else
                if (ShopItems.skinShop.skinList[i].skinID == skinID &&
                ShopItems.skinShop.skinList[i].isBought == false &&
                ShopManager.shopManager.RequestMoney(ShopItems.skinShop.skinList[i].skinPrice) == false)
            {
                ShopItems.skinShop.skinList[i].isBought = false;
                Debug.Log("NOT ENOUGH MINERALS!");
            }
             else 
                if (ShopItems.skinShop.skinList[i].skinID == skinID &&
                ShopItems.skinShop.skinList[i].isBought == true)
            {
                Debug.Log("This item is already bought!");
                ShopManager.shopManager.currentSkinID = skinID;
                UpdateBuyButton();
            }
        }
    }

    public void UpdateBuyButton()
    {
        buttonText.text = "Using";

        //UPDATE THE BUTTONS THAT ARE ALREADY BOUGHT

        for(int i = 0; i < ShopItems.skinShop.buyButtonList.Count; i++)
        {
            BuyButton buyButtonScript = ShopItems.skinShop.buyButtonList[i].GetComponent<BuyButton>(); 
            
            for (int j = 0; j < ShopItems.skinShop.skinList.Count; j++)
            {
                //HAS BOUGHT SKIN MATCH 
                if(ShopItems.skinShop.skinList[j].skinID == buyButtonScript.skinID &&
                   ShopItems.skinShop.skinList[j].isBought == true &&
                   ShopItems.skinShop.skinList[j].skinID != skinID)
                {
                    buyButtonScript.buttonText.text = "Use";
                }

                
            }
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
