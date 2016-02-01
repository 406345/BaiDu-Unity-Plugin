using UnityEngine;
using System.Collections;
namespace baidu
{
	public class BaiduListenerProxy : AndroidJavaProxy {
		private IBaiduListener listener;
		internal BaiduListenerProxy(IBaiduListener listener)
            : base("com.baidu.plugin.IBaiduListener")
		{
			this.listener = listener;
		}
         void onBaiduEvent(string adtype,string eventName,string paramString){
         	 listener.onBaiduEvent(adtype,eventName,paramString);
         }
		string toString(){
			return "BaiduListenerProxy";
		}
	}
}
