using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TurnbaseRPG.Extensions.GoogleAds
{
    public class GoogleRewardedAd : MonoBehaviour
    {
        [System.Serializable]
        public class StringEvent : UnityEvent<string> { }

        [System.Serializable]
        public class EarnRewardEvent : UnityEvent<string, double> { }

        public RewardedAd RewardedAd { get; private set; }
        public string androidAdUnitId = "ca-app-pub-3940256099942544/5224354917";
        public string iosAdUnitId = "ca-app-pub-3940256099942544/1712485313";
        public UnityEvent onAdLoaded = new UnityEvent();
        public StringEvent onAdFailedToLoad = new StringEvent();
        public UnityEvent onAdOpening = new UnityEvent();
        public StringEvent onAdFailedToShow = new StringEvent();
        public EarnRewardEvent onAdEarnedReward = new EarnRewardEvent();
        public UnityEvent onAdClosed = new UnityEvent();

        private void Awake()
        {
            // Initial rewarded ad
            string adUnitId = androidAdUnitId;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                adUnitId = iosAdUnitId;
            RewardedAd = new RewardedAd(adUnitId);
            // Called when an ad request has successfully loaded.
            RewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
            // Called when an ad request failed to load.
            RewardedAd.OnAdFailedToLoad += RewardedAd_OnAdFailedToLoad;
            // Called when an ad is shown.
            RewardedAd.OnAdOpening += RewardedAd_OnAdOpening;
            // Called when an ad request failed to show.
            RewardedAd.OnAdFailedToShow += RewardedAd_OnAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            RewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward;
            // Called when the ad is closed.
            RewardedAd.OnAdClosed += RewardedAd_OnAdClosed;
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded ad with the request.
            RewardedAd.LoadAd(request);
        }

        public bool IsLoaded()
        {
            return RewardedAd.IsLoaded();
        }

        public void Show()
        {
            RewardedAd.Show();
        }

        private void RewardedAd_OnAdLoaded(object sender, System.EventArgs e)
        {
            onAdLoaded.Invoke();
        }

        private void RewardedAd_OnAdFailedToLoad(object sender, AdErrorEventArgs e)
        {
            onAdFailedToLoad.Invoke(e.Message);
        }

        private void RewardedAd_OnAdOpening(object sender, System.EventArgs e)
        {
            onAdOpening.Invoke();
        }

        private void RewardedAd_OnAdFailedToShow(object sender, AdErrorEventArgs e)
        {
            onAdFailedToShow.Invoke(e.Message);
        }

        private void RewardedAd_OnUserEarnedReward(object sender, Reward e)
        {
            WebServiceGoogleRewardedAd.Instance.EarnedReward(e.Type, (long)e.Amount, (result) =>
            {
                if (result.Success)
                    onAdEarnedReward.Invoke(e.Type, e.Amount);
            });
        }

        private void RewardedAd_OnAdClosed(object sender, System.EventArgs e)
        {
            onAdClosed.Invoke();
        }
    }
}