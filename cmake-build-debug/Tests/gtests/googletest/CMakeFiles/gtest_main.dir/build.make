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
CMAKE_SOURCE_DIR = D:\CProj\lab4

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = D:\CProj\lab4\cmake-build-debug

# Include any dependencies generated for this target.
include Tests\gtests\googletest\CMakeFiles\gtest_main.dir\depend.make

# Include the progress variables for this target.
include Tests\gtests\googletest\CMakeFiles\gtest_main.dir\progress.make

# Include the compile flags for this target's objects.
include Tests\gtests\googletest\CMakeFiles\gtest_main.dir\flags.make

Tests\gtests\googletest\CMakeFiles\gtest_main.dir\src\gtest_main.cc.obj: Tests\gtests\googletest\CMakeFiles\gtest_main.dir\flags.make
Tests\gtests\googletest\CMakeFiles\gtest_main.dir\src\gtest_main.cc.obj: ..\Tests\gtests\googletest\src\gtest_main.cc
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=D:\CProj\lab4\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object Tests/gtests/googletest/CMakeFiles/gtest_main.dir/src/gtest_main.cc.obj"
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoCMakeFiles\gtest_main.dir\src\gtest_main.cc.obj /Fd..\..\..\bin\gtest_maind.pdb /FS -c D:\CProj\lab4\Tests\gtests\googletest\src\gtest_main.cc
<<
	cd D:\CProj\lab4\cmake-build-debug

Tests\gtests\googletest\CMakeFiles\gtest_main.dir\src\gtest_main.cc.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/gtest_main.dir/src/gtest_main.cc.i"
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe > CMakeFiles\gtest_main.dir\src\gtest_main.cc.i @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E D:\CProj\lab4\Tests\gtests\googletest\src\gtest_main.cc
<<
	cd D:\CProj\lab4\cmake-build-debug

Tests\gtests\googletest\CMakeFiles\gtest_main.dir\src\gtest_main.cc.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/gtest_main.dir/src/gtest_main.cc.s"
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoNUL /FAs /FaCMakeFiles\gtest_main.dir\src\gtest_main.cc.s /c D:\CProj\lab4\Tests\gtests\googletest\src\gtest_main.cc
<<
	cd D:\CProj\lab4\cmake-build-debug

# Object files for target gtest_main
gtest_main_OBJECTS = \
"CMakeFiles\gtest_main.dir\src\gtest_main.cc.obj"

# External object files for target gtest_main
gtest_main_EXTERNAL_OBJECTS =

lib\gtest_maind.lib: Tests\gtests\googletest\CMakeFiles\gtest_main.dir\src\gtest_main.cc.obj
lib\gtest_maind.lib: Tests\gtests\googletest\CMakeFiles\gtest_main.dir\build.make
lib\gtest_maind.lib: Tests\gtests\googletest\CMakeFiles\gtest_main.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=D:\CProj\lab4\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX static library ..\..\..\lib\gtest_maind.lib"
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	$(CMAKE_COMMAND) -P CMakeFiles\gtest_main.dir\cmake_clean_target.cmake
	cd D:\CProj\lab4\cmake-build-debug
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	C:\PROGRA~2\MICROS~2\2017\BUILDT~1\VC\Tools\MSVC\1416~1.270\bin\Hostx86\x86\lib.exe /nologo /machine:X86 /out:..\..\..\lib\gtest_maind.lib @CMakeFiles\gtest_main.dir\objects1.rsp 
	cd D:\CProj\lab4\cmake-build-debug

# Rule to build all files generated by this target.
Tests\gtests\googletest\CMakeFiles\gtest_main.dir\build: lib\gtest_maind.lib

.PHONY : Tests\gtests\googletest\CMakeFiles\gtest_main.dir\build

Tests\gtests\googletest\CMakeFiles\gtest_main.dir\clean:
	cd D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest
	$(CMAKE_COMMAND) -P CMakeFiles\gtest_main.dir\cmake_clean.cmake
	cd D:\CProj\lab4\cmake-build-debug
.PHONY : Tests\gtests\googletest\CMakeFiles\gtest_main.dir\clean

Tests\gtests\googletest\CMakeFiles\gtest_main.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" D:\CProj\lab4 D:\CProj\lab4\Tests\gtests\googletest D:\CProj\lab4\cmake-build-debug D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest D:\CProj\lab4\cmake-build-debug\Tests\gtests\googletest\CMakeFiles\gtest_main.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : Tests\gtests\googletest\CMakeFiles\gtest_main.dir\depend

