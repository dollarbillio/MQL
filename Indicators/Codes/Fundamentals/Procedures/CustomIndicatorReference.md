## Custom indicator:
* Indicators that you created in cAlgo
---
---
**Procedures**:
* Press ```Manage References``` button on the top left corner of the text editor
* In Indicators page of Reference Manager, check indicators which you want to be referenced and press Apply
---
---
```cs
sma = Indicators.GetIndicator<SampleSMA>(Source, SmaPeriod);

//---
[Indicator(IsOverlay = true, TimeZone = TimeZones.UTC)]
public class SampleReferenceSMA : Indicator
{
    [Parameter("Source")]
    public DataSeries Source { get; set; }
 
    [Parameter(DefaultValue = 14)]
    public int SmaPeriod { get; set; }
 
    [Output("Referenced SMA Output")]
    public IndicatorDataSeries refSMA { get; set; }
 
    private SampleSMA sma;
 
    protected override void Initialize()
    {
        sma = Indicators.GetIndicator<SampleSMA>(Source, SmaPeriod);
    }
 
    public override void Calculate(int index)
    {
        refSMA[index] = sma.Result[index];
    }
}
```
