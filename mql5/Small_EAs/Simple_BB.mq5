void OnTick()
  {
   // Create an Array for several prices
   double UpperBollinger[];
   double MiddleBolinger[];
   double LowerBollinger[];
   
   // Set all Bollingers as times series
   ArraySetAsSeries(UpperBollinger, true);
   ArraySetAsSeries(MiddleBolinger, true);
   ArraySetAsSeries(LowerBollinger, true);
   
   
   // define the properties of bollinger band
   int BB_properties = iBands(_Symbol, _Period, 20, 0, 2, PRICE_CLOSE);
   CopyBuffer(BB_properties, 0, 0, 10, MiddleBolinger);
   CopyBuffer(BB_properties, 1, 0, 10, UpperBollinger);
   CopyBuffer(BB_properties, 2, 0, 10, LowerBollinger);
   
   // MA for the current candle
   double currMidBB = MiddleBolinger[0];
   double currUpperBB = UpperBollinger[0];
   double currLowerBB = LowerBollinger[0];
   
   // Output on chart current MA
   Comment ("MiddleBand: ", currMidBB, "\n",
            "UpperBand: ", currUpperBB, "\n",
            "LowerBand: ", currLowerBB,"\n");
  }
