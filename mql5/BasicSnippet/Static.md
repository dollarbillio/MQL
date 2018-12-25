* ```static``` means that the function is only internal to the file being written only
---
```Log.h```
```cpp
// Code is unique to this file only meaning that
//  each file containing this header will have their own 
//   void Log() version and there will be no linking error
static void Log(const char* message)
{
  // code here
}
```
```file2.cpp```
```cpp
#include "Log.h"

// You can use void Log() here which is different from above
```
```file3.cpp```
```cpp
#include "Log.h"

// You can use void Log() here and no linking error as 
//  this '''void Log()``` is different from ``void Log() 
```
