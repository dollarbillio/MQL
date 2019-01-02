**Stack Array**
* Destroy immediately when we get to the end of function
```cpp
// This array contains 6 integers
// Each integer is 4 bytes => 25 bytes of memory
// Heap
int array[6];

// Set the index value of array
// offset the pointer 4 bytes in memory then start filling from the start of int 4 bytes
array[1] = 1;

// Print a value of array
std::cout << array[0] << std::endl;

// Print Memory address of array
std::cout << array << std::endl;
```
* Pointer
```cpp
int array[7];
// Pointer point to array
int* ptr =  array;

// Pointer move 2 dataUnits forward then set the value to 6
*(ptr + 2) = 6;
// Another way:
// cast the pointer into char* ptr, move 8 positions and cast back in to (int*) and dereference the pointer to 6
*(int*)((char*)ptr + 8) = 6
```
**Heap Array**
* Can't be destroyed unless we ```delete[] array```
* Must be used in function to return array
```cpp
int* ptr = new int[5];
delete[];
```
**Standard Array**
```cpp
#include <array>
std::array <int,5> example;
example.size();
```

