```cpp
//+------------------------------------------------------------------+ 
//| A class with a default constructor                               | 
//+------------------------------------------------------------------+ 
class CFoo 
  { 
    datetime m_call_time;     // Time of the last object call 
  public: 
  //--- Constructor with a parameter that has a default value is not a default constructor 
    CFoo(const datetime t=0){m_call_time=t;}; 
  //--- Copy constructor: What is this 
    CFoo(const CFoo &foo){m_call_time=foo.m_call_time;}; 
  
   string ToString(){return(TimeToString(m_call_time,TIME_DATE|TIME_SECONDS));}; 
  }; 
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
  { 
// CFoo foo; // This variant cannot be used - a default constructor is not set 
//--- Possible options to create the CFoo object 
   CFoo foo1(TimeCurrent());     // An explicit call of a parametric constructor 
   CFoo foo2();                  // An explicit call of a parametric constructor with a default parameter 
   CFoo foo3=D'2009.09.09';      // An implicit call of a parametric constructor 
   CFoo foo40(foo1);             // An explicit call of a copy constructor 
   CFoo foo41=foo1;              // An implicit call of a copy constructor 
   CFoo foo5;                    // An explicit call of a default constructor (if there is no default constructor, 
                                 // then a parametric constructor with a default value is called) 
//--- Possible options to receive CFoo pointers 
   CFoo *pfoo6=new CFoo();       // Dynamic creation of an object and receiving of a pointer to it 
   CFoo *pfoo7=new CFoo(TimeCurrent());// Another option of dynamic object creation 
   CFoo *pfoo8=GetPointer(foo1); // Now pfoo8 points to object foo1 
   CFoo *pfoo9=pfoo7;            // pfoo9 and pfoo7 point to one and the same object 
   // CFoo foo_array[3];         // This option cannot be used - a default constructor is not specified 
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
  }
```
