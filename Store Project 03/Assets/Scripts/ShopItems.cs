using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public static ShopItems skinShop;

    public List<Skins> skinList = new List<Skins>();

    public List<GameObject> buyButtonList = new List<GameObject>();

    public GameObject skinHolderPrefab;
    public Transform grid;


    public void FillList()
    {
        for (int i = 0; i < skinList.Count; i++)
        {
            GameObject skins = Instantiate(skinHolderPrefab, grid);
            SkinHolder skin = skins.GetComponent<SkinHolder>();


            //ADD BUTTONS
            buyButtonList.Add(skin.btnBuy);

            skin.skinName = skinList[i].skinName;
            skin.txtSkinPrice.text = "$ " + skinList[i].skinPrice.ToString();
            skin.skin.sprite = skinList[i].skin;

            //BUY BUTTON

            skin.btnBuy.GetComponent<BuyButton>().skinID = skinList[i].skinID;
        }
    }

    public void UpdateBuyButtons()
    {
        int currentSkinID = ShopManager.shopManager.currentSkinID;
        for (int i = 0; i < buyButtonList.Count; i++)
        {
            BuyButton buyButtonScript = buyButtonList[i].GetComponent<BuyButton>();

            for (int j = 0; j < skinList.Count; j++)
            {
                if (skinList[j].skinID == buyButtonScript.skinID && 
                    skinList[j].isBought == true && 
                    skinList[j].skinID != currentSkinID)
                {
                    buyButtonScript.buttonText.text = "Use";
                }
                else 
                    if (skinList[j].skinID == buyButtonScript.skinID &&
                    skinList[j].isBought == true &&
                    skinList[j].skinID == currentSkinID)
                {
                    buyButtonScript.buttonText.text = "Using";
                }
            }
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        skinShop = this;
        FillList();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
