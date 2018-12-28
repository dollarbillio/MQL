**POINTER**
* Pointer is an ```int``` that holds memory address
```cpp
// Most basic pointer has is Void*, memory address is 0
void* ptr = 0/NULL/nullptr;

// <DataType> is meaningless if you are not making changes to/read from the memory address
int var = 1;
void* ptr = &var;

// <NoneVoid_DataType>* says that the value of the pointer memory is that datatype
// necessary when read from/making change to ptr
int var = 1;
int* ptr = var;
*ptr = 10; // change value of the memory address which the pointer is holding

--> var = 10;
```
---
* Allocating memory size for pointer
```cpp 
// pointer for a block of memory
// pointer will start at the beginning of memory block 
char* buffer = new char[8]; // memory of 8 bytes  
memset(buffer, 0, 8); // set all 8 bytes to 0 => default [00 00 00 00 00 00 00 00]

delete[] buffer; // delete array
```
* Pointer to Pointer
```cpp
// buffer which holds memory address of char[8] has its own memory address
// the new ptr will hold memory address of buffer
char** ptr = &buffer;
```
---
* PassByPointer()
```cpp
// prototyping
void passByPtr(int * ptr);

int main ()
{
  int x = 5;
  int y = 6
  
  // p will point the memory address of x 
  int * p = &x;
  int * p2 = &y;
  
  passByPtr(p); // this will need to pass in a POINTER, not a value or a reference
  return 0;
}
  
// the function below will pass the copy-p[containing the same address as p, and pointing to x-memoryAddress] 
//  so when you manipulate the passed in p, you are actually manipulate the copy-p(still pointing to x-memoryAddress) 
//    So now at x-memoryAddress, it will have the new value (the result from manipulating copy-p) and the *real-p(having the same)
//      memory address) will have different value
void passByPtr(int * ptr)
{
  // ptr is the copy version of p
  *ptr = 30;
  
  // ptr will now be copy of another pointer(p2)
  //  aka containing the address that (p2) is pointing to
  //   two pointer ptr and p2 is pointing at the same address while p 
  //    is pointing to another address
  ptr = p2;
  
  // change the value of memory address that new-ptr is pointing to
  *ptr = 7;
}
```
* PassByPointerReference()
```cpp
void passByPtr(int * & ptrRef)
{
  // ptr is now the real p
  *ptrRef = 30;
  
  // ptrRef will now be pointing to another pointer(p2)
  //  aka containing the address that (p2) is pointing to
  //    Now three pointers: p, ptrRef, p2 are pointing at the same address
  ptrRef = p2;
  
  // change the value of memory address that new-ptrRef is pointing to
  //  This will change *p, *ptrRef, *p2 => 7
  *ptrRef = 7;
}
```
