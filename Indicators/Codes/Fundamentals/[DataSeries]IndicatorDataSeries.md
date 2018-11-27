# IndicatorDataSeries
```cs
public interface IndicatorDataSeries : DataSeries
```
* Represents a mutable array of values. An extension of DataSeries used to represent indicator values.
```cs
// Example1
//This will be the output result of your indicator
[Output("Result", Color = Colors.Orange)]
public IndicatorDataSeries Result { get; set; }

// Example2
[Output("Result")]
public IndicatorDataSeries Result { get; set; }
private IndicatorDataSeries _dataSeries;
private SimpleMovingAverage _simpleMovingAverage;
protected override void Initialize()
{
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
```cs
public IndicatorDataSeries Result{ get; }
```
* Equals to for example: ```SimpleMovingAverage.Result```
```cs
//...
[Output]
public IndicatorDataSeries Result { get; set; }
private MovingAverage ma;
protected override void Initialize()
{
    ma = Indicators.MovingAverage(Source, MAPeriods, MAType);
}
public override void Calculate(int index)
{
    Result[index] = ma.Result[index];   
    //...
}
```
---

```cs


```
