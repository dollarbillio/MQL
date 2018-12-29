* Static in Class and Variable in side one translation unit
---
**```Static``` in Variable**
* Class variable ```ClassName::variable```. Meaning that all instance of ```ClassName``` will share the same value of ```variable``` 
```cpp
#include <iostream>

struct Entity
{
  // there is only one value for x and y shared by all instance
  static int x, y;
  
  static void Print()
  {
    std::cout << x << ", " << y << std::endl;
  }
};

// Define the static variable
int Entity::x;
int Entity::y;

int main()
{
  Entity e;
  e.x = 2; //Entity::x = 2;
  e.y = 3; //Entity::y = 3;
  
  Entity e1;
  e1.x = 5; // Entity::x = 5;
  e1.y = 8; // Entity::y = 8;
  
  e.Print(); // If ```static Print``` above, can use Entity::Print(); 
  e1.Print();
  std::cin.get();
}
```
* Output: 
```5, 8``` and ```5, 8```
