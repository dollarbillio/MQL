```Indicators.GetIndicator```
```cs
public TIndicator GetIndicator(MarketSeries marketSeries, Object[] parameterValues)
```
* Initializes the custom indicator
```cs
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
