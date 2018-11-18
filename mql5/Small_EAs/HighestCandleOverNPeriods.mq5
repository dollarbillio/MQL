void OnTick()
  {
   double HighestCandleM1;
   double High[];
   
   // Set the attribute of High[] into Series
   ArraySetAsSeries(High, true);
   CopyHigh(_Symbol, PERIOD_M1, 0, 11, High);
   HighestCandleM1 = ArrayMaximum(High, 0, 11);
   
   Comment("Highest Candle is: ", HighestCandleM1);
  }
