* Both are ways to connect to variable
* ```variable0``` once referenced to ```variable1 (memoryAdress1)``` **can't** be referenced to ```variable2(memoryAddress2)``` as it is fixed to ```variable1(memoryAddress1)```. ```ValueReference```can't move around.
* ```pointer0``` once referenced to ```pointer1(currently pointing to memoryAddress1)``` **can** be referenced to ```pointer2 (currently pointing to memoryAddress2)``` which in effect makes all three pointers point to the same ```memoryAddress2```. Any changes of value made by one of the pointers will change the value referred by other pointers.
---
**Reference**
```cpp
// the variable is referred to x, meaning when two of them are connected
// unlike pointers that can move around, once you refer to something, you can't
//  refer to others

// ref is referred to x
<datatype> int & ref = x;
```
---
* PassByValue()
```cpp
// Prototyping
void passByVal(int val);

int main ()
{
  int x = 5;
  passByVal(x); // this will pass the copy-x, will not change the real-x
  return 0;
}

// - This function will change the value of the copy-x and print it, but
//    the real-x is the same
void passByVal(int val)
{
  val = 10;
}

```
* PassByRef()
```cpp
// Prototyping
void PassByRef(int & ref);

int main()
{
  int = 5;
  PassByRef(x); x will be changed to 20 after this
  return 0;
}

// - This function says that int & ref = x
//    so ref is referred to x. When ref is changed, x will also changed
void passByRef(int & ref)
{
  ref = 20;
}
```
---
**POINTER**
```cpp
// - There is a variable, with a pointer 
// - The pointer is pointing at a variable x address in memory
// - The pointer contains the address of x
<datatype> * ptr = &x;

// - Print the value of ptr under x address 
//    aka dereference pointer
printf (* ptr);
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
