## Combining Two Or More Indicators 
---
* Combining Two or More Indicators to display on chart
---
```cs
// combines the Aroon, RSI and Directional Movement System in one
using cAlgo.API;
using cAlgo.API.Indicators;
 
namespace cAlgo.Indicators
{
    [Indicator(IsOverlay = false, TimeZone = TimeZones.UTC, ScalePrecision = 5)]
    public class Aroon_RSI_DMS : Indicator
    {
        private Aroon aroon ;
        private RelativeStrengthIndex rsi;
        private DirectionalMovementSystem dms;
 
        [Parameter]
        public DataSeries Source { get; set; }
 
        [Parameter(DefaultValue = 14)]
        public int Periods { get; set; }
         
 
        [Output("Aroon Up", Color = Colors.LightSkyBlue)]
        public IndicatorDataSeries AroonUp { get; set; }
 
        [Output("Aroon Down", Color = Colors.Red)]
        public IndicatorDataSeries AroonDn { get; set; }
 
        [Output("Rsi", Color = Colors.Green)]
        public IndicatorDataSeries Rsi { get; set; }
 
        [Output("DI Plus", Color = Colors.DarkGreen)]
        public IndicatorDataSeries DmsDIPlus { get; set; }
 
        [Output("DI Minus", Color = Colors.DarkRed)]
        public IndicatorDataSeries DmsDIMinus { get; set; }
 
        [Output("ADX", Color = Colors.Blue)]
        public IndicatorDataSeries DmsADX { get; set; }
 
 
        protected override void Initialize()
        {
            // Initialize and create nested indicators
            aroon = Indicators.Aroon(Periods);
            rsi = Indicators.RelativeStrengthIndex(Source, Periods);
            dms = Indicators.DirectionalMovementSystem(Periods);
        }
 
 
        public override void Calculate(int index)
        {
            AroonUp[index] = aroon.Up[index];
            AroonDn[index] = aroon.Down[index];
 
            Rsi[index] = rsi.Result[index];
 
            DmsADX[index] = dms.ADX[index];
            DmsDIMinus[index] = dms.DIMinus[index];
            DmsDIPlus[index] = dms.DIPlus[index];
        } 
    }
}
```
