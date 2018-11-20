**BASIC TEMPLATE**
```cs
using System;

class MainClass 
{
  public static void Main (string[] args) 
  {
    //Create Variables Here
    
    Console.WriteLine ("Hello World");
  }
}
```

**VARIABLE DECLARATION**
```cs
var x = 1;
var y = 2;
var sum = x + y;

int myInt = 1;
float myFloat = 1f;
bool myBoolean = true;
string myName = "John";
char myChar = 'a';
double myDouble = 1.75;
```

**Enums are integers used when an integer is used to specify an option from a fixed amount of options**
```cs
public enum CarType
{
    Toyota = 1,
    Honda = 2,
    Ford = 3,
}

public class Tutorial
{
    public static void Main()
    {
        CarType myCarType = CarType.Toyota;
    }
}
```
