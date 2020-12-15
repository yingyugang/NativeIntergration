package com.unity.intergration;

public interface IntergrationInterface {
    void Callback(int result);
    void Callback(String result);
    void Callback(NativeParameter nativeParameter);
}
