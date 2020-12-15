package com.unity.intergration;

public class NativeParameter {
    public int a;
    public String b;
    public int GetA(){
        return a;
    }
    public String GetB(){
        return b;
    }
    public String GetStringData(){
        return "a:" + a + ";b:" + b;
    }
}
