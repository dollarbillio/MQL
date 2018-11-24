**MAIN CODE**
```cs
protected override void OnStart()
{
    // Create a midnight time
    DateTime midnight = Server.Time.AddDays(1).Date;

    // Place Limit and Stop order
    PlaceLimitOrder(TradeType.Buy, Symbol, 1000, Symbol.Bid, "sample_bot", 10, null, midnight, "First");
    PlaceStopOrder(TradeType.Buy, Symbol, 1000, Symbol.Ask, "sample_bot", 10, 10, null, "Second");

    foreach (var order in PendingOrders)
    {
        var sl = order.StopLossPips == null ? "" : "SL " + order.StopLossPips;
        var tp = order.TakeProfitPips == null ? "" : "TP " + order.StopLossPips;

        var text = string.Format("{0} {1}", sl, tp);

        if (order.OrderType == PendingOrderType.Limit)
            Print(order.OrderType + " Limit Order " + text);
        else
            Print(order.OrderType + " Stop Order " + text);
    }
}
```
---
**RELATED DOCUMENTED**

**DateTime**
```cs
// Convert time of 1 day later into Midnight of next day (00:00:00)
DateTime midnight = Server.Time.AddDays(1).Date;
```
**? Operator**
```cs 
// if condition then consequence else alternative
var variable = condition ? consequence : alternative;
```
**PendingOrderType**
```cs
public sealed enum PendingOrderType

//---
Limit:   limit order is an order to buy or sell at a specific price or better.
Stop:    stop order is an order to buy or sell once the price of the symbol reaches a specified price.
StopLimit: top limit order is an order to buy or sell once the price of the symbol reaches specific price.
Order has a parameter for maximum distance from that target price, where it can be executed.

//Example
if(PendingOrders.Count > 0)
{
    PendingOrderType type = PendingOrders[0].OrderType;
}
```
