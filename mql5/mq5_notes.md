**```ArrayResize```**: Change size of dynamic array
```mq5
double myDynamic[];
ArrayResize(myDynamic,3);
myDynamic[0] = 1.50;
```
**```PositionGetInteger```**:
- When used with POSITION_TYPE -> return the current open position as POSITION_TYPE_BUY or POSITION_TYPE_SELL
```mq5
long  PositionGetInteger(
   ENUM_POSITION_PROPERTY  property_id      // Property identifier
   );
```

**```PositionSelect```**: Return true for false if any position exists for the symbol
```mq5
bool  PositionSelect(
   string  symbol      // Symbol name 
 );
 ```

**```ArraySetAsSeries```**: The function sets the AS_SERIES flag to a selected object of a dynamic array, and elements will be indexed like in timeseries. The function returns true on success, otherwise  - false.
```mq5
bool  ArraySetAsSeries( 
   const void&  array[],    // array by reference 
   bool         flag        // true denotes reverse order of indexing 
   );
```

**```struct MqlTradeResult```**: The Price (Open, Close, High, Low), the Time, the Volumes of each bar and the spread for a symbol is stored in this structure.  Any array declared to be of the MqlRates type can be used to store the price, volumes and spread history for a symbol.
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
```

**```struct MqlTradeResult```**: Any variable declared to be of MqlTradeResult type will be able to access the trade request results.
```mq5
struct MqlTradeResult
  {
   uint     retcode;          // Operation return code
   ulong    deal;             // Deal ticket, if it is performed
   ulong    order;            // Order ticket, if it is placed
   double   volume;           // Deal volume, confirmed by broker
   double   price;            // Deal price, confirmed by broker
   double   bid;              // Current Bid price
   double   ask;              // Current Ask price
   string   comment;          // Broker comment to operation (by default it is filled by the operation description)
  };
```

**```struct MqlTradeRequest```**: Any variable declared to be of the MqlTradeRequest type can be used to send orders for our trade operations
```mq5
struct MqlTradeRequest
  {
   ENUM_TRADE_REQUEST_ACTIONS    action;       // Trade operation type
   ulong                         magic;        // Expert Advisor ID (magic number)
   ulong                         order;        // Order ticket
   string                        symbol;       // Trade symbol
   double                        volume;       // Requested volume for a deal in lots
   double                        price;        // Price
   double                        stoplimit;    // StopLimit level of the order
   double                        sl;           // Stop Loss level of the order
   double                        tp;           // Take Profit level of the order
   ulong                         deviation;    // Maximal possible deviation from the requested price
   ENUM_ORDER_TYPE               type;          // Order type
   ENUM_ORDER_TYPE_FILLING       type_filling;  // Order execution type
   ENUM_ORDER_TYPE_TIME          type_time;     // Order execution time
   datetime                      expiration;    // Order expiration time (for the orders of ORDER_TIME_SPECIFIED type)
   string                        comment;       // Order comment
  };
```
**```struct MqlTick```**: 
- This is a structure used for storing the latest prices of symbols
- Any variable declared to be of the MqlTick type can easily be used to obtain the current values of Ask, Bid, Last and Volume once you call the SymbolInfoTick() function.
```mq5
struct MqlTick
  {
   datetime     time;          // Time of the last prices update
   double       bid;           // Current Bid price
   double       ask;           // Current Ask price
   double       last;          // Price of the last deal (Last)
   ulong        volume;        // Volume for the current Last price
  };
```

**```int iRSI()```**: Relative Strength Index. Use ```CopyBuffer()```
```mq5
int  iRSI( 
   string              symbol,            // symbol name 
   ENUM_TIMEFRAMES     period,            // period 
   int                 ma_period,         // averaging period 
   ENUM_APPLIED_PRICE  applied_price      // type of price or handle 
   );
```

**```static type variable```**: this variable value will be the same through out the function's life and will be updated at next tick
```mq5
static int candleCounter;
static int candleCounter;
```
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

**```bool ArraySetAsSeries()```**: Sort A Series of Candles Reversing (From Right to Left, Descending)?
```mq5
bool  ArraySetAsSeries( 
   const void&  array[],    // array by reference 
   bool         flag        // true denotes reverse order of indexing 
   );

1| ArraySetAsSeries(PriceInformation, true);
```

**```int CopyHigh()```**: Copy High value of candle into a target array
```mq5
int  CopyHigh( 
   string           symbol_name,      // symbol name 
   ENUM_TIMEFRAMES  timeframe,        // period 
   int              start_pos,        // start position 
   int              count,            // data count to copy 
   double           high_array[]      // target array to copy 
   );
```

**```int CopyRates()```**: Returns the number of copied elements or -1 in case of  an error.
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



**```int CopyBuffer()```**: **Handling Indicator Stream**
```mq5
int  CopyBuffer( 
   int       indicator_handle,     // indicator handle 
   int       buffer_num,           // indicator buffer number 
   int       start_pos,            // start position 
   int       count,                // amount to be in the buffer 
   double    buffer[]              // target array to copy 
   );

int  CopyBuffer( 
   int       indicator_handle,     // indicator handle 
   int       buffer_num,           // indicator buffer number 
   datetime  start_time,           // start date and time 
   int       count,                // amount to copy 
   double    buffer[]              // target array to copy 
   );
   
int  CopyBuffer( 
   int       indicator_handle,     // indicator handle 
   int       buffer_num,           // indicator buffer number 
   datetime  start_time,           // start date and time 
   datetime  stop_time,            // end date and time 
   double    buffer[]              // target array to copy 
   );
```

**```int Bars()```**: Returns number of bars as requested 
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

* **```ENUM_TIMEFRAMES  Period()```**: the value of the current chart timeframe
* **```int PositionsTotal()```**: number of open positions 
* **```string PositionGetSymbol(i) | i is index in PositionsTotal()```**: Return the corresponding symbol of the currently selected positions
* **```string Symbol() or _Symbol```**: Return the symbol of the current chart, not open position

**```double SymbolInfoDouble()```**: Return the ```double``` type value of current symbol
```mq5
double  SymbolInfoDouble( 
   string                   name,       // current symbol 
   ENUM_SYMBOL_INFO_DOUBLE  prop_id     // identifier of the property 
   );

* SYMBOL_BID, SYMBOL_ASK
* SYMBOL_SWAP_LONG, SYMBOL_SWAP_SHORT
```
**```int  ArrayMaximum()```**: Return the index of the candle with maximum high in the target array
```mq5 
int  ArrayMaximum( 
   const void&   array[],             // array for search 
   int           start=0,             // index to start checking with 
   int           count=WHOLE_ARRAY    // number of checked elements 
   );
```

**```int iBands()```**: **Bollinger Band**
```mq5
int  iBands( 
   string              symbol,            // symbol name 
   ENUM_TIMEFRAMES     period,            // period 
   int                 bands_period,      // period for average line calculation 
   int                 bands_shift,       // horizontal shift of the indicator 
   double              deviation,         // number of standard deviations 
   ENUM_APPLIED_PRICE  applied_price      // type of price or handle 
   );

1|int BB_properties = iBands(_Symbol, _Period, 20, 0, 2, PRICE_CLOSE);
2|CopyBuffer(BB_properties, 0, 0, 10, MiddleBolinger);
3|CopyBuffer(BB_properties, 1, 0, 10, UpperBollinger);
4|CopyBuffer(BB_properties, 2, 0, 10, LowerBollinger);
   
5|// MA for the current candle
6|double currMidBB = MiddleBolinger[0];
7|double currUpperBB = UpperBollinger[0];
8|double currLowerBB = LowerBollinger[0];
```
