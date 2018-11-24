**MAIN CODE**
* Close the position Async when order reach a profit
```cs
protected override void OnStart()
{
    ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 1000, "myLabel", null, 10);
}
protected override void OnTick()
{
    Position myPosition = Positions.Find("myLabel");
    if (myPosition != null && myPosition.GrossProfit > 10)
    {
        ClosePositionAsync(myPosition);
        Stop();
    }
}
```
---
**RELATED DOCUMENTED**
* **ClosePositionAsync**
```cs
public TradeOperation ClosePositionAsync(Position position, 
                                        long volume, 
                                        [optional] Action callback)

//--Return TradeOperation
public class TradeOperation : Object

IsExecuting: True if a trade operation is being executed, false if it completed
TradeResult: The result of a trade operation
TradeOperation	
SetResult	
ToString: The description of a trade operation
```

