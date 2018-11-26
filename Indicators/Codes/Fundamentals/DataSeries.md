**DataSeries**
* List of values, typically used to represent market price series.
* The values are accessed with an array-like [] operator.
* Can be used at [Parameter] to choose High, Open, Close, Low
```cs
public interface DataSeries
 
//--Example--
[Parameter]
public DataSeries Source { get; set; }
//...
[Output("Main")]        
public IndicatorDataSeries Result{ get; set; }
//...
Result[index] = Source[index] * exp + previousValue * (1 - exp);
//...
Result[index] = (MarketSeries.Close[index] + MarketSeries.Open[index]) / 2;
//...
```
---
**+----------------+|Built-in methods|+----------------+**
* Count: Gets the total number of elements contained in the DataSeries.
```cs
public int Count{ get; }
    
//--Example
protected override void OnTick()
{
    int total = MarketSeries.Close.Count;
    Print("The total elements contained in the MarketSeries.Close Series is: {0}", total);
    // The last index is number of available price in the MarketSeries.Close
    int lastIndex = total - 1;    
    double lastCloseValue = MarketSeries.Close[lastIndex];
    //Print the last value of the series
    Print("The last value of Close Series is: {0}", lastCloseValue);
}
```
* This[int index]: Gets the value in the dataseries at the specified position.
```cs
public double this[int index]{ get; }
    
//--Example
//...
[Parameter("Data Source")]
// Is Source the DataSeries that contains market price (High, Low, Close, Open) that we need to choose from?
public DataSeries Source { get; set; }
//...
[Output("Main")]
public IndicatorDataSeries Result{ get; set; }
//...
public override void Calculate(int index)
{
    // This is the simple moving average calculation.
    double sum = 0.0;
    
    // Index in Source
    for (int i = 0; i <= Periods-1; i++)
    {
        // Source[i] is the item contained in Source at position i
        sum += Source[i];
    }
    Result[index] = sum / Periods;
}
```
* LastValue:Gets the last value of this DataSeries
```cs
public double LastValue{ get; }
    
//--Example
//...
protected override void OnTick()
{
    double lastValue = MarketSeries.Close.LastValue;
    Print("The last value of MarketSeries.Close Series is: {0}", MarketSeries.Close.LastValue);
    // Property LastValue has an accessor but no setter, i.e. LastValue can be retrieved but not set.
    // The following code will produce an error
    MarketSeries.Close.LastValue = 100;
}
```
* Last(): Access a value in the dataseries certain bars ago
```cs
public double Last(int index)
    
//--Example
double value = MarketSeries.Close.Last(5);
Print("The close price 5 bars ago was: {0}", value);
    
double previousOpen = MarketSeries.Open.Last(1);
double previousClose = MarketSeries.Close.Last(1);  
Print("Open: {0}, Close: {1}", previousOpen, previousClose);
    
double currentClose = MarketSeries.Close.Last(0);
Print("Current Close: {0}", currentClose);
```
