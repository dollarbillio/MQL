```Indicator.Symbol```, ```Robot.Symbol```
---
```cs
public Symbol Symbol{ get; }
```
* Represents the current symbol, provides access to its properties and certain methods
```cs
var ask = Symbol.Ask;
var bid = Symbol.Bid;
var digits = Symbol.Digits;
var pip = Symbol.PipSize;
var maxVolume = Symbol.VolumeMax;
var minVolume = Symbol.VolumeMin;

ExecuteMarketOrder(TradeType.Buy, Symbol, 10000, "myLabel", 10, 10);  

volume = Symbol.NormalizeVolume(volume, RoundingMode.Down);
```
---
```cs
public interface Symbol
```
---
**MEMBERS**
```cs
public double Ask{ get; }
```
* The current seller's price for this symbol. Price to create a Buy Order
```cs
protected override void OnTick()
{
    Print("Ask Price: {0}", Symbol.Ask);
}
```
---
```cs
public double Bid{ get; }
```
* The buyer's price for the symbol. Price to create a Sell Order
```cs
protected override void OnTick()
{
    Print("Bid Price: {0}", Symbol.Bid);
}
```
---
```cs
public string Code{ get; }
```
* Represents the currency pair code, e.g. "EURUSD"
```cs
protected override void OnTick()
{
    Print("This strategy is trading the symbol: {0}", Symbol.Code);
}
```
---
```cs
public int Digits{ get; }
```
* Number of digits for this symbol
```cs
protected override void OnTick()
{
    Print("The number of Digits the current symbol  has is: {0}", Symbol.Digits);
}
```
---
```cs
public IReadonlyList DynamicLeverage{ get; }
```
* Dynamic leverage tiers for symbol.
```cs
var symbolLeverage = Symbol.DynamicLeverage[0]; 
var realLeverage = Math.Min(symbolLeverage, Account.Leverage);
```
```cs
public interface IReadonlyList : IEnumerable
```
* ```Count```: The total number of elements contained in the collection
* ```this[int index]```: Represents the item contained in the collection at a specific index
---
```cs
public long LotSize{ get; }
```
* Size of 1 lot in units of base currency
---
```cs
public MarketHours MarketHours{ get; }

public interface MarketHours
```
* Access to symbol's trading sessions schedule
**Members** of ```public interface MarketHours```
```cs
public IReadonlyList Sessions{ get; }	
```
* List of all symbol's trading sessions
```cs
public bool IsOpened(DateTime datetime)
```
* Indicates if trading session is active
```cs
public TimeSpan TimeTillClose()
```
* Time left till end of current trading session. Returns 0 if session is not active
```cs
public TimeSpan TimeTillOpen()
```
* Time left till start of new trading session. Returns 0 if session is already active
---
```cs
public double PipSize{ get; }

//---
protected override void OnTick()
{
    Print("The current symbol has pip size of: {0}", Symbol.PipSize);
}
```
* Pip size for current symbol
---
```cs
public double PipValue{ get; }

//---
var volume = ((Account.Balance*Risk)/StopLoss)/Symbol.PipValue;
```
* The monetary value of one pip
---
```cs
public double Spread{ get; }

//---
protected override void OnTick()
{
    Print("The Spread of the symbol is: {0}", Symbol.Spread);
}
```
* The difference between Ask and Bid for the symbol.
(see Ask and Bid)
---
```cs
public double TickSize{ get; }

//---
protected override void OnTick()
{
    Print("The current symbol has TickSize: {0}", Symbol.TickSize);
}
```
* Tick size for current symbol. If the symbol is a 5 digit symbol, the tick size is 0.00001
---
```cs
public double TickValue{ get; }

//---
var volume = ((Account.Balance*Risk)/StopLoss)/Symbol.TickValue;
```
* The monetary value of one tick
---
```cs
public double UnrealizedGrossProfit{ get; }
```
* Sum of unrealized Gross profits of positions of this Symbol
---
```cs
public double UnrealizedGrossProfit{ get; }
```
* Sum of unrealized Net profits of positions of this Symbol
---
```cs
public double VolumeInUnitsMax{ get; }

if(Symbol.NormalizeVolumeInUnits(volume, RoundingMode.Down) <= Symbol.VolumeInUnitsMax)
{
    volume = Symbol.NormalizeVolumeInUnits(volume, RoundingMode.Down);
    ExecuteMarketOrder(TradeType.Buy, Symbol, volume);
}
```
* The maximum tradable amount
---
```cs
public double VolumeInUnitsMin{ get; }

//---
if(volume < Symbol.VolumeInUnitsMin)
{
    Print("The minimum volume is {0}", Symbol.VolumeInUnitsMin);
}
```
* The minimum tradable amount
---
```cs
public double VolumeInUnitsStep{ get; }

if(volume + Symbol.VolumeInUnitsStep <= Symbol.VolumeInUnitsMax)
{
    volume += Symbol.VolumeInUnitsStep;
}
```
* The minimum trade amount increment
---
```cs
public double NormalizeVolumeInUnits(double volume, [optional] RoundingMode roundingMode)

volume	Amount to normalize
roundingMode	Rounding method

//--
volume = Symbol.NormalizeVolumeInUnits(volume, RoundingMode.Down);
```
* Round the volume to an amount suitable for a trade
```cs
public sealed enum RoundingMode

// RoundingMode.Down
volume = Symbol.NormalizeVolume(volume, RoundingMode.Down);

// RoundingMode.ToNearest
var volume = Symbol.NormalizeVolume(calculatedVolume, RoundingMode.ToNearest);

//RoundingMode.Up
var volume = Symbol.NormalizeVolume(calculatedVolume, RoundingMode.Up);
```
* Rounding mode for normalizing trade volume
---
```cs
public double QuantityToVolumeInUnits(double quantity)
```
* QuantityToVolumeInUnits	Convert Quantity (in lots) to Volume in units of base currency
---
```cs
public double VolumeInUnitsToQuantity(double volume)
```
* Convert Volume in units of base currency to Quantity (in lots)
