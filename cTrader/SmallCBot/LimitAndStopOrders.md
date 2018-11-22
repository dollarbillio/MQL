**MAIN CODE**
* This Bot guides Human how to create a Limit and Stop Order 
https://bpcdn.co/images/2011/03/order-types.png
```cs
protected override void OnStart()
{
    // Put your initialization logic here
    PlaceLimitOrder(TradeType.Buy, Symbol, 10000, Symbol.Bid, "myLimitOrder");
    PlaceLimitOrder(TradeType.Buy, Symbol, 20000, Symbol.Bid - 2 * Symbol.PipSize, "myLimitOrder");
    PlaceStopOrder(TradeType.Buy, Symbol, 10000, Symbol.Ask, "myStopOrder");

    foreach (var pendingOrder in PendingOrders)
    {
        Print("Order placed with label {0}, id{1}", pendingOrder.Label, pendingOrder.Id);
    }
}
```
---
**RELATED DOCUMENTED**

**PlaceLimitOrder()**
```cs
public TradeResult PlaceLimitOrder(TradeType tradeType, Symbol symbol, long volume, 
                                    double targetPrice, string label, double? stopLossPips, 
                                    double? takeProfitPips, DateTime? expiration, string comment)
//---                                    
tradeType: Direction of Trade
symbol: Symbol of Trade
volume: Volume (in units) of Trade
targetPrice: Price (or better) at which order is filled
label: Label representing the order
stopLossPips: Stop loss in pips
takeProfitPips: Take profit in pips
expiration: Order expiry time
comment: Order comment

//--Example--
double targetPrice = Symbol.Bid - 5*Symbol.PipSize;
DateTime expiry = DateTime.Now.AddMinutes(30);
PlaceLimitOrder(TradeType.Buy, Symbol, 10000, 
                targetPrice, "112", 10, 
                10, expiry, "first order");
```
**PlaceStopOrder()**
```cs
public TradeResult PlaceStopOrder(TradeType tradeType, Symbol symbol, long volume, 
                                  double targetPrice, string label, double? stopLossPips, 
                                  double? takeProfitPips, DateTime? expiration, string comment)
//---                      
tradeType: Direction of Trade
symbol: Symbol of Trade
volume: Volume (in units) of Trade
targetPrice: Price at which order becomes a market order
label: Representing label
stopLossPips: Stop loss in pips
takeProfitPips: Take profit in pips
expiration: Order expiry time
comment: Order comment

//--Example--
PlaceStopOrder(TradeType.Sell, Symbol, 20000, 
                Symbol.Ask, "myStopOrder", 20, 
                20, null, "my comment");
```
**class PendingOrder**
* A single PendingOrder in a pool of order
```cs
public interface PendingOrder

//---
Comment: User assigned Order Comment
ExpirationTime:	The order Expiration time The Timezone used is set in the Robot attribute
HasTrailingStop:	When HasTrailingStop set to true, server updates Stop Loss every time position moves in your favor.
Id: Unique order Id.
Label: User assigned identifier for the order.
OrderType: Specifies whether this order is Stop or Limit.
Quantity: Quantity (lots) of this order
StopLimitRangePips: Maximum limit from order target price, where order can be executed.
StopLoss: The order stop loss in price
StopLossPips: The order stop loss in pips
StopLossTriggerMethod: Trigger method for position's StopLoss
StopOrderTriggerMethod: Determines how pending order will be triggered in case it's a StopOrder
SymbolCode: Symbol code of the order
TakeProfit: The order take profit in price
TakeProfitPips: The order take profit in pips
TargetPrice: The order target price.
TradeType: Specifies whether this order is to buy or sell.
VolumeInUnits: Volume of this order.

//--Example--
PlaceLimitOrder(TradeType.Buy, Symbol, 10000,Symbol.Bid);
var order = LastResult.PendingOrder;
Print("The pending order's ID: {0}", order.Id); 
```
**PendingOrders - with 's'**
* Array of all pending orders
```cs
public PendingOrders PendingOrders{ get; }

foreach (var order in PendingOrders)
{
    if (order.StopLossPips == null)
        ModifyPendingOrder(order, order.TargetPrice, 10, order.TakeProfit,
                            order.ExpirationTime);
}
