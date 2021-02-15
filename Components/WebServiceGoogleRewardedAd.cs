using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WebServiceClient))]
public class WebServiceGoogleRewardedAd : MonoBehaviour
{
    private WebServiceClient webServiceClient;
    public static WebServiceGoogleRewardedAd Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        webServiceClient = GetComponent<WebServiceClient>();
    }

    public void EarnedReward(string id, long amount, UnityAction<GoogleRewardedAdResult> onSuccess = null, UnityAction<string> onError = null)
    {
        var dict = new Dictionary<string, object>();
        dict["id"] = id;
        dict["amount"] = amount;
        GameInstance.GameService.HandleServiceCall();
        webServiceClient.PostAsDecodedJSON<GoogleRewardedAdResult>("google-rewarded-ad", (www, result) =>
        {
            if (result.Success)
            {
                PlayerCurrency.SetDataRange(result.updateCurrencies);
                PlayerStamina.SetDataRange(result.updateStaminas);
            }
            GameInstance.GameService.HandleResult(result, onSuccess, onError);
        }, dict);
    }
}
