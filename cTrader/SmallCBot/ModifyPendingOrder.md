**MAIN CODE**
```cs
protected override void OnStart()
{
    // take 10 pips above ask price (to buy)
    var price = Symbol.Ask + 10 * Symbol.PipSize;
    DateTime? expiry = Server.Time.AddHours(12);
    PlaceStopOrder(TradeType.Buy, Symbol, 10000, price, "myLabel", 10, 10, expiry);
}

protected override void OnTick()
{
    foreach (var order in PendingOrders)
    {
        if (order.Label == "myLabel")
        {
            // Take 5 pips above from the Ask Price
            double newPrice = Symbol.Ask + 5 * Symbol.PipSize;
            ModifyPendingOrder(order, newPrice, order.StopLossPips, order.TakeProfitPips, order.ExpirationTime);
        }
    }
}
```
**RELATED DOCUMENTED**

**DateTime**
```cs
DateTime? expiry = Server.Time.AddHours(12);
```
