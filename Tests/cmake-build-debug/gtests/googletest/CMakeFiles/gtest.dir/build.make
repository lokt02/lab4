# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.19

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


.SUFFIXES: .hpux_make_needs_suffix_list


# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE
NULL=nul
!ENDIF
SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2021.1.1\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2021.1.1\bin\cmake\win\bin\cmake.exe" -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = D:\CProj\laba3\Tests

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = D:\CProj\laba3\Tests\cmake-build-debug

# Include any dependencies generated for this target.
include gtests\googletest\CMakeFiles\gtest.dir\depend.make

# Include the progress variables for this target.
include gtests\googletest\CMakeFiles\gtest.dir\progress.make

# Include the compile flags for this target's objects.
include gtests\googletest\CMakeFiles\gtest.dir\flags.make

gtests\googletest\CMakeFiles\gtest.dir\src\gtest-all.cc.obj: gtests\googletest\CMakeFiles\gtest.dir\flags.make
gtests\googletest\CMakeFiles\gtest.dir\src\gtest-all.cc.obj: ..\gtests\googletest\src\gtest-all.cc
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=D:\CProj\laba3\Tests\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object gtests/googletest/CMakeFiles/gtest.dir/src/gtest-all.cc.obj"
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoCMakeFiles\gtest.dir\src\gtest-all.cc.obj /Fd..\..\bin\gtestd.pdb /FS -c D:\CProj\laba3\Tests\gtests\googletest\src\gtest-all.cc
<<
	cd D:\CProj\laba3\Tests\cmake-build-debug

gtests\googletest\CMakeFiles\gtest.dir\src\gtest-all.cc.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/gtest.dir/src/gtest-all.cc.i"
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe > CMakeFiles\gtest.dir\src\gtest-all.cc.i @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E D:\CProj\laba3\Tests\gtests\googletest\src\gtest-all.cc
<<
	cd D:\CProj\laba3\Tests\cmake-build-debug

gtests\googletest\CMakeFiles\gtest.dir\src\gtest-all.cc.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/gtest.dir/src/gtest-all.cc.s"
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoNUL /FAs /FaCMakeFiles\gtest.dir\src\gtest-all.cc.s /c D:\CProj\laba3\Tests\gtests\googletest\src\gtest-all.cc
<<
	cd D:\CProj\laba3\Tests\cmake-build-debug

# Object files for target gtest
gtest_OBJECTS = \
"CMakeFiles\gtest.dir\src\gtest-all.cc.obj"

# External object files for target gtest
gtest_EXTERNAL_OBJECTS =

lib\gtestd.lib: gtests\googletest\CMakeFiles\gtest.dir\src\gtest-all.cc.obj
lib\gtestd.lib: gtests\googletest\CMakeFiles\gtest.dir\build.make
lib\gtestd.lib: gtests\googletest\CMakeFiles\gtest.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=D:\CProj\laba3\Tests\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX static library ..\..\lib\gtestd.lib"
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	$(CMAKE_COMMAND) -P CMakeFiles\gtest.dir\cmake_clean_target.cmake
	cd D:\CProj\laba3\Tests\cmake-build-debug
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\lib.exe /nologo /machine:X86 /out:..\..\lib\gtestd.lib @CMakeFiles\gtest.dir\objects1.rsp 
	cd D:\CProj\laba3\Tests\cmake-build-debug

# Rule to build all files generated by this target.
gtests\googletest\CMakeFiles\gtest.dir\build: lib\gtestd.lib

.PHONY : gtests\googletest\CMakeFiles\gtest.dir\build

gtests\googletest\CMakeFiles\gtest.dir\clean:
	cd D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest
	$(CMAKE_COMMAND) -P CMakeFiles\gtest.dir\cmake_clean.cmake
	cd D:\CProj\laba3\Tests\cmake-build-debug
.PHONY : gtests\googletest\CMakeFiles\gtest.dir\clean

gtests\googletest\CMakeFiles\gtest.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" D:\CProj\laba3\Tests D:\CProj\laba3\Tests\gtests\googletest D:\CProj\laba3\Tests\cmake-build-debug D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest D:\CProj\laba3\Tests\cmake-build-debug\gtests\googletest\CMakeFiles\gtest.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : gtests\googletest\CMakeFiles\gtest.dir\depend

