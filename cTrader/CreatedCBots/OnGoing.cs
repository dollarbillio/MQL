using System;
using cAlgo.API;
using cAlgo.API.Internals;
using cAlgo.API.Indicators;
using cAlgo.Indicators;

namespace cAlgo
{
    [Indicator(IsOverlay = false, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class RealShitAroundHere : Indicator
    {
        // [index - 1]th candle
        public double lastHigh;
        public double lastLow;
        public double lastOpen;
        public double lastClose;
        
        // [index - 2]th candle
        public double twoLastHigh;
        public double twoLastLow;
        public double twoLastClose;
        public double twoLastOpen;
        
        public double currentATR;

        [Parameter("ChooseBasicStopUnits")
        public int basicStopUnits { get; set; }
        
        [Output("Main")]
        public IndicatorDataSeries Result { get; set; }


        protected override void Initialize()
        {

        }

        public override void Calculate(int index)
        {
            // if the candle is running at index 0, set all to 0
            if (index == 0)
            {
                lowestLow = 0;
                highestHigh = 0;
            }
            else if (index = 1)
            {
                lowestLow = MarketSeries.Low[0];
                highestHigh = MarketSeries.High[0];
            }
            // This is the main logic of the algorithm
            else if (index > 1)
            {
                SetInfoLastCandle();
                SetInfoTwoLastCandle();
                
                // Total inside bar
                bool insideBar = (lastLow >= twoLastLow) && (lastHigh <= twoLastHigh);
                
                // Inside close and update
                bool insideClose = (lastClose <= twoLastHigh) && (lastClose >= twoLastLow);
                
                
                // inside update High
                bool bullCandle = lastClose > lastOpen;
                
                // Outside bar
                bool outsideClose = (lastClose < twoLastLow) || (lastClose > twoLastHigh);
                
                if (!insideBar) 
                    if (insideClose)
                    {
                        if (bullCandle) && (High
                    }
                else if (outsideClose)
                {
                    // So stuffs
                }                
                
            }            
        
        
        
        
        
        
        public void SetInfoLastCandle()
        {
            lastHigh = MarketSeries.High[index - 1];
            lastLow = MarketSeries.Low[index - 1];
            lastClose = MarketSeries.Close[index - 1];
            lastOpen = MarketSeries.Open[index - 1];
        }
        
        public void SetInfoTwoLastCandle()
        {
            twoLastHigh = MarketSeries.High[index - 2];
            twoLastLow = MarketSeries.Low[index - 2];
            twoLastClose = MarketSeries.Close[index - 2];
            twoLastOpen = MarketSeries.Open[index - 2];
        }
            
            
            
           
            
            // +-------------------------------------------+ 
            // index >= 1 is the main part of the algorithm 
            // +-------------------------------------------+
           
                // if the first candle is bull, update high,
                if (currentClose > currentOpen)
                {
                    highestHigh = currentHigh;
                }
                else
                {
                    lowestLow = currentLow;
                }
            
            
                // This statement check the inside bar condition
            
            
            
            
            
            }
            
            Before any these, we check the previousClose distance vs the lowest Low (which is the close and low of candle with 
            the lowestLow) 
            
            
            if candle is inside(currentClose < previousHIgh, > previousLow) + (currentLow > previousLow, currentHigh < previous HighMinusLow)
                
                we either update the low/high or not
                but we are still inside candle


            if the inside candle has one of the High/Low that is either Higher/Lower than the previousLow/previousHigh;
                        
            
            
            // Outside candle pattern
            if the currentClose > highestHigh or currentClose < lowestLow)
                this is outside bar
                
                    // if this is a bear:
                    Update the lowestLow 

                    // if this is a bull
                    Update the highestHigh


            
            if (index == 1):
            {
                lowestLow = MarketSeries.Low[0];
                highestHigh = MarketSeries.High[0];
                
                initClose = MarketSeries.Close[0];
                initOpen = MarketSeries.Open[0];
                
                if (initClose - initOpen > 0)
                    # The candle is bull
                else if (initClose - initOpen <= 0)
                    # The candle is bear
             }   
                
            # the candle is bull, we look for bear short
            if (firstCandleIsBull)
            {
                if (currentHigh > highestHigh)
                    highestHigh = currentHigh;
                
                if (currentClose < highestHigh 
            }
            
            // Calculate value at specified index
            // Result[index] = ...
            
            // Go short
            if (currentclose < highestHigh - ATR)
                Sell Order
            if (currentclose > lowestLow + ATR)
                Buy Order            
        
        }
        
        if the bar is the normal bar (What is range of normal bar)
        if the bar is not normal bar (What is range of not normal bar)
        
            we wait for normal bar to comback and start updating again
                if the current bar is long, update high, if the current bar is short, update low to start evaluating position entry
                
        MoneyManagement: lock stoploss MoneyManagement: there will be two positions, first position will cover StopLoss + (otherCost)
                                                        The second will go as the rule of entry and exist
                                                        
        Also need to add condition to theClose relative to the previous highestHigh/LowestLow in order to determine the risk of the candle. If the risk is too 
        much, we forgo the opportunity,

        After we wait for first candle to close, we set the stoploss at entry price + commission to cover for commission
        The second candle will either get stop out or go at least this (stoploss*2 + commission) before triggering the usual 
        entry and sell signal. Meaning if the condition is right, we will have some pips
        
        trailing stopLoss = highestcurrentHigh/lowestcurrentClose +- 3 * unit of stop
        
        How to handle excessive bar: If the bar is too excessive, we skip the bar and wait for the bar to come back at range 
        that is in than the predefined range of normal candle 
        
        
        // Update the Extreme Points
        public void UpdateLowestLow()
        {
            lowestLow = MarketSeries.Low[index - 2]
        }
        
        public void UpdateHighestHigh()
        {
            highestHigh = MarketSeries.Close[index - 2] 
        }
    }
}
