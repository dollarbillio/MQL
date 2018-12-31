* An interface is a ```class``` containing ```virtual function()= 0``` waiting to be implemented in the ```InheritingClass```
```cpp
#include <iostream>
#include <string>

class Entity
{
public:
  // This function is virtual and unimplemented
  virtual std::string GetName() = 0;
};

// This Class inherits from Entity so it will need to have a function that implements
// the `unimplemeneted virtual function()` above
class Player : public Entity
{
private:
  std::string m_name;
public: 
  // Constructor with initialization list
  Player(const std::string& name)
    : m_name(name) {}
    
  // This is necessary because it must implement GetName() from above
  std::string GetName() override { return m_name; }
};

int main()
{
  // Can't initialize because it is all virtual function() 
  Entity* e = new Entity();
  
  // This is ok as Player have attributes from Entity
  Entity* e = new Player("");
}
```
---
* Make sure that all objects passed in have a common method
* If an **InheritingClass** doesn't have any **BassClass** ```virtual function() = 0``` unimplemented, it cannot create an instance
```cpp
class Printable
{
  virtual std::string GetClassName() = 0;
};

class Entity : public Printable
{
public:
  std::string GetClassName() override { return "Entity";}
};

class Player : public Entity
{
private:
  std::string m_Name;
public: 
  Player (const std::string& name)
    : m_Name(name) {}
  
  // overriding  
  std::string GetName() override {return m_Name;}
  std::string GetClassName() override (return "Player"}
};

void Print(Printable* obj)
{
  std::cout << obj - > GetClassName() << std::endl;
}
```
