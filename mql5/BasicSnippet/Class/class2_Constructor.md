* Constructor is used to initialize an instance memory
* if an instance is not initialized, it can't call function in class 
```cpp
class Entity
{
public:
  float X, Y;
  
  // Doesn't have return type
  Entity(float x, float y)
  {
    X = x;
    Y = y;
  }
  
  void Print()
  {
    std::cout << x << ", " << y << std::endl;
  }
};

int main()
{
  Entity e(10.0f, 5.0f);
  std::cout << e.X << std::endl;
  e.Print();
}
```
---
* A Class Without Constructor can be one with only ```StaticMethod```
```cpp
class Log
{
public:
  // this class cannot initialize an instance
  Log() = delete;
  
  static void Write()
  {
    
  }
}

int main()
{
  // This will work
  Log::Write();  
  // This will not work
  Log l;
  
  std::cin.get();
  
}
```
---
* Explicit and Implicit Call of Parametric Constructor
---
```cpp
class CFoo
{
  datetime m_call_time; // Time of the last object call
  public:
  //--- Constructor with a parameter that has a default value is not a default
  CFoo(const datetime t=0) {m_call_time=t;}; //--- Copy constructor
  
  // Pass by Reference
  CFoo(const CFoo &foo) {m_call_time=foo.m_call_time;};
  
  // ToString()
  string ToString() 
  {
    return(TimeToString(m_call_time,TIME_DATE|TIME_SECONDS));
  }; 
};

//+------------------------------------------------------------------+ 
//| Script program start function |
//+------------------------------------------------------------------+
void OnStart() 
{
  //--- Reference Stuffs
  // Using the default parameter t = 0
  CFoo foo;
  // Using the current time 
  CFoo foo1(TimeCurrent()); 
  // use default paramater
  CFoo foo2();
  // implicit conversion
  CFoo foo3=D'2009.09.09'; 
  // explicit call of reference to foo1
  CFoo foo40(foo1);
  // implicit call of reference to foo1
  CFoo foo41=foo1; 
  //---
  
  //--- Pointers point at object
  // Dynamic creation of an object and receiving of a pointer to it
  CFoo *pfoo6=new CFoo();  
  // Another option of dynamic object creation
  CFoo *pfoo7=new CFoo(TimeCurrent());
  // Now pfoo8 points to object foo1/memoryAdressfoo1
  CFoo *pfoo8=GetPointer(foo1);
  // pfoo9 points to pfoo7
  CFoo *pfoo9=pfoo7;            

  //--- Show the value of m_call_time 
  Print("foo1.m_call_time=",foo1.ToString()); 
  Print("foo2.m_call_time=",foo2.ToString()); 
  Print("foo3.m_call_time=",foo3.ToString()); 
  Print("foo4.m_call_time=",foo4.ToString()); 
  Print("foo5.m_call_time=",foo5.ToString()); 
  Print("pfoo6.m_call_time=",pfoo6.ToString()); 
  Print("pfoo7.m_call_time=",pfoo7.ToString()); 
  Print("pfoo8.m_call_time=",pfoo8.ToString()); 
  Print("pfoo9.m_call_time=",pfoo9.ToString()); 
    
  //--- Delete dynamically created arrays 
  delete pfoo6; 
  delete pfoo7; 
  //delete pfoo8;  // You do not need to delete pfoo8 explicitly, since it points to the automatically created object foo1 
  //delete pfoo9;  // You do not need to delete pfoo9 explicitly. since it points to the same object as pfoo7 
  
  //CFoo foo_array[3];     // This variant cannot be used - a default constructor is not set
  }
```

