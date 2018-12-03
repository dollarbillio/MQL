* **Math() Method**
```cs
Math()
```
* **Type Convert**
```cs
int age = Convert.ToInt16("45");
```
* **Switch Statement**
```cs
static int GetDay(int dayNum)
{
    string dayName;
    
    switch (dayNum)
    {
        case 0:
            dayName = "Monday";
            break;
        case 1:
            dayName = "Sunday";
            break;
        default:
            dayName = "Invalid dayNum";
    }
}
```
---
* **N dimensional Array**
```cs
// Two-dimensional array.
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// The same array with dimensions specified.
int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// A similar array with string elements.
string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

// Three-dimensional array.
int[, ,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
// The same array with dimensions specified.
int[, ,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } }, 
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

// Accessing array elements.
System.Console.WriteLine(array2D[0, 0]);
System.Console.WriteLine(array2D[0, 1]);
System.Console.WriteLine(array2D[1, 0]);
System.Console.WriteLine(array2D[1, 1]);
System.Console.WriteLine(array2D[3, 0]);
System.Console.WriteLine(array2Db[1, 0]);
System.Console.WriteLine(array3Da[1, 0, 1]);
System.Console.WriteLine(array3D[1, 1, 2]);
```
---
* **Error Handling**: ```Try{} Catch(){}```
```cs
try 
{
    Console.WriteLine("Enter a Number ");
	int num1 = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("Enter another Number: ");
	int num2 = Convert.ToInt16(Console.ReadLine());
			
	Console.WriteLine(num1 / num2);
} catch (Exception e) // Exception class
{
    Console.WriteLine(e.Message);
}
```
