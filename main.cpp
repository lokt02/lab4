#include <iostream>

#ifndef __wtypes_h__
#include <wtypes.h>
#endif

#ifndef __WINDEF_
#include <windef.h>
#endif

#include "SequenceSorter.h"

int main() {
    std::cout << "Hello, World!" << std::endl;
    int a;
    cin >> a;
    return 0;
}

extern "C" __declspec(dllexport) CHAR* LabFunc(){
    // string s1 = "Hello world!";
    return (char*)"Hello world!";
}
