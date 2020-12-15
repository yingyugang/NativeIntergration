using System;

namespace BlueNoah.NativeIntergrate
{
    public interface NativeInterface
    {
        void CallNative();

        void CallNative1();

        void CallNative2();

        void SetComplete(Action<string> onComplete);
    }

    public struct TransmissionData
    {
        public int a;
        public string b;

        public string GetStringData()
        {
            return $"a:{a},b:{b}";
        }
    }
}