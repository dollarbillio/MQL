```cs
using System;
using cAlgo.API;
using cAlgo.API.Internals;
using cAlgo.API.Indicators;
using cAlgo.Indicators;

namespace cAlgo
{
    [Indicator(IsOverlay = false, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class AverageTrueRangeModified : Indicator
    {
        //--[Begin] Variables in Initialize()
        private TrueRange longTrueRange;
        private TrueRange shortTrueRange;
        //--[END] Variaables in Initialize()

        //--[BEGIN] Choose Parameters
        [Parameter("LongTRPeriod", DefaultValue = 21)]
        public int longTRPeriod { get; set; }

        [Parameter("LongTRPeriod", DefaultValue = 7)]
        public int shortTRPeriod { get; set; }
        //--[END] Choose Parameters   

        //--[BEGIN] Output attributes
        [Output("longATR", Color = Colors.Turquoise)]
        public IndicatorDataSeries longATR { get; set; }

        [Output("ShortATR", Color = Colors.Turquoise)]
        public IndicatorDataSeries shortATR { get; set; }
        //--[END] Output attributes

        //--[BEGIN] Main program
        protected override void Initialize()
        {
            longTrueRange = Indicators.TrueRange();
            shortTrueRange = Indicators.TrueRange();
        }

        public override void Calculate(int index)
        {
            // Longterm TrueRange
            if (index < longTRPeriod)
                longATR[index] = longTrueRange.Result[index];
            else if (index >= longTRPeriod)
                longATR[index] = SumOfIndex(longTrueRange, longTRPeriod, index) / longTRPeriod;

            // Short Term True Range
            if (index < shortTRPeriod)
                shortATR[index] = shortTrueRange.Result[index];
            else if (index >= longTRPeriod)
                shortATR[index] = SumOfIndex(shortTrueRange, shortTRPeriod, index) / shortTRPeriod;
        }

        public double SumOfIndex(TrueRange trueRange, int Period, int index)
        {
            double sum = 0.0;
            for (int i = index - Period + 1; i <= index; i++)
            {
                sum += trueRange.Result[i];
            }

            return sum;
        }
    }
}
```
