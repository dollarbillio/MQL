void OnTick()
  {
   // Create An array
   MqlRates PriceInformation[];
   
   // Sort it from current candle to oldest candle
   ArraySetAsSeries(PriceInformation, true);
   
   // Copy price data into the array
   int Data=CopyRates(Symbol(), Period(), 0, Bars(Symbol(), Period()), PriceInformation);
   Comment("There are ", Bars(Symbol(), Period()), " in ", Period());
   
   if (PriceInformation[1].close > PriceInformation[2].close) Comment("It is going up");
   if (PriceInformation[1].close <= PriceInformation[2].close) Comment("It is going down");
  }
