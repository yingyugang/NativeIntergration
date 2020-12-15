package com.unity.intergration;

public class UnityIntergration {
    public void PluginMethod(IntergrationInterface intergrationInterface){
        intergrationInterface.Callback(123);
    }

    public void PluginMethod1(IntergrationInterface intergrationInterface){
        intergrationInterface.Callback("abcdefg");
    }

    public void PluginMethod2(IntergrationInterface intergrationInterface){
        NativeParameter nativeParameter = new NativeParameter();
        nativeParameter.a = 123;
        nativeParameter.b = "abcdefg";
        intergrationInterface.Callback(nativeParameter);
    }
}