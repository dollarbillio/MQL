**MAIN CODE**
```cs
 protected override void OnStart()
{
ExecuteMarketOrderAsync(TradeType.Buy, Symbol, 1000, "myLabel", 10, 10);
}
protected override void OnTick()
{
Position[] positions = Positions.FindAll("myLabel", Symbol, TradeType.Buy);
            if (positions.Length == 0)
return;

foreach (var position in positions)Print("Buy at {0} SL {1}", position.EntryPrice, position.StopLoss);

            Stop();
        }
```
