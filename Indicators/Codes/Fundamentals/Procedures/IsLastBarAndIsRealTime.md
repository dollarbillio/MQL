**IsLastBarAndIsRealTime**
---
* the IsLastBar property can be checked, to determine if
the index parameter of the Calculate method, is that of the last bar
---
---
```cs
[Indicator(IsOverlay = true, TimeZone = TimeZones.UTC)]
public class TimeInDifferentParts : Indicator
{
    public override void Calculate(int index)
    {
        if (IsRealTime)
        DisplayTime(index);
    }
 
    protected void DisplayTime(int index)
    {
    DateTime nyDateTime = MarketSeries.OpenTime[index].AddHours(-5);
    DateTime tokyoDateTime = MarketSeries.OpenTime[index].AddHours(7);
             
    string nyTime = nyDateTime.ToShortTimeString();
    string tokyoTime = tokyoDateTime.ToShortTimeString();
 
    ChartObjects.DrawText("Title", "Last Bar OpenTime ",StaticPosition.TopLeft, Colors.Lime); 
    ChartObjects.DrawText("NY", "NY " + nyTime, 
    StaticPosition.TopLeft, Colors.Lime);
    ChartObjects.DrawText("Tokyo", " Tokyo " + tokyoTime, StaticPosition.TopLeft, Colors.Lime);
    }
}
```
