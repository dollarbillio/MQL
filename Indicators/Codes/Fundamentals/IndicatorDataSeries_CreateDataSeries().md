**CreateDataSeries()**
* Used in ```protected override void Initialize()```
* Not used when something like this: ```public IndicatorDataSeries Result { get; set; }```
* Used when a series needs to be hidden from display and is used for calculation only ```private IndicatorDataSeries series;```
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
