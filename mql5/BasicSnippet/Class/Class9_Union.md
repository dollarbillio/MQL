**Union**
---
* ```a special data type``` consisting of several variables ```sharing the same memory area```
* Provides the ability to interpret the ```same bit sequence``` in two (or more) different ways
```cpp
// various union members belong to the same memory area
union LongDouble 
{ 
  long   long_value; 
  double double_value; 
};
```
* Union of LongDouble is declared with long and double type values sharing the same memory area
* Union like this is in an MQL5 program ==> data containing in the union as an integer (long) or real (double) value at any time
* Union allows receiving two (or more) options for representing the same data sequence
```cpp
union LongDouble 
{ 
  long   long_value; 
  double double_value; 
}; 
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
{ 
//--- 
  LongDouble lb; 
//--- get and display the invalid -nan(ind) number 
  lb.double_value=MathArcsin(2.0); 
  printf("1.  double=%f                integer=%I64X",lb.double_value,lb.long_value); 

//--- largest normalized value (DBL_MAX) 
  lb.long_value=0x7FEFFFFFFFFFFFFF; 
  printf("2.  double=%.16e  integer=%I64X",lb.double_value,lb.long_value); 

//--- smallest positive normalized (DBL_MIN) 
  lb.long_value=0x0010000000000000;     
  printf("3.  double=%.16e  integer=%.16I64X",lb.double_value,lb.long_value); 
} 
/*  Execution result 
    1.  double=-nan(ind)                integer=FFF8000000000000 
    2.  double=1.7976931348623157e+308  integer=7FEFFFFFFFFFFFFF 
    3.  double=2.2250738585072014e-308  integer=0010000000000000 
*/
```
---
* The unions cannot be involved in the ```inheritance```, and they also cannot have ```static members``` due to their very nature.
* the union behaves like a structure with all its members having a zero offset: one structures only
* Can't include: ```dynamic arrays```, ```strings```, ```pointers to objects and functions```, ```class objects```, ```structure objects 
having constructors or destructors```, ```structure objects having members from the points 1-5```
---
* The union is capable of having constructors and destructors, as well as methods
* Union members are of ```public``` access type. In order to create ```private``` elements, use the ```private``` keyword. 
* The code below shows how to convert a color of the color type to ARGB as does the ColorToARGB() function.
```cpp
//+------------------------------------------------------------------+ 
//| Union for color(BGR) conversion to ARGB                          | 
//+------------------------------------------------------------------+ 
union ARGB 
  { 
   uchar             argb[4]; 
   color             clr; 
   //--- parametric constructors 
   //--- color col is pass on later 
   ARGB(color col,uchar a=0) {Color(col,a);}; 
   // destructors
   ~ARGB(){}; 
   
   //--- public methods 
public: 
   uchar  Alpha() {return(argb[3]);}; 
   // assign argb[3] = alpha
   void   Alpha(const uchar alpha) {argb[3]=alpha;}; 
   
   // Return color defined above
   color  Color() {return(color(clr));}; 
   //--- private methods 
private: 
   //+------------------------------------------------------------------+ 
   //| set the alpha channel value and color                            | 
   //+------------------------------------------------------------------+ 
   void Color(color col,uchar alpha) 
     { 
      //--- set color to clr member 
      clr=col; 
      //--- set the Alpha component value - opacity level 
      argb[3]=alpha; 
      //--- interchange the bytes of R and B components (Red and Blue)      
      uchar t=argb[0];
      argb[0]=argb[2];
      argb[2]=t; 
     }; 
  };
//+------------------------------------------------------------------+ 
//| Script program start function                                    | 
//+------------------------------------------------------------------+ 
void OnStart() 
  { 
//--- 0x55 means 55/255=21.6 % (0% - fully transparent) 
   uchar alpha=0x55;  

//--- color type is represented as 0x00BBGGRR 
   color test_color=clrDarkOrange; 

//--- values of bytes from the ARGB union are accepted here 
   uchar argb[];  
//--- [Output]: 0x00008CFF - here is how the color type looks for clrDarkOrange, BGR=(255,140,0) 
   PrintFormat("0x%.8X - here is how the 'color' type look like for %s, BGR=(%s)", 
               test_color,ColorToString(test_color,true),ColorToString(test_color)); 

//--- ARGB type is represented as 0x00RRGGBB, RR and BB components are swapped 
//--- [ThisFunction]: ARGB(color col,uchar a=0) {Color(col,a);}; 
   ARGB argb_color(test_color); 

//--- copy the bytes array 
   ArrayCopy(argb,argb_color.argb); 

//--- here is how it looks in ARGB representation
//--- [OUTPUT]: 0x00FF8C00 - ARGB representation with the alpha channel=0x00, ARGB=(0,255,140,0)
   PrintFormat("0x%.8X - ARGB representation with the alpha channel=0x%.2x, ARGB=(%d,%d,%d,%d)", 
               argb_color.clr,argb_color.Alpha(),argb[3],argb[2],argb[1],argb[0]); 

//--- add opacity level 
   argb_color.Alpha(alpha); 

//--- try defining ARGB as 'color' type 
//--- [OUTPUT]: ARGB as color=(0,140,255)  alpha channel=85
   Print("ARGB as color=(",argb_color.clr,")  alpha channel=",argb_color.Alpha()); 

//--- copy the bytes array 
   ArrayCopy(argb,argb_color.argb); 

//--- here is how it looks in ARGB representation
//--- [OUTPUT]: 0x55FF8C00 - ARGB representation with the alpha channel=0x55, ARGB=(85,255,140,0) 
   PrintFormat("0x%.8X - ARGB representation with the alpha channel=0x%.2x, ARGB=(%d,%d,%d,%d)", 
               argb_color.clr,argb_color.Alpha(),argb[3],argb[2],argb[1],argb[0]); 

//--- check with the ColorToARGB() function results
//--- [OUTPUT]: 0x55FF8C00 - result of ColorToARGB(clrDarkOrange,0x55)
   PrintFormat("0x%.8X - result of ColorToARGB(%s,0x%.2x)",ColorToARGB(test_color,alpha), 
               ColorToString(test_color,true),alpha); 
  } 
```
