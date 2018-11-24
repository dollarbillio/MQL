**MAIN CODE**
```cs
protected override void OnStart()
{
    Positions.Opened += PositionsOnOpened;
    ExecuteMarketOrder(TradeType.Buy, Symbol, 1000, "mylabel", 10, 10);
}
private void PositionsOnOpened(PositionOpenedEventArgs args)
{
    var pos = args.Position;
    Print("Position opened at {0}", pos.EntryPrice);
}
```
---
**RELATED DOCUMENTED**

**Positions.Opended**: Subscribe a method that is called each time a position opens
```cs
public event Action Opened

//---
protected override void OnStart()
 {
     Positions.Opened += PositionsOnOpened;            
 }
 private void PositionsOnOpened(PositionOpenedEventArgs args)
 {
     Print("Position opened {0}", args.Position.Label);
 }
```
**PositionOpenedEventArgs**:The arguments of the subscribed event raised when the position opens
```cs
public class PositionOpenedEventArgs : Object

Position: The position being opened

//---

protected override void OnStart()
{
    Positions.Opened += Positions_Opened;
    ExecuteMarketOrder(TradeType.Buy, Symbol, 10000, "myLabel");         
}
private void Positions_Opened(PositionOpenedEventArgs args)
{
    var position = args.Position;
    if(position.Label == "myLabel")
}
```

