using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public static ShopItems shopItems;
    public Transform grid;
    public GameObject skinHolder;

    public List<SkinInfo> skinList = new List<SkinInfo>();
    public List<SpritesScripts> sprites = new List<SpritesScripts>();
    public List<Text> texts = new List<Text>();
    public List<SkinHolder> skinHolded = new List<SkinHolder>();
    public List<GameObject> buyButtonList = new List<GameObject>();



    public void FillList()
    {
        for (int i = 0; i < skinList.Count; i++)
        {
            GameObject skin = Instantiate(skinHolder, grid);
            SkinHolder skinHeld = skin.GetComponent<SkinHolder>();
            buyButtonList.Add(skinHeld.btnBuy);

            texts.Add(skinHeld.textField);

            skinHeld.textField.text = skinList[i].intPrice.ToString();
            skinHeld.skinImage.sprite = sprites[i].skinIcon;
            skinHeld.txtSkinName.text = skinList[i].strSkinName;
            skinHolded.Add(skinHeld);
            //skinHolded[i].textField.text = skinList[i].strPrice;
            //sprites[i].textField.text = skinList[i].values.ToString();
            //skinHolded[i].intValue = skinList[i].values;
            //SkinHolder.skinHolder.btnBuy;
            skinHeld.btnBuy.GetComponent<BuyButton>().skinID = skinList[i].skinID;
        }
    }

    public void UpdateTexts()
    {
        for (int i = 0; i < skinHolded.Count; i++)
        {

            if (skinList[i].isBought == true)
            {
                skinHolded[i].textField.text = "Bought";
            }
            else
            if (skinList[i].isBought == false)
            {
                skinHolded[i].intValue = skinList[i].intPrice;
            }

        }
    }






















    // Start is called before the first frame update
    void Start()
    {
        shopItems = this;
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateTexts();
    }
}
