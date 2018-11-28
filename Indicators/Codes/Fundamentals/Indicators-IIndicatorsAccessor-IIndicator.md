**```IIndicatorsAccessor Interface```**: 
* Declare the the variable as Accessor to Indicators
```cs
public interface IIndicatorsAccessor
```
**```IIndicatorsAccessor Interface => SimpleMovingAverage Interface```**
* ```SimpleMovingAverage Interface``` inherits from ```MovingAverage``` and ```IIndicator``` Interface
```cs
public interface SimpleMovingAverage : MovingAverage, IIndicator

//--Example
[Indicator]
public class SimpleMovingAverageExample : Indicator
{
    [Parameter]
    public DataSeries Source { get; set; }
    
    [Parameter(DefaultValue = 14, MinValue = 2)]
    public int Periods { get; set; }
    
    [Output("Result", Color = Colors.Orange)]
    public IndicatorDataSeries Result { get; set; }
    
    private SimpleMovingAverage _simpleMovingAverage;
    protected override void Initialize()
    {
        _simpleMovingAverage = Indicators.SimpleMovingAverage(Source, Periods);
    }
    public override void Calculate(int index)
    {
        var average = _simpleMovingAverage.Result[index];
        double sum = 0;
        for (var period = 0; period < Periods; period++)
        {
            sum += Math.Pow(Source[index - period] - average, 2.0);
        }
        Result[index] = Math.Sqrt(sum / Periods);
    }
}
```
**SimpleMovingAverage.Result == IndicatorDataSeries**
```cs
public SimpleMovingAverage SimpleMovingAverage(DataSeries source, int periods)

private SimpleMovingAverage sma;
protected override void Initialize()
{
    sma = Indicators.SimpleMovingAverage(MarketSeries.Close, 14);
}
public override void Calculate(int index)
{
    Result[index] = sma.Result[index]; 
}
```
---
```cs
public interface IIndicator
```
* Base interface for all Indicators
* **```[Method] Calculate()```**: Method to calculate the value(s) of indicator for given index.
```cs
//...Example 1
[Parameter("Period", DefaultValue = 14)]
public int Period { get; set; }
//...
public override void Calculate(int index)
{
    // if the index is less than Period exit
    if(index < Period)
        return;
    // Maximum returns the largest number in the Series in the range [Series[index-Period], Series[index]]
    double high = MarketSeries.High.Maximum(Period);
    // Minimum returns the smallest number in the Series in the range [index - Period, index]
    double low = MarketSeries.Low.Minimum(Period);
    double center = (high + low) / 2;
    // Display Result of Indicator
    Result[index] = center;
}

// Example_2
[Parameter("Period", DefaultValue = 14)]
public int Period { get; set; }
//...
public override void Calculate(int index)
{
    // Calculate value at specified index
    
    // if the index is less than Period exit
    if(index < Period)
        return;
    // Maximum returns the largest number in the Series in the range [Series[index-Period], Series[index]]
    double high = MarketSeries.High.Maximum(Period);
    // Minimum returns the smallest number in the Series in the range [index - Period, index]
    double low = MarketSeries.Low.Minimum(Period);
    double center = (high + low) / 2;
    // Display Result of Indicator
    Result[index] = center;
```
---
**```IIndicatorAccessor Indicators```**
* Access to built-in Indicators
* Returns IIndicatorAccessor
```cs
public IIndicatorsAccessor Indicators{ get; }

protected override void Initialize()
{
    //Use MarketSeries price data as parameters to indicators
    _ma = Indicators.SimpleMovingAverage(MarketSeries.Close, 20);
}
```
---
```cs
public interface MovingAverage : IIndicator
```
* Inherits from IIndicator Interface
*  ```.Result``` returns ```IndicatorDataSeries```

```cs
private MovingAverage ma;
protected override void Initialize()
{
    ma = Indicators.MovingAverage(Source, MAPeriods, MAType);
}
//...
public override void Calculate(int index)
{
    MA[index] = ma.Result[index];   
    //...
}
```

