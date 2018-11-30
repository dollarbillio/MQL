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
