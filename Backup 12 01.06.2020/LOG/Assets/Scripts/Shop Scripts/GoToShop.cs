using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class GoToShop : MonoBehaviour
{
    public static GoToShop goToShop;
    public Button shop;
    //public static SaveLoad saveLoad = new SaveLoad();
    public int numbre;



    public string text;
    public int numbers;

    public List<SkinInfo> shopList = new List<SkinInfo>();


    [System.Serializable]
    public class SaveData
    {
        public int money;
        public List<SkinInfo> shopList = new List<SkinInfo>();
        //public List<GameObject> buyButtonList = new List<GameObject>();
        public int currentSkinID;
        public int storeMoney;
    }



    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.money = ShopManager.shopManager.GetMoney();
        saveData.shopList.Clear();
        saveData.currentSkinID = ShopManager.shopManager.currentSkinID;
        saveData.storeMoney = ShopManager.shopManager.coinsInPurse;

        for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
        {
            saveData.shopList.Add(ShopItems.shopItems.skinList[i]);
        }

        PlayerPrefs.SetInt("prefCurrentID", ShopManager.shopManager.currentSkinID);


        //string text = SkinHolder.skinHolder.textField.text;
        //numbers = SkinInfo.values;
        string fileLocation = Application.persistentDataPath + "/save.oma";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(fileLocation, FileMode.Create);

        bf.Serialize(stream, saveData);
        stream.Close();

        Debug.Log("File is saved!");
    }



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



            ShopManager.shopManager.coinsInPurse = data.storeMoney;
            for (int i = 0; i < ShopItems.shopItems.skinList.Count; i++)
            {
                ShopItems.shopItems.skinList[i].intPrice = data.shopList[i].intPrice;
                ShopItems.shopItems.skinList[i].isBought = data.shopList[i].isBought;
                ShopManager.shopManager.currentSkinID = data.currentSkinID;
                ShopManager.shopManager.coinsInPurse = data.storeMoney;
                Debug.Log(data.storeMoney);
                //ShopItems.shopItems.UpdateTexts();

                if (data.shopList[i].isBought == true)
                {
                    ShopItems.shopItems.skinHolded[i].textField.text = "Bought";

                    if (data.shopList[i].skinID == ShopManager.shopManager.currentSkinID)
                    {
                        BuyButton buyButton = ShopItems.shopItems.buyButtonList[i].GetComponent<BuyButton>();
                        buyButton.txtButtonText.text = "Using";

                        //PlayerMove.playerMove.curentSkinIID = data.currentSkinID;
                        numbre = ShopManager.shopManager.currentSkinID;
                        ShopManager.shopManager.coinsInPurse = data.storeMoney;
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

    public async void GoShopping()
    {
        SceneManager.LoadScene("Store");
        //SaveLoad.saveLoad.Load();
        await Task.Delay(100);
        Load();
    }


    public async void GoToMainScreen()
    {
        Save();
        await Task.Delay(500);
        SceneManager.LoadScene("StartScreen");
    }



    // Start is called before the first frame update
    void Start()
    {
        //Button shopButton = shop.GetComponent<Button>();
        //shopButton.onClick.AddListener(GoShopping);

        goToShop = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
