using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SelectSkinBall : MonoBehaviour
{
    //public GameObject PlayerToPlay;
    int price = 5;
    public Button SkinName;
    public Text PurseCoins;
    bool isBought = false;
    public static bool bought = false;
    public static Sprite spriteToSend;
    public Sprite spriteToReceive;
    public static int counter;
    //private PlayerPrefs IsBought;
    /*
     Button.name (Before buying the skin) - "Buy: <price>"
     Button.name (After buying the skin) - "Use skin"
     bool isBought - Flag to check if the skin is bought or not
         */

    void OnClickEvent()
    {
        int purse = Int32.Parse(PurseCoins.text);
        //int price = Int32.Parse(SkinPrice.text);
        //int counter = PlayerPrefs.GetInt("IsBought", 0);

        //If the item is not Bought and the coins are enough => Buy the skin
        if (purse >= price && isBought == false && counter < 1)
        {
            counter = 1;
            //The button changes its' text to "Bought"
            SkinName.GetComponentInChildren<Text>().text = "Bought";
            isBought = true;

            //This is done so the PlayerMove.cs could have access to bool variable
            if (isBought == true)
            {
                bought = true;
            }
            else
                bought = false;

            //The available coins are reduced
            purse = purse - price;
            PurseCoins.text = purse.ToString();

            //Send the new skin to PlayerMove.cs
            spriteToSend = spriteToReceive;
            PlayerMove.spriteToUse = spriteToReceive;

            //Store If the skin is available already
            PlayerPrefs.SetInt("IsBought", counter);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        counter = PlayerPrefs.GetInt("IsBought", 0);
        Button clickToBuy = SkinName.GetComponent<Button>();
        clickToBuy.GetComponentInChildren<Text>().text = "Buy: " + price;  
        clickToBuy.onClick.AddListener(OnClickEvent);


        if (counter > 0)
        {
           clickToBuy.GetComponentInChildren<Text>().text = "Bought";
            //Send the new skin to PlayerMove.cs
            spriteToSend = spriteToReceive;
            PlayerMove.spriteToUse = spriteToReceive;

        }
        
        Debug.Log("The counter is: " + counter);

    }

    // Update is called once per frame
    void Update()
    {
        //if (counter > 0)
        //{
        //    PlayerPrefs.SetInt("IsBought", counter);
        //}
    }
}
