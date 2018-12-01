```Indicators.GetIndicator<CustomIndicators>```
* Get Results of Custom Indicators from ```Manage References```
```cs
public TIndicator GetIndicator(MarketSeries marketSeries, Object[] parameterValues)
```
* Initializes the custom indicator
```cs
public interface IIndicatorsAccessor

//---
protected override void Initialize()
{
    sma = Indicators.GetIndicator<SampleSMA>(Source, Period);
}
public override void Calculate(int index)
{
    // Display the sma result on the chart
    Result[index] = sma.Result[index]; 
}
```
