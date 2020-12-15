using System;
using UnityEngine;

namespace BlueNoah.NativeIntergrate
{
    public class AndroidNative : NativeInterface
    {

        Action<string> onComplete;

        public void CallNative()
        {
            AndroidJavaObject pluginClass = new AndroidJavaObject("com.unity.intergration.UnityIntergration");
            var callback = new NativeCallback();
            callback.onCallback = onComplete;
            pluginClass.Call("PluginMethod", callback);
        }

        public void CallNative1()
        {
            AndroidJavaObject pluginClass = new AndroidJavaObject("com.unity.intergration.UnityIntergration");
            var callback = new NativeCallback();
            callback.onCallback = onComplete;
            pluginClass.Call("PluginMethod1", callback);
        }

        public void CallNative2()
        {
            AndroidJavaObject pluginClass = new AndroidJavaObject("com.unity.intergration.UnityIntergration");
            var callback = new NativeCallback();
            callback.onCallback = onComplete;
            pluginClass.Call("PluginMethod2", callback);

        }

        public void SetComplete(Action<string> onComplete)
        {
            this.onComplete = onComplete;
        }
    }

    public struct NativeParameters
    {
        public int a;
        public string b;

        public string GetStringData()
        {
            return $"a:{a},b:{b}";
        }
    }

    class NativeCallback : AndroidJavaProxy
    {

        public NativeCallback() : base("com.unity.intergration.IntergrationInterface") { }

        public Action<string> onCallback;

        public void Callback(string result)
        {
            onCallback?.Invoke(result);
        }

        public void Callback(int result)
        {
            onCallback?.Invoke(result.ToString());
        }

        public void Callback(AndroidJavaObject result)
        {
            var str = result.Call<string>("GetStringData");
            onCallback?.Invoke(str);
        }
    }
}
