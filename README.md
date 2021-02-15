# unity-tbrpg-google-ads
Google Ads/Admob extensions for Turnbase RPG

## How to setup
* Import [Google Mobile Ad](https://github.com/googleads/googleads-mobile-unity/releases/) plugin.
* Extract this to to your Turnbase RPG project -> Assets folder (You may create subfolder before extracting into it).
* Attach `WebServiceGoogleRewardedAd` component to the same game object which attached `WebServiceClient`.
* Attach `GoogleRewardedAd` component to any game object in scene which have buttons to show ads, set its `androidAdUnitId`, `iosAdUnitId` and other events as you wish. Then set `Show` function to buttons.
* Set rewards in `GameDatabase` -> `GoogleAdRewards`, `Id` is name which you can set in dashboard -> app -> ad unit -> settings. After that export game data to your game service.