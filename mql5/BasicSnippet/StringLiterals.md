* String literal is an array of ```char``` and the pointer is pointing at the first ```char``` of the array
* String literal is stored in read-only memory
```cpp
// Pointer to constant string
const char* name = "Dung";
// can't do this
name[2] = a;
```
* Take the read-only memory, take a variable, copy from read-only to a variable that can be manipulated
```cpp
// This code is probable
char name[] = Dung;
name[1] = "a";
```
* Paragraph
```cpp
const char* paragraph = R"(Line1
Line2
Line3
Line4)";
```
