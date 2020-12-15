using System;
using System.Runtime.InteropServices;
using AOT;

namespace BlueNoah.NativeIntergrate
{
    public class iOSNative : NativeInterface
    {
        static Action<string> onComplete;

        [DllImport("__Internal")]
        private static extern void _CallNative(int num, CallBack callBack);

        [DllImport("__Internal")]
        private static extern void _CallNative1(string txt, CallBack callBack);

        [DllImport("__Internal")]
        private static extern void _CallNative2(TransmissionData transmissionData, CallBack callBack);

        delegate void CallBack(IntPtr param);

        [MonoPInvokeCallback(typeof(CallBack))]
        static void CallBackFunc(IntPtr param)
        {
            string path = Marshal.PtrToStringAuto(param);
            onComplete?.Invoke(path);
        }

        [MonoPInvokeCallback(typeof(CallBack))]
        static void CallBackFunc1(IntPtr param)
        {
            var num = Marshal.ReadInt32(param);
            onComplete?.Invoke(num.ToString());
        }

        [MonoPInvokeCallback(typeof(CallBack))]
        static void CallBackFunc2(IntPtr param)
        {
            var transmissionData = Marshal.PtrToStructure<TransmissionData>(param);
            onComplete?.Invoke(transmissionData.GetStringData());
        }

        public void SetComplete(Action<string> onComplete)
        {
            iOSNative.onComplete = onComplete;
        }

        public void CallNative()
        {
            _CallNative(123, CallBackFunc);
        }

        public void CallNative1()
        {
            _CallNative("abcdefg", CallBackFunc1);
        }

        public void CallNative2()
        {
            var transmissionData = new TransmissionData() { a = 1, b = "aaabbbccc" };
            _CallNative(transmissionData, CallBackFunc2);
        }
    }
}
