#include <iostream>
using namespace std;

extern "C" {

    struct TransmissionData{
        int a;
        char* b;
    };

    typedef void(*CallBack)(int num);
    CallBack cb;

    typedef void(*CallBack1)(const char* p);
    CallBack1 cb1;

    typedef void(*CallBack2)(TransmissionData transmissionData);
    CallBack2 cb2;

    void _CallNative(int num,CallBack cb){
        //::是C++的全局变量用的符号，相当于C#的this。
        ::cb = cb;
        ::cb(num);
    }

    void _CallNative1(const char* txt,CallBack1 cb){
        ::cb1 = cb;
        ::cb1(txt);
    }

    void _CallNative2(TransmissionData transmissionData,CallBack2 cb){
        ::cb2 = cb;
        ::cb2(transmissionData);
    }
}
