Baidu Unity Plugin
Baidu Unity Plugin教程
==============================

Baidu Unity Plugin provides a way to integrate baidu ads in Unity3D Game and u3d app.
You can use it for Unity iOS and Android App with the same c# or js code.
Unity Baidu Plugin features include:
Baidu Unity 插件提供一种方法让unity 游戏和u3d应用能够在ios和android应用中通过相同代码使用baidu移动广告
通过js或者c#就可以给Unity应用加上Baidu广告功能。Unity Baidu Plugin包括下面各种特点：

* A single package with cross platform (Android/iOS) support
* Support for Baidu Banner Ads
* Support for Baidu Interstitial Ads
* Support all Baidu native events
* A sample project to demonstrate plugin integration
* Very simple API 

同时支持ios和android，一个包，一样的代码，无需关心平台
u3d baidu插件支持baidu横幅广告
u3d baidu插件支持baidu全屏广告
支持所有baidu原生的事件
包活一个简单的使用demo
接口非常的简单

BaiduUnityPlugin.unitypackage is the plugin  file for those that want to easily import
,baidudemo is a simple demo file how to use this plugin.
BaiduUnityPlugin.unitypackage 是Baidu Unity 插件文件，可以直接通过asset import进项目
baidudemo.cs  是Baidu 的ios sdk和插件使用样例代码，样例代码里面说明了怎么在代码里面使用Unity Baidu插件
Build base on 
------------
Baidu iOS SDK 3 ,android sdk 4
Baidu Unity插件是基于 baidu ios sdk 3和android 4编写，也就是最新的baidu sdk

Integrate the Baidu Unity3D Plugin into your Unity Game
-----------------------------------

1. Open your project in the Unity editor.
2. Navigate to **Assets -> Import Package -> Custom Package**.
3. Select the BaiduUnityPlugin.unitypackage file.
4. Import all of the files for the plugins by selecting **Import**. Make sure
   to check for any conflicts with files.

把Baidu Unity插件添加进unity工程
1. 打开Unity工程
2. 从菜单打开，Assets -> Import Package -> Custom Package.
3. 选中Unity插件文件BaiduUnityPlugin.unitypackage
4. 选择导入所有内容，把baidu unity插件内全部内容导入导unity工程

Run the project
---------------
编译运行工程项目

If you're running the **HelloWorld** sample project, you should be able to run
the project now.
如果你是运行测试工程，则可以直接进行编译运行了

To build and run on Android, click **File -> Build Settings**, select the
Android platform, then **Switch Platform**, then **Build and Run**.
编译和运行Unity android项目的方法是选择菜单 File -> Build Settings ，选择android平台，点击player set设置应用信息，选择Build and Run ，如果你的android设备连接到电脑了，等待一段时间后就app就会自动安装到手机并运行
To build and run on iOS, click **File -> Build Settings**, select the iOS
platform, then **Switch Platform**, then **Build**. This will export an
XCode project.You'll need to do the following before you can run it:
编译Unity项目到ios项目，选择菜单File -> Build Settings 选择ios平台，选择player settings设置平台属性，然后点击build
Unity项目将会被导出为ios工程。为了顺利编译ios项目，你需要对xcode工程进行下面的修改设置



Add the following framework to xcode project

    AdSupport.framework,CoreTelephony.framework,StoreKit.framework,MessageUI.framework

 把下面的frame 添加至项目

    AdSupport.framework,CoreTelephony.framework,StoreKit.framework,MessageUI.framework

Running the Unity Baidu Plugin demo code 
===========================
运行Unity Baidu Plugin demo项目

1. copy baidudemo.cs  to your unity project/assets dic
2. attach baidudemo.cs to the main camera
3. set the baidu id  in baidudemo.cs
4. build and run this in your device

1.把baidudemo.cs 复制到xcode 工程项目
2. 把baidudemo.cs 添加到main camera组件上（任何一直存在舞台上的组件都行）
3. 编辑baidudemo.cs设置baidu广告id
4. 编译apk或ipa，然后在设备上运行查看效果
Integrate  baidu into Unity3d tutorial
===========================
Unity 集成baidu 广告教程

The remainder of this guide assumes you are now attempting to write your own
code to integrate  Mobile Ads into your game.
下面是编写代码，假设你已经把baidu unity插件导入到unity项目中，并创建了一个脚本文件，下面以c#为例说明使用过程
Add Baidu Banner in Unity App 
-----------------
在Unity android和Unity iOS游戏里面集成baidu横幅广告
Here is the minimal code needed to create a banner.
下面是添加baidu横幅广告的代码
    using baidu;
    ...
    Baidu.Instance().initBaidu("app id", "banner id", "institial id", "video id");//id is got from ssp.baidu.com
    Baidu.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);

AdSize.Banner表示展示的广告尺寸，AdPosition.BOTTOM_CENTER表示横幅的放置位置，AdPosition里面包含各个广告位置常量，AdSize包含各个广告尺寸常量
The AdPosition class specifies where to place the banner. AdSize specifies witch size banner to show


How to integrate Interstitial into Unity 3d app?
-----------------------
怎么在Unity应用里面集成Baidu全屏广告？

Here is the minimal banner code to create an interstitial.
下面的Unity3d里面添加baidu广告的代码
    using baidu;
    ...
    Baidu.Instance().initBaidu("app id", "banner id", "institial id", "video id");//id is got from ssp.baidu.com
    Baidu.Instance().loadInterstitial(); 

Unlike banners, interstitials need to be explicitly shown. At an appropriate
stopping point in your app, check that the interstitail is ready before
showing it:
和横幅广告不同，全屏广告需要先加载，等加载完成后在合适的时间点展示广告

    if (Baidu.Instance().isInterstitialReady()) {
      Baidu.Instance().showInterstitial();
    }

Banner Placement Locations
--------------------------
横幅广告相对位置
The following constants list the available ad positions:
下面是所有支持的baidu横幅广告相对位置常量
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
Baidu横幅广告和全屏广告都有差不多的广告事件，你可以在unity3d里面监听并处理所有baidu广告事件
Here we'll demonstrate setting ad events on a interstitial,and show interstitial when load success:
下面是一个处理全屏广告事件的例子，我们在收到广告的时候就展示广告
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
你只需要关注你想处理的baidu广告事件，忽略掉不想关注的

Remove Banner 
----------------
By default, banners are visible. To temporarily hide a banner, call:
默认横幅广告展示后就一直是可见的，如果想隐藏广告那可以通过下面的方式进行
    Baidu.Instance().removeBanner();
Additional Resources
====================
其他资源
* [Baidu](https://ssp.baidu.com/)
* [Baidu Unity Plugin Home](https://github.com/unity-plugins/BaiDu-Unity-Plugin)

