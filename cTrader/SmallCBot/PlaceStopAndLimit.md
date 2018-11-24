**MAIN CODE**
* Create AsyncOrder
```cs
 protected override void OnStart()
{
    DateTime expiry = Server.Time.AddHours(12);
    PlaceLimitOrderAsync(TradeType.Buy, Symbol, 1000, Symbol.Bid, "myLabel", null, null, expiry);
    PlaceStopOrderAsync(TradeType.Buy, Symbol, 1000, Symbol.Ask + 10 * Symbol.PipSize, "myLabel", null, null, expiry);
}
```
**RELATED DOCUMENTED**
```cs
public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, Symbol symbol, l
    ong volume, double targetPrice, string label, 
    double? stopLossPips, double? takeProfitPips, 
    DateTime? expiration, string comment, [optional] Action callback)


tradeType	Direction of trade
symbol	Symbol of trade
volume	Volume of trade
targetPrice	Target price (or better) at which the order is filled
label	Label that represents the order
stopLossPips	Stop loss in pips from target price
takeProfitPips	Take profit in pips from target price
expiration	Order expiry date and time
comment	Order comment
callback	The action when the position closes

//--Example
DateTime? expiry = DateTime.Now.AddHours(1);
PlaceLimitOrderAsync(TradeType.Buy, Symbol, 10000, 
             Symbol.Bid - 10* Symbol.PipSize,"myLabel", 
             10, 10, expiry, "order comment");
             
//--Example
protected override void OnStart()
{
    PlaceLimitOrderAsync(TradeType.Buy, Symbol, 10000, Symbol.Bid, LimitOrderOnPlaced);
}
private void LimitOrderOnPlaced(TradeResult tradeResult)
{
    Print("Limit order placed {0}", tradeResult.PendingOrder.Label);
}
```
