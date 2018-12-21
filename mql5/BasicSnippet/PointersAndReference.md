* Both are ways to connect to variable
---
* Pointer
```cpp
// - There is a variable, with a pointer(*)
// - The pointer is pointing at a variable x address in memory
<datatype> * ptr = &x;

// - Print the value of ptr under x address 
printf (ptr);
```
* Reference
```cpp
// the variable is referred to x, meaning when two of them are connected
// unlike pointers that can move around, once you refer to something, you can't
//  refer to others
<datatype> int & ref = x;

```
---
* PassByValue() and PassByReference() mechanism
```cpp
#include <studio.h>

// Prototyping
void passByVal(int val);
void passByRef(int & ref);
void passByPtr(int * ptr);

int main ()
{
  int x = 5;
  passByVal(x); // this will pass the copy of x, will not change the real x
  passByRef(x); // pass the reference to x(real x)
  
  // x pointer point to variable x reference
  int * xptr = &x;
  // pass the address of x which the pointer is pointing to and the pointer 
  //  will handle the change to x
  passByPtr(xptr); 
  return 0;
}

void passByVal(int val)
{
  val = 10;
  printf ("val = %i\n", val
}

void passByRef(int & ref)
{
  ref = 20;
  printf ("val = %i\n", val
}

void passByPtr(int * ptr)
{
  // set the pointer to 30 but ptr points to reference of 
  // x so x will also be changed to 30
  *ptr = 30;
  printf ("val = %i\n", val
}
