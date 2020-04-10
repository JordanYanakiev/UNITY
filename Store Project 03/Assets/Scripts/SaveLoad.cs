using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public List<Skins> shopList = new List<Skins>();


    public void Save()
    {
        //Clear the List
        shopList.Clear();

        //Add the skins from the shop List
        for (int i = 0; i < ShopItems.skinShop.skinList.Count; i++)
        {
            shopList.Add(ShopItems.skinShop.skinList[i]);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/save.oma", FileMode.Create);

        bf.Serialize(stream, shopList);
        stream.Close();

        print("Pgress Saved!");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.oma"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "save.oma", FileMode.Open);

            shopList = (List<Skins>)bf.Deserialize(stream);
            stream.Close();

            //Load the information into the store
            for (int i = 0; i < shopList.Count; i++)
            {
                //Update the shop
                ShopItems.skinShop.skinList[i] = shopList[i];

                //Update the buttons
                ShopItems.skinShop.UpdateBuyButtons();
            }
        }
    }

    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/save.oma"))
        {
            File.Delete(Application.persistentDataPath + "/save.oma");
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
