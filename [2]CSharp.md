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
* **2-D Array [,]**
```cs
int[,] twoDArray = {
    {1, 2},
    {3, 4},
    {5, 6}
};

Console.WriteLine(twoDArray[0, 1); 

//---
>>> 2
```
```cs
// when not having any values assigned to newArray, initialize with new array with rows and columns
int[,] newArray = new int[2, 3]; // 2 rows, 3 columns

```
* Put on more commas for more dimension
```cs
int [,,,] newArray = new int [,,,];
```
