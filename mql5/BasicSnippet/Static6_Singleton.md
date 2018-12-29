* we will use and ```static ClassMethod``` and ```static ClassInstance```
* The ```static ClassInstance``` will not be changed at the next time an instance is initialized as it stay in a static function
```cpp
#include <iostream>

// a class that has only one instance
class Singleton
{
public
  static Singleton& Get() 
  {
    // if there is no static ==> the singleton instance will get destroyed everytime an instance is done called
    static Singleton singleton;
    return singleton
  };
  
  // normal Singleton function
  void Hello() {}
};

Singleton* Singleton::s_singleton = nullptr;

int main()
{
  // return an instance of Singleton and use the '''Hello() function of 
  Singleton::Get().Hello();
}
```
---
* If we use ```&``` and ```static``` for ```Get()```, it means that it refers to only ```one fixed Dead memory``` so if we don't use ```static Singleton singleton```
* it causes error because each time Get() is called, a new ```Singleton singleton``` is created which returns a different memory address
```cpp
public
  static Singleton& Get() 
  {
    // if there is no static ==> the singleton instance will get destroyed everytime an instance is done called
    static Singleton singleton;
    return singleton
  };
```
