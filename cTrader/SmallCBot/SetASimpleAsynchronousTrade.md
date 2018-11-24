**MAIN CODE**
* Asynchronuous trade is trade sent to the server and not waiting for the response before sending new orders
```cs
protected override void OnStart()
{
    TradeOperation operation = ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 1000);
    if (operation.IsExecuting)
    {
        Print("Operation is Executing");
    }
}
```
**RELATED DOCUMENTED**

**TradeOperation**
```cs
public class TradeOperation : Object

//---
IsExecuting: True if a trade operation is being executed, false if it completed
TradeResult: The result of a trade operation
    Error: Error code of un unsuccessful trade
    IsSuccessful: True if the trade is successful, false if there is an error
    PendingOrder: The resulting pending order of a trade request
    Position: The resulting position of a trade request
    TradeResult	
    ToString: The description of a trade result	
ToString	The description of a trade operation

//--Example--
protected override void OnStart()
{
    Positions.Opened += PositionsOnOpened;
    TradeOperation operation = ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 10000, "asynchronous");
    ExecuteMarketOrder(TradeType.Buy, Symbol, 10000, "synchronous", 10, 10);
    
    // This logic only works with AsyncOrder
    if (operation.IsExecuting)
    {
        Print("Trade is executing");
    }
    else
    {
        if (operation.TradeResult.IsSuccessful)
            Print("Trade executed");
    } 
}
private void PositionsOnOpened(PositionOpenedEventArgs args)
{
    var pos = args.Position;
    Print("Position {0} opened at {1}", pos.Label, pos.EntryPrice);
}
```
