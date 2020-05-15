using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUpdate : MonoBehaviour
{
    Text res;


    // Start is called before the first frame update
    void Start()
    {
        res = GetComponent<Text>();
        res.text = "Score: " + 0 ;
        
    }

    // Update is called once per frame
    void Update()
    {
        res.text = "Score: " + PlayerMove.result;
    }
}
