**```struct MqlRates```**: Create A Price Array to manipulate(e.g sorting) candle based on each candle attribute
```mq5
struct MqlRates 
  { 
   datetime time;         // Period start time 
   double   open;         // Open price 
   double   high;         // The highest price of the period 
   double   low;          // The lowest price of the period 
   double   close;        // Close price 
   long     tick_volume;  // Tick volume 
   int      spread;       // Spread 
   long     real_volume;  // Trade volume 
  };
  
1| MqlRate PriceInformation[]; 
```

**```bool ArraySetAsSeries```**: Sort A Series of Candles Reversing (From Right to Left, Descending)?
```mq5
bool  ArraySetAsSeries( 
   const void&  array[],    // array by reference 
   bool         flag        // true denotes reverse order of indexing 
   );

1| ArraySetAsSeries(PriceInformation, true);
```

**```int CopyRates```**: Returns the number of copied elements or -1 in case of  an error.
```mq5
int  CopyRates( 
   string           symbol_name,       // symbol name 
   ENUM_TIMEFRAMES  timeframe,         // period 
   int              start_pos,         // start position 
   int              count,             // data count to copy 
   MqlRates         rates_array[]      // target array to copy 
   );

int  CopyRates( 
   string           symbol_name,       // symbol name 
   ENUM_TIMEFRAMES  timeframe,         // period 
   datetime         start_time,        // start date and time 
   int              count,             // data count to copy 
   MqlRates         rates_array[]      // target array to copy 
   );

int  CopyRates( 
   string           symbol_name,       // symbol name 
   ENUM_TIMEFRAMES  timeframe,         // period 
   datetime         start_time,        // start date and time 
   datetime         stop_time,         // end date and time 
   MqlRates         rates_array[]      // target array to copy 
   );

1| CopyRates(Symbol(), Period(), 0, Bars(Symbol(), Period()), PriceInformation);
```

**```int Bars```**: Returns number of bars as requested 
```mq5
int  Bars( 
   string           symbol_name,     // symbol name 
   ENUM_TIMEFRAMES  timeframe        // period 
   );
=> all bars as not specifying start_time and end_time

int  Bars( 
   string           symbol_name,     // symbol name 
   ENUM_TIMEFRAMES  timeframe,       // period 
   datetime         start_time,      // start date and time 
   datetime         stop_time        // end date and time 
   );

1| int bars = Bars(_Symbol(), Period())
```

**```ENUM_TIMEFRAMES  Period()```**: the value of the current chart timeframe
**```int PositionsTotal()```**: number of open positions 
**```string PositionGetSymbol(i) | i is index in PositionsTotal()```**: Return the corresponding symbol of the currently selected positions
**```string Symbol() or _Symbol```**: Return the symbol of the current chart, not open position


