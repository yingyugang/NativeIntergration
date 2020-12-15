using UnityEngine;
using UnityEngine.UI;

namespace BlueNoah.NativeIntergrate
{
    public class SampleScene : MonoBehaviour
    {
        [SerializeField]
        Button btnInt;
        [SerializeField]
        Button btnString;
        [SerializeField]
        Button btnStruct;
        [SerializeField]
        Text txt;
        NativeInterface nativeInterface;

        void Awake()
        {
#if UNITY_EDITOR
            Debug.LogError("This RuntimePlatform is not supported. Only iOS and Android devices are supported.");
            Debug.LogError("请在Ios或者Android实机上面运行");
            Debug.LogError("エディターでサポートされていなかったので、端末で実行してください、");
            return;
#endif
#if UNITY_IOS
            nativeInterface = new iOSNative();
#elif UNITY_ANDROID
            nativeInterface = new AndroidNative();
#endif
            nativeInterface.SetComplete((string txt) =>
            {
                this.txt.text = txt;
            });

            btnInt.onClick.AddListener(() =>
            {
                nativeInterface.CallNative();
            });

            btnString.onClick.AddListener(() =>
            {
                nativeInterface.CallNative1();
            });

            btnStruct.onClick.AddListener(() =>
            {
                nativeInterface.CallNative2();
            });
        }
    }
}