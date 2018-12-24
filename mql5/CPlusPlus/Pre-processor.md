* PreProcessors will be checked first at complilation
---
* ```#include```: include file
* ```EndBrace.h``` file
```cpp
}
```
* ```main.cpp``` file
```cpp
int main()
{
  // Code in here
#include EndBracer.h // Basically will replace the content in the [EndBrace.h] in this area
```
---
```#define```: replace something with something
```cpp
// Replace INTEGER with int
#define INTEGER int

INTEGER multiply(int a, int b)
{
  INTEGER result = a * b;
  return result;
}
```
---
```#if #endif``` determine if we should include/exclude code based on condition
```cpp
#if 1: true 0: false

// code here

#endif
```
