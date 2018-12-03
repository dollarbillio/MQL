**Overriding Method**
* The class that inherits from the super class, if they have the same method, will have its method overriding that of the super class
---
```cs
Class Chef
{
    public virtual void MakeSpecialDisk()
    {
        Console.WriteLine("Chef makes BBQ");
    }
}

// Child Class
Class ItalianCheck
{
    // override the virtual MakeSpecialDisk()
    public override void MakeSpecialDisk()
    {
        Console.WriteLine("Chef makes steak");
    }
}
```
