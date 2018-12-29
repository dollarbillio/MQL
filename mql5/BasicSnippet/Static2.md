```file1.cpp```
```cpp
// static means that s_var is only internal
static int s_var = 2;

// non-static means that var is external to other files
int var = 3;
```
```file2.cpp```
```cpp
#include <iostream>
#define PRINT std::cout << var << std::endl;
// This will result in linking error as there is also [int var = 3] above
int var = 4;
PRINT

// This will include [int var = 3] from file1.cpp
extern int var;
PRINT 

// This will result in linking error as [static int s_var]
extern int s_var;
PRINT
```
