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

**ARRAYS**
```cs
int[] nums = { 1, 2, 3, 4, 5 };

int[] nums = new int[10];
Console.WriteLine(nums.Length);

// Set the inital size10 array with all elements = 0
int[] nums = new int[10];
nums[2] = 9; // index_3 = 9
nums[9] = 2; // index_10 = 2
```

**MATRIX**
```cs
int[,] matrix = new int[2,2];
matrix[0,0] = 1;
matrix[0,1] = 2;
matrix[1,0] = 3;
matrix[1,1] = 4;

// Same as above
int[,] predefinedMatrix = new int[2,2] { { 1, 2 }, { 3, 4 } };
```

**Lists**: Dynamically sized WhereAs Arrays = Fixed Size
```cs
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);

// Add a range of number into list
List<int> numbers = new List<int>();
int[] array = new int[] { 1, 2, 3 };
// Use .AddRange(ArrayToAdd)
numbers.AddRange(array);
```
