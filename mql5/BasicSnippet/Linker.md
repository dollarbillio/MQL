#### Linker Properties
* After compiling individual files, the linker will link functions of the compiled-s to each other
---
* Style from **```Cherno```**
---
```Log.h```
```cpp
// Decorators in header 
void Log(const char* message); 
```
---
```Log.cpp```
```cpp
// Log.h decorator is linked here 
#include "Log.h"

void Log(const char* message)
{
  std::cout << message << std:endl;
}
```
```Main.cpp```
```cpp
// this preprocessor will include void Log() from Log.h
// which is defined above
#include "Log.h"

int main ()
{
  // include the function Log() 
}
```
