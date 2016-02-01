using System;

namespace baidu
{
    // Interface for the methods to be invoked by the native plugin.
	internal interface IBaiduListener
    {
        void onBaiduEvent(string adtype,string eventName,string paramString);
    }
}
