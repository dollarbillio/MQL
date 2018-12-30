* Class inheritance is used to have a ```BiggerClass``` inherit from a ```SmallerClass```
* If a variable needs a ```SmallerClass``` input, we can use ```BiggerClass``` input as it also has ```SmallerClass``` attributes 
---
```cpp
class Entity
{
  void PrintEntity()
  {
    std::cout << "message" << std:endl;
  }
}

class Player : public Entity
{
  
}

int main()
{
  Player player;
  player.PrintEntity();
}
```
