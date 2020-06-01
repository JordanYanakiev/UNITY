using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;





[System.Serializable]
public class StartGameSkins
{
    public static StartGameSkins startGameSkins;

    public Sprite sprSkinImage;
    public int intSkinID;



    // Start is called before the first frame update
    void Start()
    {
        startGameSkins = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
