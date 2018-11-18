//+------------------------------------------------------------------+
//| int iMA(), CopyBuffer(), ArraySetAsSeries()
//+------------------------------------------------------------------+
void OnTick()
  {
   // Create an Array for several prices
   double MA_Array[];
   // Set MA_Array as times series
   ArraySetAsSeries(MA_Array, true);
   
   // define the properties of moving average
   int MA_properties = iMA(_Symbol, _Period, 20, 0, MODE_SMA, PRICE_CLOSE);
   CopyBuffer(MA_properties, 0, 0, 10, MA_Array);
   
   // MA for the current candle
   double currentMA = MA_Array[0];
   
   // Output on chart current MA
   Comment ("Current MA: ", currentMA);
  }
