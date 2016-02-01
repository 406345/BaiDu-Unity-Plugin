Baidu Unity Plugin
==============================

Baidu Unity Plugin provides a way to integrate baidu ads in Unity3D Game and u3d app.
You can use it for Unity iOS and Android App with the same c# or js code.
Unity Baidu Plugin features include:

* A single package with cross platform (Android/iOS) support
* Support for Baidu Banner Ads
* Support for Baidu Interstitial Ads
* Support all Baidu native events
* A sample project to demonstrate plugin integration
* Very simple API 

BaiduUnityPlugin.unitypackage is the plugin  file for those that want to easily import
,baidudemo.cs is  a simple demo file how to use this plugin.

Build base on 
------------
Baidu iOS SDK 3 ,android sdk 4


Integrate the Baidu Unity3D Plugin into your Unity Game
-----------------------------------

1. Open your project in the Unity editor.
2. Navigate to **Assets -> Import Package -> Custom Package**.
3. Select the BaiduUnityPlugin.unitypackage file.
4. Import all of the files for the plugins by selecting **Import**. Make sure
   to check for any conflicts with files.



Run the project
---------------

To build and run on Android, click **File -> Build Settings**, select the
Android platform, then **Switch Platform**, then **Build and Run**.

To build and run on iOS, click **File -> Build Settings**, select the iOS
platform, then **Switch Platform**, then **Build**. This will export an
XCode project. You'll need to do the following before you can run it:
 Add the following framework to xcode project

    AdSupport.framework,CoreTelephony.framework,StoreKit.framework,MessageUI.framework


Running the Unity Baidu Plugin demo code 
===========================

1. copy baidudemo.cs  to your unity project/assets dic
2. attach baidudemo.cs to the main camera
3. set the baidu id  in baidudemo.cs
4. build and run this in your device

Integrate  baidu into Unity3d tutorial
===========================

The remainder of this guide assumes you are now attempting to write your own
code to integrate  Mobile Ads into your game.

Add Baidu Banner in Unity App 
-----------------
Here is the minimal code needed to create a banner.

    using baidu;
    ...
    Baidu.Instance().initBaidu("app id", "banner id", "institial id", "video id");//id is got from ssp.baidu.com
    Baidu.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);

The AdPosition class specifies where to place the banner. AdSize specifies witch size banner to show


How to integrate Interstitial into Unity 3d app?
-----------------------
Here is the minimal banner code to create an interstitial.

    using baidu;
    ...
    Baidu.Instance().initBaidu("app id", "banner id", "institial id", "video id");//initBaidu just need call once,if you called when create banner ,you not need call any more
    Baidu.Instance().loadInterstitial(); 

Unlike banners, interstitials need to be explicitly shown. At an appropriate
stopping point in your app, check that the interstitail is ready before
showing it:

    if (Baidu.Instance().isInterstitialReady()) {
      Baidu.Instance().showInterstitial();
    }

Banner Placement Locations
--------------------------
The following constants list the available ad positions:

    AdPosition.TOP_LEFT
    AdPosition.TOP_CENTER
    AdPosition.TOP_RIGHT
    AdPosition.MIDDLE_LEFT
    AdPosition.MIDDLE_CENTER
    AdPosition.MIDDLE_RIGHT
    AdPosition.BOTTOM_LEFT
    AdPosition.BOTTOM_CENTER
    AdPosition.BOTTOM_RIGHT

Ad Events
---------
Both _Banner_ and _Interstitial_ contain the same ad events that you can
register for. 
Here we'll demonstrate setting ad events on a interstitial,and show interstitial when load success:

    using baidu;
    ...
    Baidu.Instance().interstitialEventHandler += onInterstitialEvent;
    ...
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onBaiduEvent---" + eventName + "   " + msg);
        if (eventName == BaiduEvent.onAdLoaded)
        {
            Baidu.Instance().showInterstitial();
        }
    }

You only need to register for the events you care about.
you can handler banner and video event as follow

	 Baidu.Instance().interstitialEventHandler += onInterstitialEvent;
        Baidu.Instance().videoEventHandler += onVideoEvent;

Remove Banner 
----------------
By default, banners are visible. To temporarily hide a banner, call:

    Baidu.Instance().removeBanner();

Additional Resources
====================
* [Baidu](https://apps.baidu.com/)
* [Baidu Unity Plugin Home](https://github.com/unity-plugins/Unity-Baidu)

