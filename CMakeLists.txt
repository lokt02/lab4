cmake_minimum_required(VERSION 3.19)
project(lab4)

set(CMAKE_CXX_STANDARD 20)

# add_executable(lab4 main.cpp SequenceSorter.h)

add_library(lab4 SHARED main.cpp SequenceSorter.h)

add_subdirectory(Tests)