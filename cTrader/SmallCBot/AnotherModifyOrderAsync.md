**MAIN CODE**
* Modify Order Asynchronously
```cs
protected override void OnStart()
{
    ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 1000, "myLabel", null, 10);
}

protected override void OnTick()
{
    Position myPosition = Positions.Find("myLabel");
    if (myPosition != null && myPosition.StopLoss == null)
    {
        double stopLoss = Symbol.Bid - 10 * Symbol.PipSize;
        ModifyPositionAsync(myPosition, stopLoss, myPosition.TakeProfit);
    }
}
```
---
**RELATED DOCUMENTED**
```cs
public TradeOperation ModifyPositionAsync(Position position, 
                                            double? stopLoss, 
                                            double? takeProfit, 
                                            bool hasTrailingStop, 
                                            StopTriggerMethod? stopLossTriggerMethod, 
                                            [optional] Action callback)
                                           
//--Parameters
position: Position to modify
stopLoss: New stop loss
takeProfit: New take profit
hasTrailingStop: Enable/disable TrailingStop for position
stopLossTriggerMethod: Trigger method for position's StopLoss
callback: Method that is called when position is modified

//--Example
var position = Positions.Find("myLabel", Symbol, TradeType.Buy);
if (position != null)
{
    double? stopLoss = Symbol.Ask- 10*Symbol.PipSize;
    double? takeProfit = Symbol.Ask + 10 * Symbol.PipSize;
    bool hasTrailingStop = true;
    ModifyPositionAsync(position, stopLoss,  takeProfit, hasTrailingStop);
}

//--Return TradeOperation
IsExecuting: True if a trade operation is being executed, false if it completed
TradeResult: The result of a trade operation
TradeOperation	
SetResult	
ToString: The description of a trade operation
```
