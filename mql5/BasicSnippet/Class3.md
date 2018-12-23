# Initialization list
**CHERNO PROJECT**
---
* Initialization list is used in the constructor
* If we use parameterize constructor it is better since before the parameter is passed to the constructor it must be first declared above
```cpp
// This is an construction of class that will be used below
class Example
{
  public:
    Example()
    {
      std::cout <<"Created Example"<<end::endl;      
    }
    
    Example(int x)
    {
      std::cout <<"Created Example with " << x << endl;
    }
};

class Entity 
{
  private:
    std::string name;
    // The complier will create an Example object with default constructor
    Example example;
  
  public:
    // This constructor waste performance
    Entity()
    {
      // The compiler will create another Example but with parameter 8 and replaced the 
      //  already declared example with this Example(8)
      example = Example(8);
    }
};
```
* So there will be two objects created eventhough the task is doing right it wastes computer performance
* The right way and standard way is using ```initialization list```
```cpp
Entity()
  : example(Example(8))
  {
  }
```
---
---
**MQL5**
```mq5
//+------------------------------------------------------------------+ 
//| A class for storing the name of a character                      | 
//+------------------------------------------------------------------+ 
class CPerson 
{ 
  string m_first_name;     // First name  
  string m_second_name;    // Second name 
  public: 
  //--- An empty default constructor 
  CPerson() {Print(__FUNCTION__);}; // print 'CPerson::CPerson' everytime an object is created
  //--- A parametric constructor 
  CPerson(string full_name); 
  //--- A constructor with an initialization list 
  CPerson(string surname,string name): m_second_name(surname), m_first_name(name) {}; 
  void PrintName(){PrintFormat("Name=%s Surname=%s",m_first_name,m_second_name);}; 
}; 
//+------------------------------------------------------------------+ 
//| The Constructor Above                                            | 
//+------------------------------------------------------------------+ 
CPerson::CPerson(string full_name) 
{ 
  int pos=StringFind(full_name," "); 
  if(pos>=0) 
  { 
    m_first_name=StringSubstr(full_name,0,pos); 
    m_second_name=StringSubstr(full_name,pos+1); 
  } 
} 
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
  { 
  // This code runs perfectly normal
   CPerson people[5]; // Create an array of CPerson
   CPerson Tom="Tom Sawyer";                       // Tom Sawyer 
   CPerson Huck("Huckleberry","Finn");             // Huckleberry Finn 
   // Dynamically Created Object
   CPerson *Pooh = new CPerson("Winnie","Pooh");  // Winnie the Pooh 
   //--- Output values 
   Tom.PrintName(); 
   Huck.PrintName(); 
   Pooh.PrintName(); 
    
   //--- Delete a dynamically created object 
   delete Pooh; 
  }
  ```
