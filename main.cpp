#include <iostream>
#include "SequenceSorter.h"

int main() {
    std::cout << "Hello, World!" << std::endl;
    ArraySequence<int> seq = ArraySequence<int>({5, 2, 3, 6, 1, 4});
    seq.Display();
    seq = SequenceSorter<int>::BubbleSort(seq, [](int a, int b){ return a > b; });
    seq.Display();

    std::cout << "Hello, World!" << std::endl;
    ArraySequence<int> seq1 = ArraySequence<int>({5, 2, 3, 6, 1, 4});
    seq1.Display();
    seq1 = SequenceSorter<int>::InsertionSort(seq1, [](int a, int b){ return a > b; });
    seq1.Display();

    std::cout << "Hello, World!" << std::endl;
    ArraySequence<int> seq2 = ArraySequence<int>({5, 2, 3, 6, 1, 4});
    seq2.Display();
    seq2 = SequenceSorter<int>::HeapSort(seq2, [](int a, int b){ return a > b; });
    seq2.Display();

    std::cout << "Hello, World!" << std::endl;
    ArraySequence<int> seq3 = ArraySequence<int>({5, 2, 3, 6, 1, 4});
    seq3.Display();
    seq3 = SequenceSorter<int>::QuickSort(seq3, [](int a, int b){ return a > b; });
    seq3.Display();
    return 0;
}
