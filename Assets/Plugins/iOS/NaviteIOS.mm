#include <iostream>
using namespace std;

extern "C" {

    typedef void(*CallBack)(const char* p);
    CallBack cb;

    void _CallNative(const char* txt,CallBack1 cb1){
        ::cb = cb1;
        ::cb(txt);
    }

    typedef void(*CallBack1)(int num);
    CallBack cb1;

    void _CallNative(int num,CallBack1 cb1){
        //::是C++的全局变量用的符号，相当于C#的this。
        ::cb1 = cb;
        ::cb1(num);
    }
}
