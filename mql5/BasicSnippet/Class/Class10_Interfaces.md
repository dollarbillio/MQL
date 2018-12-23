**Interface**
---
* An interface allows determining specific functionality, which a class can then implement => A template
* An interface is a class that cannot contain any members, and may not have a constructor and/or a destructor
* A methods declared in an interface are purely virtual, even without an explicit definition
---
```cpp
//--- Basic interface for describing animals 
interface IAnimal 
{ 
//--- The methods of the interface have public access by default 
   void Sound();  // The sound produced by the animal 
}; 
//+------------------------------------------------------------------+ 
//|  The CCat class is inherited from the IAnimal interface          | 
//+------------------------------------------------------------------+ 
class CCat : public IAnimal 
{ 
public:
  // 
  CCat() { Print("Cat was born"); } 
  ~CCat() { Print("Cat is dead");  } 
  
  //--- Implementing the Sound method of the IAnimal interface 
  void Sound(){ Print("meou"); } 
}; 
//+------------------------------------------------------------------+ 
//|  The CDog class is inherited from the IAnimal interface          | 
//+------------------------------------------------------------------+ 
class CDog : public IAnimal 
{ 
public: 
  CDog() { Print("Dog was born"); } 
  ~CDog() { Print("Dog is dead");  } 
  //--- Implementing the Sound method of the IAnimal interface 
  void Sound(){ Print("guaf"); } 
}; 
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
{ 
  //--- An array of pointers to objects of the IAnimal type 
  IAnimal *animals[2]; 
  //--- Creating child classes of IAnimal and saving pointers to them into an array     
  animals[0]=new CCat; 
  animals[1]=new CDog; 
  
  //--- Calling the Sound() method of the basic IAnimal interface for each child   
  for(int i=0;i<ArraySize(animals);++i) 
    animals[i].Sound(); 
  
  //--- Deleting objects, invoking destructors
  for(int i=0;i<ArraySize(animals);++i) 
    delete animals[i]; 
}
//--- Execution result 
/* 
   Cat was born 
   Dog was born 
   meou 
   guaf 
   Cat is dead 
   Dog is dead 
*/
```
---
* Like with abstract classes, an interface object cannot be created without inheritance
* An interface can only be inherited from other interfaces and can be a parent for a class
* An interface is always publicly visible
* An interface cannot be declared within ```a class or structure``` declaration, 
but ```a pointer``` to the ```interface``` can be saved in a ```variable of type void *```
* A pointer to ```an object of any class``` can be saved into ```a variable of type void *```
* In order to convert a ```void * pointer``` to ```a pointer to an object of a particular class```, use the ```dynamic_cast``` operator
