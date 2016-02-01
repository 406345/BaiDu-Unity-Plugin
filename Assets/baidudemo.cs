using UnityEngine;
using System.Collections;
using baidu;
public class baidudemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Baidu.Instance().bannerEventHandler += onBannerEvent;
        Baidu.Instance().interstitialEventHandler += onInterstitialEvent;
        Baidu.Instance().videoEventHandler += onVideoEvent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 100, 60), "initbaidu")) {
            Baidu ad = Baidu.Instance();
             #if UNITY_IOS
            ad.initBaidu("app id", "banner id", "institial id", "video id");
            #else
            ad.initBaidu("app id", "banner id", "institial id", "video id");
            #endif
		}
        if (GUI.Button(new Rect(0, 100, 100, 60), "showInstitial"))
        {
            Baidu ad = Baidu.Instance();
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        if (GUI.Button(new Rect(0, 200, 100, 60), "showVideo"))
        {
            Baidu ad = Baidu.Instance();
            if (ad.isVideoReady())
            {
                ad.showVideo();
            }
            else
            {
                ad.loadVideo();
            }
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "showbanner"))
        {
            Baidu.Instance().showBannerRelative(AdSize.Banner320x50, AdPosition.BOTTOM_CENTER, 0);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "showbannerABS"))
        {
            Baidu.Instance().showBannerAbsolute(AdSize.Banner728x90, 0, 30);
        }
        if (GUI.Button(new Rect(240, 300, 100, 60), "hidebanner"))
        {
            Baidu.Instance().removeBanner();
        }
	}
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onBaiduEvent---" + eventName + "   " + msg);
        if (eventName == BaiduEvent.onAdLoaded)
        {
            Baidu.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onBaiduBannerEvent---" + eventName + "   " + msg);
    }
    void onVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onBaidu Video Event---" + eventName + "   " + msg);
    }
}
