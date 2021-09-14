//
// Created by lokt on 11.05.2021.
//
#include "gtest/gtest.h"
#include <iostream>
#include "../Enumerable.h"
#include "../ListSequence.h"
#include "../ArraySequence.h"

using namespace std;

int Pow(int x) {
    return x * x;
}

bool IsEven(int x) {
    return x % 2 == 0;
}

int f(int x, int y) {
    return x + y;
}

TEST(Enumerable, ListSequence_Map) {
    auto arr = new ListSequence<int>({11, 12, 3, 4, -5});
    auto res = (ListSequence<int>*)Enumerable<int>::Map(arr, Pow);
    EXPECT_TRUE(*res == ListSequence<int>({121, 144, 9, 16, 25}));
    auto res1 = (ListSequence<int>*)Enumerable<int>::Map(new ListSequence<int>({}), Pow);
    EXPECT_TRUE(*res1 == ListSequence<int>({}));
    auto res2 = (ListSequence<bool>*)Enumerable<int>::Map(new ListSequence<int>({11, 12, 3, 4, 6}), IsEven);
    EXPECT_TRUE(*res2 == ListSequence<bool>({false, true, false, true, true}));
    int (*wrong)(int) = nullptr;
    EXPECT_ANY_THROW(Enumerable<int>::Map(arr, wrong));
}
TEST(Enumerable, ListSequence_Reduce) {
    ListSequence<int>* arr = new ListSequence<int>({11, 12, 3, 4, -5});
    EXPECT_EQ(Enumerable<int>::Reduce(arr, f, 0), 25);
    int res2 = Enumerable<int>::Reduce(new ListSequence<int>({}), f, -1);
    EXPECT_EQ(res2, -1);
    int (*wrong)(int, int) = nullptr;
    EXPECT_ANY_THROW(Enumerable<int>::Reduce(arr, wrong, 0));
}

TEST(Enumerable, ListSequence_Where) {
    ListSequence<int> arr = {11, 12, 3, 4, -5};
    EXPECT_TRUE(*(Enumerable<int>::Where(arr, IsEven)) == ListSequence<int>({12, 4}));
    ListSequence<int> *res2 = Enumerable<int>::Where(ListSequence<int>({}), IsEven);
    EXPECT_TRUE(*res2 == ListSequence<int>());
    bool (*wrong)(int) = nullptr;
    EXPECT_ANY_THROW(Enumerable<int>::Where(arr, wrong));
}
