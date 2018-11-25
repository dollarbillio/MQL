**MAIN CODE**
* This Bot will return a piece of code 
```cs
protected override void OnStart()
{
    // PositionOpened is a function defined below, served as [Action callback] in parameter
    TradeOperation operation = ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 1000, PositionOpened);
    // Is the trade is still being executed, use TradeOperation.ToString() to describe
    if (operation.IsExecuting)
        Print(operation.ToString());
    // If Successful, Go to TradeResult and use TradeResult.ToString() to describe
    else
        Print(operation.TradeResult.ToString());
}

// Call Back Action
private void PositionOpened(TradeResult tradeResult)
{
    var position = tradeResult.Position;
    Print(tradeResult.ToString());
    if (tradeResult.IsSuccessful)
        Print("Position {0} opened at {1}", position.Id, position.EntryPrice);
}
```
---
**RELATED DOCUMENTED**
**private void PositionOpened(TradeResult tradeResult)**
* Remember this function
```cs
private void PositionOpened(TradeResult tradeResult)
{
    var position = tradeResult.Position;
    Print(tradeResult.ToString());
    if (tradeResult.IsSuccessful)
        Print("Position {0} opened at {1}", position.Id, position.EntryPrice);
}
```
