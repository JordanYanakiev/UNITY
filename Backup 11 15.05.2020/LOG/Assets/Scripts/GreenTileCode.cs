using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTileCode : MonoBehaviour
{
    bool playerEnter = false;

   
    private void OnCollisionEnter2D (Collision2D colin)
    {

       //Debug.Log("Green Tile Hit!");
       
        //playerEnter = true;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        playerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerEnter == true)
        //{
        //    Debug.Log("You hit green!");
        //}

    }
}
