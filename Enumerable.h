//
// Created by lokt on 13.04.2021.
//


#ifndef LABA2_ENUMERABLE_H
#define LABA2_ENUMERABLE_H

#include "ICollection.h"
#include <iostream>

template<typename T>
class Enumerable : public ICollection<T> {
public:

    virtual T &Get(int) = 0;

    static T Reduce(Enumerable<T> *collection, T(*f)(T, T), T const & c) {
        if (f == NULL)
            throw std::invalid_argument("reducer is NULL");
        T res = c;
        for (size_t i = 0; i < collection->GetLength(); ++i) {
            res = f(collection->Get(i), res);
        }
        return res;
    }
    template<template<typename> class ChildClass>
    static ChildClass<T> *Where(ChildClass<T> collection, bool(*predicate)(T)) {
        if constexpr (static_cast<ICollection<T> *>(&collection) == nullptr) {
            throw std::runtime_error("Wrong type");
        }
        if (predicate == NULL)
            throw std::invalid_argument("predicate is NULL");
        ChildClass<T> *res = new ChildClass<T>();
        for (size_t i = 0; i < collection.GetLength(); i++)
            if (predicate(collection.Get(i)))
                res->Append(collection.Get(i));
        return res;
    }

    template<class T1>
    static Enumerable<T>* Map(Enumerable<T>* collection, T1 (*mapper)(T)) {
        if (mapper == nullptr)
            throw std::invalid_argument("mapper is NULL");
        size_t length = collection->GetLength();
        for (size_t i = 0; i < length; i++)
            collection->Get(i) = mapper(collection->Get(i));
        return collection;
    }

};
#endif //LABA2_ENUMERABLE_H
