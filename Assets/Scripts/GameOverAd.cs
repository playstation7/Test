using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GameOverAd : MonoBehaviour
{

    private InterstitialAd interstitialAd;
    private string interstitialUniId = "####################################";
    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUniId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd() 
    {
        if (interstitialAd.IsLoaded()) 
        {
            interstitialAd.Show();
        }
    }
}
