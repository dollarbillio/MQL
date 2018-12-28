* Both are ways to connect to variable
* ```variable0``` once referenced to ```variable1(memoryAdress1)``` **can't** be referenced to ```variable2(memoryAddress2)``` as it is fixed to ```variable1(memoryAddress1)```. ```ValueReference``` can't move around.
* ```pointer0``` once referenced to ```pointer1(currently pointing to memoryAddress1)``` **can** be referenced to ```pointer2 (currently pointing to memoryAddress2)``` which in effect makes all three pointers point to the same ```memoryAddress2```. Any changes of dereferenced value made by one of the pointers will change the dereferenced value referred by other pointers.
---
**REFERENCE**
```cpp
// the variable is referred to x, meaning when two of them are connected
// unlike pointers that can move around, once you refer to something, you can't
//  refer to others

// ref is referred to x
<datatype> int& ref = x;
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
void passByRef(int& ref)
{
  ref = 20;
}
```
---
