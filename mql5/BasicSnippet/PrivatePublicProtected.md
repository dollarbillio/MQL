#### Public, Private, Protected
---
* No effect on program performance
* ```private``` in ```class``` or ```struct``` means that the ```private``` can only be used by ```public```methods inside the class and can't be accessed outside
even in the **InheritingClass**
* ```protected```: ```private``` + **accessible** to **InheritingClass**
```cpp
#include <iostream>
#include <string>

class Entity
{
private:/protected:
  int X, Y;
  void Print() {}

public:
  // This code doesn't generate errors 
  Entity 
  {
    X = 2;
    Print();
  }
};

class Player : public Entity
{
public:
  Player
  {
    // This will generate Error if use private, not if use protected
    X = 0;
    // This will also generate Errors if ~
    Print();
  }
}

int main
{
  Entity e;
  // This code shows error in protected and private
  e.X = 3;
  
  // This code also shows if 'private' in Entity, not if 'protected'
  Player p;
}
```
