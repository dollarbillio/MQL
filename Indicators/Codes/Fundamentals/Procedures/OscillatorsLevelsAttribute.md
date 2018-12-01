## Oscillators and the Levels Attribute
---
* The momentum oscillator typically oscillates around 100, so we will add a level line at that value using the Levels attribute
* Can only be used when the indicator is ```IsOverlay = true``` 
* Multiple Levels
```
[Levels(0, 50, 100)]
[Levels(50.5, 50.75)]
[Levels(0.001, 0.002)]
```
```cs
namespace cAlgo.Indicators
{
    [Levels(100)]
    [Indicator("Momentum Oscillator")]
    public class MomentumOscillator : Indicator
    {
        [Parameter]
        public DataSeries Source { get; set; }
 
        [Parameter(DefaultValue = 14, MinValue = 1)]
        public int Periods { get; set; }
 
        [Output("Main", Color = Colors.Green)]
        public IndicatorDataSeries Result { get; set; }
 
        public override void Calculate(int index)
        {
            Result[index] = 100 * Source[index] / Source[index - Periods];
        }
    }
}
```
