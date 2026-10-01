cmake_minimum_required(VERSION 3.20)
project(leetcode C CXX)

set(CMAKE_C_STANDARD 11)
set(CMAKE_C_STANDARD_REQUIRED ON)
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

if(NOT CMAKE_BUILD_TYPE AND NOT CMAKE_CONFIGURATION_TYPES)
    set(CMAKE_BUILD_TYPE Debug CACHE STRING "Build type" FORCE)
endif()

# AddressSanitizer + UndefinedBehaviorSanitizer: out-of-bounds access,
# use-after-free, leaks (C only) and signed overflow make the test fail with a
# stack trace. Turn off with -DLC_SANITIZE=OFF to use valgrind.
option(LC_SANITIZE "Build tests with ASan + UBSan" ON)

# Unused parameters are normal while a solution is still a stub.
add_compile_options(-Wall -Wextra -Wno-unused-parameter -g)
# Failure messages show "problems/0094_.../test.c:12" instead of the absolute path.
add_compile_options(-fmacro-prefix-map=${CMAKE_CURRENT_SOURCE_DIR}/=)
if(LC_SANITIZE)
    add_compile_options(-fsanitize=address,undefined -fno-sanitize-recover=undefined -fno-omit-frame-pointer)
    add_link_options(-fsanitize=address,undefined)
endif()

enable_testing()

# One executable + one CTest test per problems/<NNNN_name>/test.c or test.cpp.
# test.c #includes solution.c, so only the test file is compiled.
file(GLOB LC_TEST_SOURCES CONFIGURE_DEPENDS
    ${CMAKE_CURRENT_SOURCE_DIR}/problems/*/test.c
    ${CMAKE_CURRENT_SOURCE_DIR}/problems/*/test.cpp)

foreach(test_source ${LC_TEST_SOURCES})
    get_filename_component(problem_dir ${test_source} DIRECTORY)
    get_filename_component(problem ${problem_dir} NAME)      # 0094_binary_tree_inorder_traversal
    string(REGEX MATCH "^[0-9]+" number ${problem})          # 0094
    get_filename_component(ext ${test_source} LAST_EXT)

    if(ext STREQUAL ".cpp")
        set(target p${number}_cpp)
        set(test_name ${problem}_cpp)
    else()
        set(target p${number})
        set(test_name ${problem})
    endif()

    add_executable(${target} ${test_source})
    target_include_directories(${target} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/include ${problem_dir})
    if(ext STREQUAL ".c")
        target_link_libraries(${target} PRIVATE m)
    endif()

    add_test(NAME ${test_name} COMMAND ${target})
    set_tests_properties(${test_name} PROPERTIES TIMEOUT 10)
endforeach()

# Scratch program for trying things out: cmake --build build --target playground
add_executable(playground playground/main.cpp)
