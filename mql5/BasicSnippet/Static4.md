```Static``` Method in Class
* Work with only **```static variables```** in class
* This is because ```static method``` don't have access to ```ClassInstance``` variables 
```cpp
#include <iostream>

struct Entity
{
  // non-static class variable
  int x, y;
  
  // static method in class work with static 
  static void Print()
  {
    std::cout << x << ", " << y << std::endl;
  }
};

// +------------------------------------------------------------+
// | This function is substitute for `static void Print()` above 
// | to demonstrate how the static method works. Not included in main code
// +------------------------------------------------------------+
static void Print(Entity e)
{
  std::cout << e.x << ", " << e.y << std::endl;
}
// +------------------------------------------------------------+
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
