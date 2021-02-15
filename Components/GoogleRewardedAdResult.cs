using System.Collections.Generic;

[System.Serializable]
public class GoogleRewardedAdResult : GameServiceResult
{
    public List<PlayerCurrency> updateCurrencies = new List<PlayerCurrency>();
    public List<PlayerStamina> updateStaminas = new List<PlayerStamina>();
}
