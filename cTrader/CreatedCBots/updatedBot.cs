using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;


/*
 *  POPULAR SIMPLE MOVING AVERAGES
 *
 *  The simple moving average (SMA) is the most basic of the moving averages used for trading. 
 *  The simple moving average formula is calculated by taking the average closing price of a stock over the last "x" periods.
 *  
 *  5 - SMA  - For the hyper trader.  This short of an SMA will constantly give you signals.  The best use of a 5-SMA is as a trade trigger in conjunction with a longer SMA period.
 *  10 - SMA - popular with the short-term traders.  Great swing traders and day traders.
 *  20 - SMA - the last stop on the bus for short-term traders.  Beyond 20-SMA you are basically looking at primary trends.
 *  50 - SMA - use the trader to gauge mid-term trends.
 *  200 -SMA - welcome to the world of long-term trend followers.  Most investors will look for a cross above or below this average to represent if the stock is in a bullish or bearish trend.
 */

namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class PracticeBot : Robot
    {

        // +---------------------------
        // | [START] Custom Parameters
        // +---------------------------
        // Robot Name
        [Parameter("Instance Name", DefaultValue = "EMA_cross")]
        public string instanceName { get; set; }

        // Choose the source of calculation
        [Parameter("ShortMASourcePrice")]
        public DataSeries shortSource { get; set; }

        // Choose the source of calculation
        [Parameter("longMASourcePrice")]
        public DataSeries longSource { get; set; }

        // Set Default Lot Size 
        [Parameter("Lot Size", DefaultValue = 0.01)]
        public double lotSize { get; set; }

        // Short and Long Moving Average
        [Parameter("Period SMA #1", DefaultValue = 7, MinValue = 1, MaxValue = 100)]
        public int shortPeriod { get; set; }

        [Parameter("Period SMA #2", DefaultValue = 21, MinValue = 1, MaxValue = 100)]
        public int longPeriod { get; set; }

        [Parameter("Calculate OnBar", DefaultValue = false)]
        public bool calculateOnBar { get; set; }

        // Variables to be initialized in Onstart()
        private ExponentialMovingAverage shortEMA { get; set; }
        private ExponentialMovingAverage longEMA { get; set; }

        [Parameter()]
        public DataSeries SourceSeries { get; set; }
        // +---------------------------
        // | [END] Custom Parameters
        // +---------------------------


        // +-----------------------------
        // | [START] MAIN PROGRAM
        // +-----------------------------
        protected override void OnStart()
        {
            // construct the indicators
            shortEMA = Indicators.ExponentialMovingAverage(shortSource, shortPeriod);
            longEMA = Indicators.ExponentialMovingAverage(longSource, longPeriod);
        }

        /// <summary>
        /// This method is called at every candle (bar) close, when it has formed
        /// </summary>
        protected override void OnBar()
        {
            if (calculateOnBar)
            {
                return;
            }

            ManagePositions();
        }

        protected override void OnStop()
        {
            // unused
        }

        // [FUNCTION_START] -- Main function to manage Positions
        private void ManagePositions()
        {
            // Generate candle index
            // index 0
            double currentShortMA = shortEMA.Result.Last(0);
            double currentLongMA = longEMA.Result.Last(0);

            // index 1
            double lastShortMA = shortEMA.Result.Last(1);
            double lastLongMA = longEMA.Result.Last(1);

            // index 2
            double twoLastShortMA = shortEMA.Result.Last(2);
            double twoLastLongMA = longEMA.Result.Last(2);

            // Modify Existing Position
            ModifyPosition(TradeType.Buy);
            ModifyPosition(TradeType.Sell);

            if ((lastShortMA >= lastLongMA + 0.5 * Symbol.PipSize) && (twoLastShortMA <= twoLastLongMA) && (SourceSeries.Last(1) >= shortEMA.Result.Last(1) + 0.25 * Symbol.PipSize))
            {
                if (!PositionExists(TradeType.Buy))
                    //&& (SourceSeries.LastValue > shortEMA.Result.LastValue))
                    OpenPosition(TradeType.Buy);
                ClosePosition(TradeType.Sell);
            }

            // if a sell position is already open and signal is buy do nothing
            if ((lastShortMA <= lastLongMA - 0.5 * Symbol.PipSize) && (twoLastShortMA >= twoLastLongMA) && (SourceSeries.Last(1) <= shortEMA.Result.Last(1) - 0.25 * Symbol.PipSize))
            {
                // if there is no sell position open, open one and close any buy position that is open
                // && (SourceSeries.LastValue < shortEMA.Result.LastValue))
                if (!PositionExists(TradeType.Sell))
                    //&& (SourceSeries.LastValue < shortEMA.Result.LastValue))
                    OpenPosition(TradeType.Sell);
                ClosePosition(TradeType.Buy);
            }
        }

        // [Function_START]--Opens a new long/short position
        private void OpenPosition(TradeType tradeType)
        {
            // calculate volume from lot size.
            double volume = Symbol.QuantityToVolumeInUnits(lotSize);

            // open a new position
            ExecuteMarketOrder(tradeType, Symbol, volume, instanceName, 17, 300);
        }
        // [Function_END]


        // [Function_START]--Close Position
        private void ClosePosition(TradeType type)
        {
            Position p = Positions.Find(instanceName, Symbol, type);

            if (p != null)
            {
                ClosePosition(p);
            }
        }

        // [Function_END]--Close Position

        // [Function_START]-- Retrieve Position by Type to Use Above
        private bool PositionExists(TradeType tradeType)
        {
            var p = Positions.FindAll(instanceName, Symbol, tradeType);

            if (p.Count() >= 1)
            {
                return true;
            }

            return false;
        }
        // [Function_END]-- Retrieve Position by Type to Use Above

        // [Function_START]--ModifyTrailingStop
        private void ModifyPosition(TradeType tradeType)
        {
            Position position = Positions.Find(instanceName, Symbol, tradeType);

            double stopLoss;
            double takeProfit;

            if (tradeType == TradeType.Buy)
            {
                stopLoss = Symbol.Bid - 15 * Symbol.PipSize;
                takeProfit = Symbol.Bid + 170 * Symbol.PipSize;
            }
            else
            {
                stopLoss = Symbol.Ask + 15 * Symbol.PipSize;
                takeProfit = Symbol.Ask - 170 * Symbol.PipSize;
            }

            if ((position != null) && (position.Pips > 20))
                ModifyPosition(position, stopLoss, takeProfit, true);
        }
        // +-----------------------------
        // | [END] MAIN PROGRAM
        // +-----------------------------       
    }
}
