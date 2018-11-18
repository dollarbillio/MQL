Create A Price Array to manipulate(e.g sorting) candle based on each candle attribute
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

Sort A Series of Candles Reversing (From Right to Left, Descending)?
```mq5
bool  ArraySetAsSeries( 
   const void&  array[],    // array by reference 
   bool         flag        // true denotes reverse order of indexing 
   );

1| ArraySetAsSeries(PriceInformation, true);
```
