add_subdirectory(gtests)
include_directories(${gtest_SOURCE_DIR}/include ${gtest_SOURCE_DIR})
add_executable(Tests EnumerableTest.cpp LinkedListTest.cpp DynamicArrayTest.cpp ListSequenceTest.cpp ArraySequenceTest.cpp SequenceSorterTest.cpp)
target_link_libraries(Tests gtest gtest_main)