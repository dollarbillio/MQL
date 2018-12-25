## Initialization list related to Base Class
---
* If a default constructor is **not declared in the base class**, and at the same time one or more constructors 
with parameters are declared, **always call one of the base class constructors** in the initialization list. 
* ```BaseClass Constructor``` will be **called first during object initialization**, no matter where in the 
initialization list **it is located**
---
```cpp
//+------------------------------------------------------------------+ 
//| Base class                                                       | 
//+------------------------------------------------------------------+ 
class CFoo 
  { 
   string            m_name; 
public: 
   // There is no default constructor in the base class
   //--- A constructor with an initialization list 
   CFoo(string name) : m_name(name) { Print(m_name);} 
  }; 
//+------------------------------------------------------------------+ 
//| Class derived from CFoo                                          | 
//+------------------------------------------------------------------+ 
class CBar : CFoo 
  { 
   CFoo m_member;      // A class member is an object of the parent 
public: 
   //--- A default constructor in the initialization list calls the constructor of a parent 
   CBar(): m_member(_Symbol), CFoo("CBAR") {Print(__FUNCTION__);} 
  }; 
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
  { 
   CBar bar; 
  }
```
---
* In this initialization list, we call ```CFoo("CBAR")``` first and ```m_member(_Symbol)``` later
