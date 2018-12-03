**Static method in class**
* Does't need to initialize an instance to use the medthod
---
---
```cs
Class Book 
{
    public static void SayHi()
    {
        Console.WriteLine("Hello World")
    }
}

//---Call the Method
static void Main(string[] args)
    {
       Book.SayHi("Mike");
    }
```
