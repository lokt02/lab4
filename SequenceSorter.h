//
// Created by lokt0 on 13.09.2021.
//

#ifndef LAB4_SEQUENCESORTER_H
#define LAB4_SEQUENCESORTER_H

#include <functional>
#include "Sequence.h"
#include "Enumerable.h"
#include "ArraySequence.h"

template<class T>
class SequenceSorter{
public:
    template <template<typename> class ChildClass>
    static ChildClass<T> BubbleSort(ChildClass<T> sequence, std::function<bool(T, T)> const & comparer){
        if constexpr (static_cast<Sequence<T>*>(&sequence) == nullptr){
            throw std::runtime_error("Wrong type");
        }
        int i, j;
        bool swapped;
        for(i = 0; i < sequence.GetLength() - 1; i++){
            swapped = false;
            for(j = 0; j < sequence.GetLength() - 1 - i; j++){
                if(comparer(sequence[j], sequence[j+1])){
                    swap(sequence[j], sequence[j+1]);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
        return sequence;
    }

    template <template<typename> class ChildClass>
    static ChildClass<T> InsertionSort(ChildClass<T> sequence, std::function<bool(T, T)> const & comparer){
        if constexpr (static_cast<Sequence<T>*>(&sequence) == nullptr){
            throw std::runtime_error("Wrong type");
        }
        T key;
        int j;
        for(int i = 1; i < sequence.GetLength(); i++){
            key = sequence[i];
            j = i;
            while(j > 0 && comparer(sequence[j-1], key)){
                sequence[j] = sequence[j-1];
                j--;
            }
            sequence[j] = key;
        }
        return sequence;
    }

    template <template<typename> class ChildClass>
    static ChildClass<T> HeapSort(ChildClass<T> sequence, std::function<bool(T, T)> const & comparer){
        if constexpr (static_cast<Sequence<T>*>(&sequence) == nullptr){
            throw std::runtime_error("Wrong type");
        }
        int count = sequence.GetLength();

        for(int i = count / 2 - 1; i >= 0; i--){
            heapify(sequence, i, count, comparer);
        }

        for (int i = count - 1; i >= 0; i--) {
            swap(sequence[0], sequence[i]);
            heapify(sequence, 0, i, comparer);
        }

        return sequence;
    }

    template <template<typename> class ChildClass>
    static ChildClass<T> QuickSort(ChildClass<T> sequence, std::function<bool(T, T)> const & comparer){
        if constexpr (static_cast<Sequence<T>*>(&sequence) == nullptr){
            throw std::runtime_error("Wrong type");
        }
        quickSort(sequence, 0, sequence.GetLength() - 1, comparer);
        return sequence;
    }

private:
    template <template<typename> class ChildClass>
    static void quickSort(ChildClass<T> &seq, int low, int high, std::function<bool(T, T)> const & comp) {
        if(low < high){
            int pi = partition(seq, low, high, comp);

            quickSort(seq, low, pi - 1, comp);
            quickSort(seq, pi + 1, high, comp);
        }
    }
    template <template<typename> class ChildClass>
    static int partition(ChildClass<T> &seq, int low, int high, std::function<bool(T, T)> const & comp) {
        T pivot = seq[high];
        int i = low - 1;
        for(int j = low; j <= high - 1; j++){
            if(!comp(seq[j], pivot)){
                i++;
                swap(seq[i], seq[j]);
            }
        }
        swap(seq[i + 1], seq[high]);
        return i + 1;
    }
    template <template<typename> class ChildClass>
    static void heapify(ChildClass<T> &seq, int i, int count, std::function<bool(T, T)> const & comp){
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if(l < count && comp(seq[l], seq[largest])){
            largest = l;
        }

        if(r < count && comp(seq[r], seq[largest])){
            largest = r;
        }

        if(largest != i){
            swap(seq[i], seq[largest]);
            heapify(seq, count, largest, comp);
        }
    };
};
#endif //LAB4_SEQUENCESORTER_H
