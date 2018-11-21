**MAIN CODE**
```cs
protected override void OnStart()
    {
        ExecuteMarketOrder(TradeType.Buy, Symbol, 1000, "Bot_1");
    }
protected override void OnTick()
    {
        // Find the order with label "Bot_1"
        var position = Positions.Find("Bot_1");
        
        // if position is a valid position and gross profit > 10
        if (position != null && position.GrossProfit > 10)
        {
            ClosePosition(position);
            Stop();
        }
    }
```
---
**RELATED DOCUMENTED**

**Positions**: Provides access to methods of the positions collection
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
Modified	
Opened:	Subscribe a method that is called each time a position opens
```
**Positions.Find()**
```cs
public Position Find(string label, Symbol symbol, TradeType tradeType)

label	Label to search by
symbol	Symbol to search by
tradeType	Trade type to search by
```
**ClosePosition(position)**
```cs
public TradeResult ClosePosition(Position position, long volume)

position:   Position to close
volume:     Volume which is closed

//--Ex--
if (position.Volume >= 20000)
    ClosePosition(position, 10000);
```


