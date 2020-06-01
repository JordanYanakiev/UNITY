using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public int money;
        public List<SkinInfo> shopList = new List<SkinInfo>();
        public List<GameObject> buyButtonList = new List<GameObject>();
        public int currentSkinID = ShopManager.shopManager.currentSkinID;
    }


    public static SaveLoad saveLoad;
    public string text;
    public int numbers;
    public int numbre;




    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.money = ShopManager.shopManager.GetMoney();
        saveData.shopList.Clear();

        for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
        {
            saveData.shopList.Add(ShopItems.shopItems.skinList[i]);
        }




        //string text = SkinHolder.skinHolder.textField.text;
        //numbers = SkinInfo.values;
        string fileLocation = Application.persistentDataPath + "/save.oma";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(fileLocation, FileMode.Create);

        bf.Serialize(stream, saveData);
        stream.Close();

        Debug.Log("File is saved!");
    }



    //public void Load()
    //{
    //    //string text = SkinHolder.skinHolder.textField.text;
    //    //numbers = SkinInfo.values;
    //    string fileLocation = Application.persistentDataPath + "/save.oma";




    //    if (File.Exists(fileLocation))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream stream = new FileStream(fileLocation, FileMode.Open);

    //        SaveData data = (SaveData)bf.Deserialize(stream);
    //        stream.Close();

    //        for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
    //        {
    //            ShopItems.shopItems.skinList[i].intPrice = data.shopList[i].intPrice;
    //            ShopItems.shopItems.skinList[i].isBought = data.shopList[i].isBought;
    //            ShopManager.shopManager.currentSkinID = data.currentSkinID;
    //            //ShopItems.shopItems.UpdateTexts();

    //            if (data.shopList[i].isBought == true)
    //            {
    //                ShopItems.shopItems.skinHolded[i].textField.text = "Boght";

    //                if (data.shopList[i].skinID == ShopManager.shopManager.currentSkinID)
    //                {
    //                    BuyButton buyButton = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();
    //                    buyButton.txtButtonText.text = "Using";
    //                }
    //                else
    //                {
    //                    BuyButton buyButton = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();
    //                    buyButton.txtButtonText.text = "Use";
    //                }
    //            }


    //        }
    //    }
    //}






    // Start is called before the first frame update


    public void Load()
    {
        //string text = SkinHolder.skinHolder.textField.text;
        //numbers = SkinInfo.values;
        string fileLocation = Application.persistentDataPath + "/save.oma";




        if (File.Exists(fileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(fileLocation, FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(stream);
            stream.Close();

            for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
            {
                ShopItems.shopItems.skinList[i].intPrice = data.shopList[i].intPrice;
                ShopItems.shopItems.skinList[i].isBought = data.shopList[i].isBought;
                ShopManager.shopManager.currentSkinID = data.currentSkinID;
                //ShopItems.shopItems.UpdateTexts();

                if (data.shopList[i].isBought == true)
                {
                    ShopItems.shopItems.skinHolded[i].textField.text = "Bought";

                    if (data.shopList[i].skinID == ShopManager.shopManager.currentSkinID)
                    {
                        BuyButton buyButton = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();
                        buyButton.txtButtonText.text = "Using";
                        //PlayerMove.playerMove.curentSkinIID = data.shopList[i].skinID;
                        numbre = ShopManager.shopManager.currentSkinID;
                    }
                    else
                    {
                        BuyButton buyButton = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();
                        buyButton.txtButtonText.text = "Use";
                    }
                }


            }
        }
    }
    void Start()
    {
        saveLoad = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
