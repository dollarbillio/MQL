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
---
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
---
**ENUMS are integers used when an integer is used to specify an option from a fixed amount of options**
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
---
**ARRAY**
```cs
int[] nums = new int[] { 1, 2, 3, 4, 5 };
-----
int[] nums = new int[10];
// Show the array length
Console.WriteLine(nums.Length);
-----
// Set the inital size10 array with all elements = 0
int[] nums = new int[10];
nums[2] = 9; // index_3 = 9
nums[9] = 2; // index_10 = 2
```
---
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
---
**LISTS**: Dynamically sized WhereAs **Arrays** = Fixed Size
```cs
// +-----------+
// |--Numbers--|
// +-----------+
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
-----
// Add a range of number into list
List<int> numbers = new List<int>();
int[] array = new int[] { 1, 2, 3 };
// Use .AddRange(ArrayToAdd)
numbers.AddRange(array);
-----
// +-----------+
// |--Strings--|
// +-----------+
// Remove "banana" 
fruits.Remove("banana");
// Remove "banana" at its index [1]
fruits.RemoveAt(1);
// Count the number of items in the list
Console.WriteLine(fruits.Count);
-----
// Create a news string list
List<string> food = new List<string>();
food.Add("apple");
food.Add("banana");
-----
List<string> vegetables = new List<string>();
vegetables.Add("tomato");
vegetables.Add("carrot");
-----
// List Concatenation
food.AddRange(vegetables);
Console.WriteLine(food.Count);
```
---
**DICTIONARY**
```cs
// Dictionary<KeyType, ValueType>
Dictionary<string, long> phonebook = new Dictionary<string, long>();
phonebook.Add("Alex", 4154346543);
phonebook["Jessica"] = 4159484588;
-----
// Check if Key is in Dictionary
if (phonebook.ContainsKey("Alex"))
{
    Console.WriteLine("Alex's number is " + phonebook["Alex"]);
}
-----
// remove a Key_Value pair in dictionary
phonebook.Remove("Jessica");
```
---
**STRINGS**
```cs
string emptyString = String.Empty/"";
-----
// String Concatenation
string firstName = "Eric";
string lastName = "Smith";
string fullName = firstName + " " + lastName;
-----
// Add string with operators
string sentence = "I like to play ";
sentence += "chess.";
-----
//+----------------------------------+
//|--TypeCasting: Integer to String--|
//+----------------------------------+
int integer = 1;
string ourString = integer.ToString();
-----
//+---------------------+
//|--String Formatting--|
//+---------------------+
int x = 1, y = 2;
int sum = x + y;
string sumCalculation = String.Format("{0} + {1} = {2}", x, y, sum);
-----
//+---------------------------------------------+
//|--string.Substring(StartIndex, TotalLength)--|
//+---------------------------------------------+
string fullString = "full string";
string partOfString = fullString.Substring(5);
string shorterPart = fullString.Substring(5, 3); // Get 3 indices starting from 5th_index 
-----
//+---------------------------+
//|--string.Replace(From,To)--|
//+---------------------------+
string newName = name.Replace("John", "Eric");
-----
//+----------------------------+
//|--string.IndexOf(ToSearch)--|
//+----------------------------+
int ItemIndex = fruit.IndexOf("orange"))
```
---
**FOR LOOP**
```cs
for(int i = 0; i < 16; i++)
{
    if(i % 2 == 1)
    {
        // Break entire loop
        break;
        // Skip the current iteration
        continue;
    }

    Console.WriteLine(i);
}
```
---
**WHILE LOOP**
```cs
int n = 0;

while( n == 0)
{
    Console.WriteLine("N is 0");
    n++;
}
```
