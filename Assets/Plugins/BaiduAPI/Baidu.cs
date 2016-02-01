using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
namespace baidu
{
	public class Baidu {
        public delegate void BaiduEventHandler(string eventName, string msg);

        public event BaiduEventHandler bannerEventHandler;
        public event BaiduEventHandler interstitialEventHandler;
        public event BaiduEventHandler videoEventHandler;

		private static Baidu _instance;	
		private AndroidJavaObject jbaidu;
		public static Baidu Instance()
	    {
	        if(_instance == null)
	        {
	            _instance = new Baidu();
				_instance.preInitBaidu ();
	        }
	        return _instance;
	    }
        
       
        #if UNITY_IOS
        internal delegate void BaiduAdCallBack(string adtype, string eventName, string msg);
        private void preInitBaidu()
        {

        }
        [DllImport("__Internal")]
        private static extern void _kminitBaidu(string appid,string bannerid, string fullid,string videoid, BaiduAdCallBack callback);
        public void initBaidu(string appID,string bannerID, string fullID,string videoID)
        {
            _kminitBaidu(appID,bannerID, fullID,videoID, onBaiduEventCallBack);
        }

        [DllImport("__Internal")]
        private static extern void _kmshowBannerAbsolute(int width, int height, int x, int y);
        public void showBannerAbsolute(AdSize size, int x, int y)
        {
            _kmshowBannerAbsolute(size.Width, size.Height, x, y);
        }

        [DllImport("__Internal")]
        private static extern void _kmshowBannerRelative(int width, int height, int position, int marginY);
        public void showBannerRelative(AdSize size, int position, int marginY)
        {
            _kmshowBannerRelative(size.Width, size.Height, position, marginY);
        }

        [DllImport("__Internal")]
        private static extern void _kmremoveBanner();
        public void removeBanner()
        {
            _kmremoveBanner();
        }

        [DllImport("__Internal")]
        private static extern void _kmloadInterstitial();
        public void loadInterstitial()
        {
            _kmloadInterstitial();
        }

        [DllImport("__Internal")]
        private static extern bool _kmisInterstitialReady();
        public bool isInterstitialReady()
        {
            return _kmisInterstitialReady();
        }

        [DllImport("__Internal")]
        private static extern void _kmshowInterstitial();
        public void showInterstitial()
        {
            _kmshowInterstitial();
        }



         [DllImport("__Internal")]
        private static extern void _kmloadVideo();
        public void loadVideo()
        {
            _kmloadVideo();
        }

        [DllImport("__Internal")]
        private static extern bool _kmisVideoReady();
        public bool isVideoReady()
        {
            return _kmisVideoReady();
        }

        [DllImport("__Internal")]
        private static extern void _kmshowVideo();
        public void showVideo()
        {
            _kmshowVideo();
        }

        [MonoPInvokeCallback(typeof(BaiduAdCallBack))]
        public static void onBaiduEventCallBack(string adtype, string eventName, string msg)
        {
         //   Debug.Log("c# receive callback " + adtype + "  " + eventName + "  " + msg);
            if (adtype == "banner")
            {
                Baidu.Instance().bannerEventHandler(eventName, msg);
            }
            if (adtype == "interstitial")
            {
                Baidu.Instance().interstitialEventHandler(eventName, msg);
            }
            else if (adtype == "video")
            {
               Baidu.Instance().videoEventHandler(eventName, msg);
            }
        }
        
#elif UNITY_ANDROID
        private void preInitBaidu(){
			if (jbaidu == null) {
                AndroidJavaClass baiduUnityPluginClass = new AndroidJavaClass("com.baidu.plugin.BaiduUnityPlugin");
				jbaidu = baiduUnityPluginClass.CallStatic<AndroidJavaObject> ("getInstance");
                InnerBaiduListener innerlistener = new InnerBaiduListener();
                innerlistener.baiduInstance = this;
                jbaidu.Call("setListener", new BaiduListenerProxy(innerlistener));
			}
		}
		public void initBaidu(string appID,string bannerID,string fullID,string videoID){
			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject activy = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jbaidu.Call ("initBaidu", new object[]{activy,appID,bannerID,fullID,videoID});
		}
        public void showBannerRelative(AdSize size, int position,int marginY)
        {
            jbaidu.Call("showBannerRelative", new object[] { size.Width,size.Height,position,marginY});
		}
        public void showBannerAbsolute(AdSize size, int x, int y)
        {
            jbaidu.Call("showBannerAbsolute", new object[] { size.Width, size.Height,x,y });
        }
        public void removeBanner()
        {
            jbaidu.Call("removeBanner");
        }


        public void loadInterstitial()
        {
            jbaidu.Call("loadInterstitial");
        }
        public bool isInterstitialReady()
        {
            bool isReady = jbaidu.Call<bool>("isInterstitialReady");
            return isReady;
        }
        public void showInterstitial()
        {
            jbaidu.Call("showInterstitial");
        }

        public void loadVideo()
        {
            jbaidu.Call("loadVideo");
        }
        public bool isVideoReady()
        {
            bool isReady = jbaidu.Call<bool>("isVideoReady");
            return isReady;
        }
        public void showVideo()
        {
            jbaidu.Call("showVideo");
        }
       
        class InnerBaiduListener : IBaiduListener
        {
            internal Baidu baiduInstance;
            public void onBaiduEvent(string adtype, string eventName, string paramString)
            {
                if (adtype == "banner")
                {
                    baiduInstance.bannerEventHandler(eventName, paramString);
                }
                else if (adtype == "interstitial")
                {
                    baiduInstance.interstitialEventHandler(eventName, paramString);
                }
                else if (adtype == "video")
                {
                    baiduInstance.videoEventHandler(eventName, paramString);
                }
            }
        }
#else
        private void preInitBaidu()
        {
           
        }
        
        public void initBaidu(string appID,string bannerID, string fullID,string videoID)
        {
            Debug.Log("calling initBaidu");
        }

        
        public void showBannerAbsolute(AdSize size, int x, int y)
        {
            Debug.Log("calling showBannerAbsolute");
        }
        
        public void showBannerRelative(AdSize size, int position, int marginY)
        {
            Debug.Log("calling showBannerRelative");
        }

        
        public void removeBanner()
        {
            Debug.Log("calling removeBanner");
        }

        
        public void loadInterstitial()
        {
            Debug.Log("calling loadInterstitial");
        }

        
        public bool isInterstitialReady()
        {
            Debug.Log("calling isInterstitialReady");
        return false;
        }

        
        public void showInterstitial()
        {
            Debug.Log("calling showInterstitial");
        }
         public void loadVideo()
        {
            Debug.Log("calling loadVideo");
        }
        public bool isVideoReady()
        {
           Debug.Log("calling isVideoReady");
            return false;
        }
        public void showVideo()
        {
            Debug.Log("calling showVideo");
        }       
    #endif
    }
}
