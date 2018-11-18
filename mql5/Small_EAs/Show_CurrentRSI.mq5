void OnTick()
{
   // create an RSI array
   double myRSIArray[];
   
   // Set RSI definition
   int myRSIDefinition = iRSI (_Symbol, _Period, 14, PRICE_CLOSE);
   
   // Copy Candle Prices for 10 candles into array
   ArraySetAsSeries(myRSIArray, true);
   
   // Define Make Series Buffer
   CopyBuffer(myRSIDefinition, 0,0,10,myRSIArray);
   
   // calculate EA for the current candle
   double myRSIValue = NormalizeDouble(myRSIArray[0], 2);
   
   // Create Datetime variable for current candle
   Comment("\nCurrentRSI: ", myRSIValue);
}
