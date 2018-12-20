* Create ```struct CustomMqlTick``` to describe how struct works
---
```mq5
//+------------------------------------------------------------------+
//| Script program start function |
//+------------------------------------------------------------------+
void OnStart()
{

   //--- develop the structure similar to the built-in MqlTick
   // Last price update time
   // Current Bid price
   // Current Ask price
   // Current price of the last trade (Last) // Volume for the current Last price
   // Last price update time in milliseconds // Tick flags
   struct CustomMqlTick 
   {
      datetime time;
      double bid;
      double ask;
      double last;
      ulong volume;
      long time_msc;
      uint flags;
   };
   //--- get the last tick value
   MqlTick last_tick;
   
   // Create a struct instance
   CustomMqlTick my_tick1,my_tick2;
   //--- attempt to copy data from MqlTick to CustomMqlTick
   if(SymbolInfoTick(Symbol(),last_tick)) 
   {
      // Update one by one
      my_tick1.time=last_tick.time; 
      my_tick1.bid=last_tick.bid; 
      my_tick1.ask=last_tick.ask; 
      my_tick1.volume=last_tick.volume; 
      my_tick1.time_msc=last_tick.time_msc; 
      my_tick1.flags=last_tick.flags;
      //--- it is allowed to copy the objects of the same type of CustomMqlTick the f
      my_tick2=my_tick1;
      //--- create an array out of the objects of the simple CustomMqlTick structure
      CustomMqlTick arr[2]; 
      arr[0]=my_tick1; 
      arr[1]=my_tick2; 
      ArrayPrint(arr);
   } else {
      Print("There is nothing here");
   }
}
//+------------------------------------------------------------------+
```
