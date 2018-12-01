## Multiple TimeFrame Indicator
---
* Sounds complex
---
---
```cs
using System;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
 
namespace cAlgo.Indicators
{
    [Indicator(IsOverlay = true, TimeZone = TimeZones.UTC)]
    public class MultiSymbolMA : Indicator
    {
        private MovingAverage ma1, ma2, ma3;
        private MarketSeries series2, series3;
        private Symbol symbol2, symbol3;
 
        [Parameter(DefaultValue = "EURCHF")]
        public string Symbol2 { get; set; }
 
        [Parameter(DefaultValue = "EURCAD")]
        public string Symbol3 { get; set; }
 
        [Parameter(DefaultValue = 14)]
        public int Period { get; set; }
 
        [Parameter(DefaultValue = MovingAverageType.Simple)]
        public MovingAverageType MaType { get; set; }
 
        [Output("MA Symbol 1", Color = Colors.Magenta)]
        public IndicatorDataSeries Result1 { get; set; }
 
        [Output("MA Symbol 2", Color = Colors.Magenta)]
        public IndicatorDataSeries Result2 { get; set; }
 
        [Output("MA Symbol 3", Color = Colors.Magenta)]
        public IndicatorDataSeries Result3 { get; set; }
 
        protected override void Initialize()
        {            
            symbol2 = MarketData.GetSymbol(Symbol2);
            symbol3 = MarketData.GetSymbol(Symbol3);
 
            series2 = MarketData.GetSeries(symbol2, TimeFrame);
            series3 = MarketData.GetSeries(symbol3, TimeFrame);
 
            ma1 = Indicators.MovingAverage(MarketSeries.Close, Period, MaType);
            ma2 = Indicators.MovingAverage(series2.Close, Period, MaType);
            ma3 = Indicators.MovingAverage(series3.Close, Period, MaType);
        }
 
        public override void Calculate(int index)
        {
            // Defined Below
            ShowOutput(Symbol, Result1, ma1, MarketSeries, index);
            ShowOutput(symbol2, Result2, ma2, series2, index);
            ShowOutput(symbol3, Result3, ma3, series3, index);
        }
 
        private void ShowOutput(Symbol symbol, IndicatorDataSeries result, MovingAverage movingAverage, MarketSeries series, int index)
        {
            var index2 = series.OpenTime.GetIndexByTime(MarketSeries.OpenTime[index]);
            result[index] = movingAverage.Result[index2];
 
            string text = string.Format("{0} {1}", symbol.Code, Math.Round(result[index], symbol.Digits));
            ChartObjects.DrawText(symbol.Code, text, index,
                                  result[index], VerticalAlignment.Top, 
                                  HorizontalAlignment.Right, Colors.Yellow);
        }
    }
}
```
