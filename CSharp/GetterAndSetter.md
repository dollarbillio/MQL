Getter and Setter Method
* The Method has helps returning ```private variables``` in class
```cs
class Movie
{
    private string rating;
    
    public Movie (string aRating)
    {
        // Not 'rating' attribute but "Rating" method 
        Rating = aRating
    }
    
    public string Rating
    {
        get {return rating;}
        set 
        {
            if (value == "G" || value == "PG" ) 
            {
                rating = value;
            } else 
            {
                rating = "NR";
            }
        }
    }
}

//---Access the Attribute with getter and setter method
Console.WriteLine(movie.Rating);
```
