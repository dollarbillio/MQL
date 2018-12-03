**Class Constructor**
* Can have many Class Constructors
```cs
class Book
{
    public string title;
    public string author;
    public double reviews
    
    // Class Constructor
    public Book () 
    {
    }
    
    // Class Constructor
    public Book (string aTitle, string aAuthor)
    {
    
    }
    
    // Class Method
    public bool GoodReviews()
    {
        if (reviews > 3.0)
        {
            return true;
        }
        return false;
    }
}
```
