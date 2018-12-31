* When a **BaseClass** has ```Function()```method and an **InheritingClass** also has ```Function()``` method
you want ```Function()``` from **InheritingClass** to override that of **BaseClass** or there will be problems from ```Polymorphism```
```cpp
class Entity
{
  virtual void Function()
  {
    std::cout << "Entity" << std::endl;
  }
};

class Player : public Entity
{
private:
  std::string p_name;
public:
  Player(const std::string& name)
    : p_name(name) { Do things here}
  
  void Function() override
  {
    std::cout << p_name << std::endl;
  }
};
```
