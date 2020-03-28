using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAds : MonoBehaviour
{
        private BannerView bannerView;

        public void Start()
        {
    #if UNITY_ANDROID
            string appId = "ca-app-pub-1353183405563614~8214747771";
    #elif UNITY_IPHONE
                string appId = "ca-app-pub-1353183405563614~8214747771";
    #else
                string appId = "unexpected_platform";
    #endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            this.RequestBanner();
        }

        private void RequestBanner()
        {
    #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-1353183405563614/9144686063";
    #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-1353183405563614/9144686063";
    #else
                string adUnitId = "unexpected_platform";
    #endif

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        }
}