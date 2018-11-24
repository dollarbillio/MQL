**MAIN CODE**
* Print some kind of messages when a position is closed
```cs
protected override void OnStart()
{
    Positions.Closed += PositionsOnClosed;
    ExecuteMarketOrder(TradeType.Buy, Symbol, 1000, "mylabel", 10, 10);
}
protected override void OnBar()
{
    var position = Positions.Find("mylabel");
    if (position != null)
    {
        ClosePosition(position);
    }
}
private void PositionsOnClosed(PositionClosedEventArgs args)
{
    var pos = args.Position;
    Print("Position closed at {0} profit", pos.GrossProfit);
}
```
---
**RELATED DOCUMENTED**

**PositionClosedEventArgs**
```cs
public class PositionClosedEventArgs : Object

//---
Position: The position being closed
Reason: Reason for position closing

//--Example
protected override void OnStart()
{
    Positions.Closed += PositionsClosed;
}
private void PositionsOnClosed(PositionClosedEventArgs args)
{
    var position = args.Position;
    Print("Position closed with {0} profit", position.GrossProfit);
}
```
