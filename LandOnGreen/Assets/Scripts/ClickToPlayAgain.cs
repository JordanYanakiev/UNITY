using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine;

public class ClickToPlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    public Button playAgain;
    string appID = "ca-app-pub-1353183405563614~8214747771";

    //private void Awake()
    //{
    //    MobileAds.Initialize(appID);
    //}
    


    void TaskOnClick()
    {
        SceneManager.LoadScene("ActualGame");
        PlayerMove.result = 0;
    }
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        Button play = playAgain.GetComponent<Button>();
        play.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
