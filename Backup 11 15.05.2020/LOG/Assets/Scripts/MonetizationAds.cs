using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class MonetizationAds : MonoBehaviour
{
    private BannerView bannerView;


    //testBannerID = "ca-app-pub-3940256099942544/6300978111";
    //actualBannerID = "ca-app-pub-1353183405563614/9144686063";


    //void Awake()
    //{
    //    MobileAds.Initialize(appID);

    //}


    void RequestBannerAd()
    {
        string bannerID = "ca-app-pub-1353183405563614/9144686063";
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    void Start()
    {
        string appID = "ca-app-pub-1353183405563614~8214747771";

        this.RequestBannerAd();
    }
}
