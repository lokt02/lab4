#include <iostream>

#ifndef __wtypes_h__
#include <wtypes.h>
#endif

#ifndef __WINDEF_
#include <windef.h>
#endif

#include <random>
#include "SequenceSorter.h"
#include "ListSequence.h"
#include "ArraySequence.h"
#include <string>
#include <cstring>

//int main() {
//    std::cout << "Hello, World!" << std::endl;
//    int a;
//    cin >> a;
//    return 0;
//}

template<class T>
string DisplaySequence(Sequence<T>* sequence){
    string output;
    for(int i = 0; i < sequence->GetLength(); i++){
        output += to_string(sequence->Get(i));
    }
    return output;
}

ArraySequence<int>* arr1;
ArraySequence<float>* arr2;
ListSequence<int>* list1;
ListSequence<float>* list2;

extern "C" __declspec(dllexport) void AppendIntArray(int item) {
    arr1->Append(item);
}
extern "C" __declspec(dllexport) void AppendFloatArray(float item) {
    arr2->Append(item);
}
extern "C" __declspec(dllexport) void AppendIntList(int item) {
    list1->Append(item);
}
extern "C" __declspec(dllexport) void AppendFloatList(float item) {
    list2->Append(item);
}

extern "C" __declspec(dllexport) CHAR* InitIntArray() {
    string message = "Integer array initialized";
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    delete arr1;
    arr1 = new ArraySequence<int>();

    return c;
}
extern "C" __declspec(dllexport) CHAR* InitFloatArray() {
    string message = "Float array initialized";
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    delete arr2;
    arr2 = new ArraySequence<float>();
    return c;
}
extern "C" __declspec(dllexport) CHAR* InitIntList() {
    string message = "Integer list initialized";
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    delete list1;
    list1 = new ListSequence<int>();
    return c;
}
extern "C" __declspec(dllexport) CHAR* InitFloatList() {
    string message = "Float list initialized";
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    delete list2;
    list2 = new ListSequence<float>();
    return c;
}

extern "C" __declspec(dllexport) CHAR* RandomIntArray(size_t length) {
    delete arr1;
    arr1 = new ArraySequence<int>();

    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dist(-1000, 1000);
    for(size_t i = 0; i < length; i++){
        arr1->Append(dist(gen));
    }

    string message = DisplaySequence(arr1);
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    return c;

}
extern "C" __declspec(dllexport) CHAR* RandomFloatArray(size_t length) {
    delete arr2;
    arr2 = new ArraySequence<float>();

    random_device rd;
    mt19937 gen(rd());
    uniform_real_distribution<> dist(-1000, 1000);
    for(size_t i = 0; i < length; i++){
        arr2->Append((float)dist(gen));
    }

    string message = DisplaySequence(arr2);
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    return c;
}
extern "C" __declspec(dllexport) CHAR* RandomIntList(size_t length) {
    delete list1;
    list1 = new ListSequence<int>();

    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dist(-1000, 1000);
    for(size_t i = 0; i < length; i++){
        list1->Append(dist(gen));
    }

    string message = DisplaySequence(list1);
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    return c;
}
extern "C" __declspec(dllexport) CHAR* RandomFloatList(size_t length) {
    delete list2;
    list2 = new ListSequence<float>();

    random_device rd;
    mt19937 gen(rd());
    uniform_real_distribution<> dist(-1000, 1000);
    for(size_t i = 0; i < length; i++){
        list2->Append((float)dist(gen));
    }

    string message = DisplaySequence(list2);
    char *c = nullptr;
    message.copy(c, message.size() + 1);
    return c;
}

extern "C" __declspec(dllexport) void SortIntArray(size_t sort_method, size_t sort_type) {
    switch(sort_method){
        case 0:
            switch(sort_type){
                case 0:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::BubbleSort((Sequence<int>*)(arr1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::BubbleSort((Sequence<int>*)(arr1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 1:
            switch(sort_type){
                case 0:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::InsertionSort((Sequence<int>*)(arr1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::InsertionSort((Sequence<int>*)(arr1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 2:
            switch(sort_type){
                case 0:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::HeapSort((Sequence<int>*)(arr1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::HeapSort((Sequence<int>*)(arr1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 3:
            switch(sort_type){
                case 0:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::QuickSort((Sequence<int>*)(arr1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    arr1 = (ArraySequence<int>*)SequenceSorter<int>::QuickSort((Sequence<int>*)(arr1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }
}
extern "C" __declspec(dllexport) void SortFloatArray(size_t sort_method, size_t sort_type) {
    switch(sort_method){
        case 0:
            switch(sort_type){
                case 0:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::BubbleSort((Sequence<float>*)(arr2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::BubbleSort((Sequence<float>*)(arr2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 1:
            switch(sort_type){
                case 0:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::InsertionSort((Sequence<float>*)(arr2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::InsertionSort((Sequence<float>*)(arr2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 2:
            switch(sort_type){
                case 0:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::HeapSort((Sequence<float>*)(arr2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::HeapSort((Sequence<float>*)(arr2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 3:
            switch(sort_type){
                case 0:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::QuickSort((Sequence<float>*)(arr1), [](float a, float b){return a < b;});
                    break;
                case 1:
                    arr2 = (ArraySequence<float>*)SequenceSorter<float>::QuickSort((Sequence<float>*)(arr1), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }
}
extern "C" __declspec(dllexport) void SortIntList(size_t sort_method, size_t sort_type) {
    switch(sort_method){
        case 0:
            switch(sort_type){
                case 0:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::BubbleSort((Sequence<int>*)(list1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::BubbleSort((Sequence<int>*)(list1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 1:
            switch(sort_type){
                case 0:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::InsertionSort((Sequence<int>*)(list1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::InsertionSort((Sequence<int>*)(list1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 2:
            switch(sort_type){
                case 0:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::HeapSort((Sequence<int>*)(list1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::HeapSort((Sequence<int>*)(list1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 3:
            switch(sort_type){
                case 0:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::QuickSort((Sequence<int>*)(list1), [](int a, int b){return a < b;});
                    break;
                case 1:
                    list1 = (ListSequence<int>*)SequenceSorter<int>::QuickSort((Sequence<int>*)(list1), [](int a, int b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }
}
extern "C" __declspec(dllexport) void SortFloatList(size_t sort_method, size_t sort_type) {
    switch(sort_method){
        case 0:
            switch(sort_type){
                case 0:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::BubbleSort((Sequence<float>*)(list2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::BubbleSort((Sequence<float>*)(list2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 1:
            switch(sort_type){
                case 0:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::InsertionSort((Sequence<float>*)(list2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::InsertionSort((Sequence<float>*)(list2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 2:
            switch(sort_type){
                case 0:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::HeapSort((Sequence<float>*)(list2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::HeapSort((Sequence<float>*)(list2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        case 3:
            switch(sort_type){
                case 0:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::QuickSort((Sequence<float>*)(list2), [](float a, float b){return a < b;});
                    break;
                case 1:
                    list2 = (ListSequence<float>*)SequenceSorter<float>::QuickSort((Sequence<float>*)(list2), [](float a, float b){return a > b;});
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }
}

extern "C" __declspec(dllexport) CHAR* DisplayArray(int arr_number){
    string message;
    switch(arr_number){
        case 0:
            message += DisplaySequence(arr1);
            break;
        case 1:
            message += DisplaySequence(arr2);
            break;
        case 2:
            message += DisplaySequence(list1);
            break;
        case 3:
            message += DisplaySequence(list2);
            break;
        default:
            message += "Incorrect array number!";
            break;
    }

    char *c = nullptr;
    message.copy(c, message.size() + 1);
    return c;
}

// 0 - initialize dynamic array by yourself
// 0 0 - int
// 0 0 - float
// 1 - initialize dynamic array with random items
// 2 - initialize linked list by yourself
// 3 - initialize linked list with random items
//extern "C" __declspec(dllexport) CHAR* LabFunc(int count, int action, int subaction){
//    string output = "";
//    switch(action){
//        case 0:
//            arr1 = DynamicArray<int>();
//            break;
//        case 1:
//            arr2 = DynamicArray<float>();
//            break;
//    }
//    return (char*)"Hello world!";
//}
