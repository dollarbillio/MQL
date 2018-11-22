**MAIN CODE**
* This Bot will modify total order value by going over each ```Position``` in ```Position[]```
    each time a candle is finished and reduce the order value by a specified amount
```cs
protected override void OnStart()
{
    // Put your initialization logic here
    ExecuteMarketOrder(TradeType.Buy, Symbol, 2000, "mylabel");
    ExecuteMarketOrder(TradeType.Buy, Symbol, 1000, "mylabel");
}

// Run on every candle bar
protected override void OnBar()
{
    // Find All positions with the name "mylabel"
    // Return a Positions[] list
    var positions = Positions.FindAll("mylabel", Symbol, TradeType.Buy);

    foreach (var position in positions)
    {
        if (position.VolumeInUnits > 1000)
        {
            ClosePosition(position, 1000);
        }
    }
}
```
---
**RELATED DOCUMENTED**

**Class Position**
```cs
// Class
public interface Position

//--Attributes on Trade.Position
Comment	        :Comment can be used as a note for the order
Commissions     :Commission Amount of the request to trade one way(Buy/Sell) associated with this position.
EntryPrice      :Entry price of the position.
EntryTime       :Entry time of trade associated with a position. The Timezone used is set in the Robot attribute
GrossProfit     :Gross profit accrued by the order associated with a position.
HasTrailingStop :When HasTrailingStop set to true,server updates Stop Loss every time position moves in your favor.
Id              :The position's unique identifier.
Label	        :Label can be used to represent the order.
NetProfit       :The Net profit of the position.
Pips	        :Represents the winning or loosing pips of the position.
Quantity        :Quantity (lots) traded by the position
StopLoss        :The stop loss level (price) of the position.
StopLossTriggerMethod   :Trigger method for position's StopLoss
Swap	                :Swap is the overnight interest rate if any, accrued on the position.
SymbolCode              :Symbol code of the position.
TakeProfit              :The take profit level of the position.
TradeType               :Trade type (Buy/Sell) of the position.
VolumeInUnits	        :The amount traded by the position.

//--Examples
protected override void OnStart()
{
    foreach (var position in Positions)
    {
        Print("Position Label {0}", position.Label);
        Print("Position ID {0}", position.Id);
        Print("Profit {0}", position.GrossProfit);
        Print("Entry Price {0}", position.EntryPrice);
    }
}
```
**Position[]** list
```cs
public interface Positions : IEnumerable

Count:  Total number of open positions
this[int index]: Find a position by index
Find:   Find a position by its label
Find:   Find a position by its label and symbol
Find:   Find a position by its label, symbol and trade type
FindAll:Find all positions with this label
FindAll:Find all positions with this label and symbol
FindAll:Find all positions of this label, symbol and trade type
Closed: Subscribe a method that is called each time a position closes
Modified:	
Opened:Subscribe a method that is called each time a position opens
```
**ClosePosition()**
```cs
public TradeResult ClosePosition(Position position, long volume)

position: Position to close
volume: Volume which is closed,in value, not in pip

if (position.Volume >= 20000)
    ClosePosition(position, 10000);
```
