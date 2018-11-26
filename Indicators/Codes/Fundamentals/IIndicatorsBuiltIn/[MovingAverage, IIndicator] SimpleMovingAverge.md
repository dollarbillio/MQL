**```SimpleMovingAverage Interface```**
* SimpleMovingAverage Class
```cs
public interface SimpleMovingAverage : MovingAverage, IIndicator

+------|Example|------+
// This indicator will return standard deviation over period
[Indicator]
public class StandardDeviationNPeriods : Indicator
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
        // Initialize SimpleMovingAverage
        _simpleMovingAverage = Indicators.SimpleMovingAverage(Source, Periods);
    }
    
    public override void Calculate(int index)
    {
        // Since SimpleMovingAverage inherits [Result method] from [MovingAverage, IIndicator]
        var average = _simpleMovingAverage.Result[index];
        double sum = 0;
        for (var period = 0; period < Periods; period++)
        {
            // Sum of all squaredError from mean
            sum += Math.Pow(Source[index - period] - average, 2.0);
        }
        // Return standard deviation over the period
        Result[index] = Math.Sqrt(sum / Periods);
    }
}
```
---
**```IIndicatorsAccessor.SimpleMovingAverage```**
* Access the Indicator
```cs
public SimpleMovingAverage SimpleMovingAverage(DataSeries source, int periods)

//--Example
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
