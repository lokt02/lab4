//
// Created by lokt on 13.04.2021.
//

#ifndef LABA2_ICOLLECTION_H
#define LABA2_ICOLLECTION_H

template<class T>
class ICollection {
public:
    size_t Count;
    ICollection(){
        Count = 0;
    }
//    virtual void Append(T) = 0;
    virtual void Clear() = 0;
    virtual size_t GetLength() const {
        return Count;
    }
};

#endif //LABA2_ICOLLECTION_H
