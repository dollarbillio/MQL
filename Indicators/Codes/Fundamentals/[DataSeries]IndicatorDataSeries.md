**IndicatorDataSeries**
* Used when making Indicator
* Parent Class: DataSeries
```cs
public interface IndicatorDataSeries : DataSeries

// +-------|Example|-------+

// The following example is the calculation of the simple moving average 
// of the median price
[Output("Result")]
public IndicatorDataSeries Result { get; set; }
private IndicatorDataSeries _dataSeries;
private SimpleMovingAverage _simpleMovingAverage;

protected override void Initialize()
{
    // Create A new DataSeries()
    _dataSeries = CreateDataSeries();
    _simpleMovingAverage = Indicators.SimpleMovingAverage(_dataSeries, 14);
}
public override void Calculate(int index)
{
    _dataSeries[index] = (MarketSeries.High[index] + MarketSeries.Low[index])/2;
    Result[index] = _simpleMovingAverage.Result[index];
}
```
---
**+-------------+| Built-in Methods |+-------------+**
**```this[int index]```**: Gets or sets the value at the specified index.
```cs
public double this[int index]{ get; set; }

//--Example
// The following example is the calculation of the median price
[Output("Result")]
public IndicatorDataSeries Result { get; set; }
private IndicatorDataSeries _dataSeries;

protected override void Initialize()
{
    _dataSeries = CreateDataSeries();
}
public override void Calculate(int index)
{
    
    _dataSeries[index] = (MarketSeries.High[index] + MarketSeries.Low[index])/2;
    
    // Get the value of _dataSeries at index 
    // and set the value of Result at index
    Result[index] = _dataSeries[index];
}
```
