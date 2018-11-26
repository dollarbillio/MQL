**CreateDataSeries()**
* Used in ```protected override void Initialize()```
* Not used when something like this: ```public IndicatorDataSeries Result { get; set; }```
```cs
public IndicatorDataSeries CreateDataSeries()

+-------|Example|-------+
private IndicatorDataSeries series;
protected override void Initialize()
{
    series = CreateDataSeries();
}

public override void Calculate(int index)
{
    series[index] = (MarketSeries.Close[index] + MarketSeries.Open[index]) / 2;
}
```
