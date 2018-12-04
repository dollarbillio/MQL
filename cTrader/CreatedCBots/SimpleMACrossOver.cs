using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;

namespace cAlgo.Robots
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class SimpleMovingAverageCrossOver : Robot
    {
        private const string label = "ExpMA728";
        // These two variables will be in OnStart()
        private MovingAverage shortMA;
        private MovingAverage longMA;

        // [START] - Parameter Settings-
        // Able to choose MA type, default value: Exp
        [Parameter("ChooseMAType", DefaultValue = MovingAverageType.Exponential)]
        public MovingAverageType MAType { get; set; }

        //------------------------------------------
        // Create long and short MA per
        [Parameter("ChooseShortMA", DefaultValue = 7)]
        public int shortMAperiod { get; set; }

        [Parameter("ChooseLongMA", DefaultValue = 21)]
        public int longMAperiod { get; set; }
        // -----------------------------------------

        // Choose High Low Close Open
        [Parameter()]
        public DataSeries SourceSeries { get; set; }


        // Choose the value trade in pips 
        [Parameter("ChooseLots", DefaultValue = 0.01, Step = 0.01)]
        public double Lots { get; set; }
        // [END] - Parameters

        // MAIN PROGRAM
        protected override void OnStart()
        {
            longMA = Indicators.MovingAverage(SourceSeries, longMAperiod, MAType);
            shortMA = Indicators.MovingAverage(SourceSeries, shortMAperiod, MAType);
        }

        protected override void OnBar()
        {
            // This will keep track of a single long and short position by this robots
            Position longPosition = Positions.Find(label, Symbol, TradeType.Buy);
            Position shortPosition = Positions.Find(label, Symbol, TradeType.Sell);

            double stopLoss = Symbol.Ask - 11 * Symbol.PipSize;
            double takeProfit = Symbol.Ask + 100 * Symbol.PipSize;

            if (longPosition != null)
                if (longPosition.Pips > 30.0)
                    ModifyPosition(longPosition, stopLoss, takeProfit);
            if (shortPosition != null)
                if (shortPosition.Pips < 30.0)
                    ModifyPosition(shortPosition, stopLoss, takeProfit);

            // 
            double lastShortMA = shortMA.Result.Last(1);
            double lastLongMA = longMA.Result.Last(1);
            double twoLastShortMA = shortMA.Result.Last(3);
            double twoLastLongMA = longMA.Result.Last(3);
            //&&  previousSlowMa > previousFastMa

            if (lastShortMA > lastLongMA && twoLastShortMA < twoLastLongMA)
            {
                if (shortPosition != null)
                    ClosePosition(shortPosition);
                if (longPosition == null && SourceSeries.Last(1) > lastShortMA)
                    ExecuteMarketOrder(TradeType.Buy, Symbol, 2000, label, 17, 200, 2, "Nothing");
            }
            //&& previousSlowMa < previousFastMa
            else if (lastShortMA < lastLongMA && twoLastShortMA > twoLastLongMA)
            {
                if (longPosition != null)
                    ClosePosition(longPosition);
                if (shortPosition == null && SourceSeries.Last(1) < lastShortMA)
                    ExecuteMarketOrder(TradeType.Sell, Symbol, 2000, label, 17, 200, 2, "Nothing");
            }
        }
    }
}
