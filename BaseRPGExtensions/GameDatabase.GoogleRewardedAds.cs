using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameDatabase
{
    [System.Serializable]
    public struct GoogleAdRewards
    {
        public string id;
        public int rewardSoftCurrency;
        public int rewardHardCurrency;
        public int rewardStageStamina;
        public int rewardArenaStamina;

        public string ToJson()
        {
            return "{\"id\":\"" + id + "\"," +
                "\"rewardSoftCurrency\":" + rewardSoftCurrency + "," +
                "\"rewardHardCurrency\":" + rewardHardCurrency + "," +
                "\"rewardStageStamina\":" + rewardStageStamina + "," +
                "\"rewardArenaStamina\":" + rewardArenaStamina + "}";
        }
    }

    [Header("Google Ad Rewards")]
    public GoogleAdRewards[] googleAdRewards;

    [DevExtMethods("AddExportingData")]
    public void AddExportingData(Dictionary<string, string> keyValues)
    {
        string json = string.Empty;
        foreach (var entry in googleAdRewards)
        {
            if (!string.IsNullOrEmpty(json))
                json += ",";
            json += entry.ToJson();
        }
        json = "[" + json + "]";

        keyValues["googleAdRewards"] = json;
    }
}
