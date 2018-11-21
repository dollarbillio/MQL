**MAIN CODE**
```cs
protected override void OnStart()
{
    // Put your initialization logic here
    // Create A simple Buy Order With StopLoss=null, takeprofit=10
    TradeResult result = ExecuteMarketOrder(TradeType.Buy, Symbol, 10000, "order1", null, 10);

    if (result.IsSuccessful)
    {
        var position = result.Position;
        Print("Position SL price is {0}", position.StopLoss);
                
        var StopLoss = position.EntryPrice - 10 * Symbol.PipSize;
        ModifyPosition(position, StopLoss, position.TakeProfit);

        // Print the new stoploss
        Print("The Position new SL is {0}", position.StopLoss);
    } 
    else
    {
        Print("There is something wrong");
    }
}
```
---
**RELATED DOCUMENTED**

**Class Symbol** - current symbol and symbol attributes
```cs
public interface Symbol

//---
Ask:                The current ask price for this symbol.
Bid:                The current bid price of this symbol.
Code:               Represents the currency pair code, e.g. "EURUSD"
Digits:             Number of digits for this symbol
DynamicLeverage:    Dynamic leverage tiers for symbol.
LotSize:            Size of 1 lot in units of base currency
MarketHours:        Access to symbol's trading sessions schedule
PipSize:	        Pip size for current symbol
PipValue:	        The monetary value of one pip
Spread:             The current spread of this symbol.
TickSize:	        Tick size for current symbol
TickValue:	        The monetary value of one tick
UnrealizedGrossProfit:  Sum of unrealized Gross profits of positions of this Symbol
UnrealizedNetProfit:    Sum of unrealized Net profits of positions of this Symbol
VolumeInUnitsMax:   The maximum tradable amount
VolumeInUnitsMin:   The minimum tradable amount
VolumeInUnitsStep:  The minimum trade amount increament
NormalizeVolumeInUnits:     Round the volume to an amount suitable for a trade
QuantityToVolumeInUnits:    Convert Quantity (in lots) to Volume in units of base currency
VolumeInUnitsToQuantity:    Convert Volume in units of base currency to Quantity (in lots)
```
**ModifyPosition()**
```cs
public TradeResult ModifyPosition(Position position,                    // Position which is affected 
                           double? stopLoss,                            // new StopLoss
                           double? takeProfit,                          // new TakeProfit
                           bool hasTrailingStop,                        // Enable/disable TrailingStop for position
                           StopTriggerMethod? stopLossTriggerMethod)    // Trigger methods for position SlopLoss

//--Example
var position = Positions.Find("myLabel", Symbol, TradeType.Buy);
if (position != null )
{
    double? stopLoss = Symbol.Ask- 10*Symbol.PipSize;
    double? takeProfit = Symbol.Ask + 10 * Symbol.PipSize;
    bool hasTrailingStop = true;
    ModifyPosition(position, stopLoss,  takeProfit, hasTrailingStop, StopTriggerMethod.Opposite);
    Print("Position was modified, stop loss trigger method = {0}", result.Position.StopLossTriggerMethod);
}
```
**StopTriggerMethod**
```cs
public sealed enum StopTriggerMethod
//---
DoubleOpposite
DoubleTrade
Opposite
Trade
```
