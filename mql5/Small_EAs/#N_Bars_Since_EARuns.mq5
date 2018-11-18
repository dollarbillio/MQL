void OnTick()
{
   // create a price array
   MqlRates priceData[];
   
   // Set priceData into a time series
   ArraySetAsSeries(priceData, true);
   
   // Copy Candle Prices for 10 candles into array
   CopyRates(Symbol(), Period(), 0, 10, priceData);
   
   // Create a Counter for the candle
   static int candleCounter;
   
   // Create Datetime variable for the last time stamp
   static datetime LastCheckTime;
   
   // Create Datetime variable for current candle
   datetime CurrentTime;
   
   // read time stamp for current candle in array
   CurrentCandle=priceData[0].time;
   
   // if the current time stamp is different from last time checked
   if (timeStampLastCheck!=timeStampCurrentCandle) 
      {
         // If market is running (timeStampLastCheck[timeStampCurrentCandle-t1] < timeStampCurrentCandle
         timeStampLastCheck = timeStampCurrentCandle;
         candleCounter+=1;
      }
   
   Comment("Bars Processed since EA born: ", candleCounter);
}
