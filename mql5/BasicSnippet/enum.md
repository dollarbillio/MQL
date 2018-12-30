### Enums
* As a way to store value that is anything
* Group all related values into one block
---
```cpp
enum Example 
{
  A, // A = 0 as default, if A = 5 wlll also increments by one below
  B, // B = 1  
  C  // C = 2 

  
}

int main
{
  Example value = B; // value = 1;
  if (value == 0) // (value == A)?
  {
    // do things
  }
}
```
---
* Can specify which type of integer does Example belong to
```cpp
// we specify that Example use 1 byte 
enum Example : unsigned char 
{
  A, // A = 0 as default, if A = 5 wlll also increments by one below
  B, // B = 1  
  C  // C = 2 

  
}

int main
{
  Example value = B; // value = 1;
  if (value == 0) // (value == A)?
  {
    // do things
  }
}
```
