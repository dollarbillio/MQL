**Static Class Attribute**
* Attribute of Class, change every time an instance is created
---
```cs
Class Song
{
    public static int songCounts;
    
    public Song ()
    {
        songCounts++;
    }
    
    // Method used to return songCounts from a class instance
    public int getsongCounts()
    {
        return songCounts
    }
}
```

