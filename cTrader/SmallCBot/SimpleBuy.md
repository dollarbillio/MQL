**CODE SAMPLE**
* Create a simple buy order at Robot start
```cs
//...
protected override void OnStart()
{
    // Put your initialization logic here
    // Create A simple Buy Order
    var/TradeResult result = ExecuteMarketOrder(TradeType.Buy, Symbol, 10000);
        
    // If the trade is executed successfully, print the entry Price
    if (result.IsSuccessful) 
    {
        var position = result.Position;
        Print("Position entry price is {0}", position.EntryPrice);
    } else 
    {
        Print("There is something wrong");
    }
}
//...
```
---
**RELATED DOCUMENTED**
* ExecuteMarketOrder()
```cs
public TradeResult ExecuteMarketOrder(TradeType tradeType,      // Direction of Trade: TradeType.buy/sell
                                      Symbol symbol,            // Symbol to execute order on
                                      long volume,              // 10000 -> 10k position on EURUSD
                                      string label,             // Label 
                                      double? stopLossPips,     // Stop Loss
                                      double? takeProfitPips,   // Take Profit
                                      double? marketRangePips,  // slippage(max)
                                      string comment)           // Order Comment
//---
Returns [Class] TradeResult 
```
* TradeResult
```cs
public class TradeResult : Object

//--Methods on TradeResult
Error	        :Error code of un unsuccessful trade
IsSuccessful	:True if the trade is successful, false if there is an error
PendingOrder	:The resulting pending order of a trade request
Position        :The resulting position of a trade request
TradeResult	
ToString        :The description of a trade result

//--Examples
TradeResult result = ExecuteMarketOrder(TradeType.Sell, Symbol, 20000);
if (result.IsSuccessful)
    Print("Sell at {0}", result.Position.EntryPrice);
```
* TradeResult.Position
```cs
public interface Position

//--Attributes on Trade.Position
Comment	        :Comment can be used as a note for the order
Commissions     :Commission Amount of the request to trade one way(Buy/Sell) associated with this position.
EntryPrice      :Entry price of the position.
EntryTime       :Entry time of trade associated with a position. The Timezone used is set in the Robot attribute
GrossProfit     :Gross profit accrued by the order associated with a position.
HasTrailingStop :When HasTrailingStop set to true,server updates Stop Loss every time position moves in your favor.
Id              :The position's unique identifier.
Label	        :Label can be used to represent the order.
NetProfit       :The Net profit of the position.
Pips	        :Represents the winning or loosing pips of the position.
Quantity        :Quantity (lots) traded by the position
StopLoss        :The stop loss level (price) of the position.
StopLossTriggerMethod   :Trigger method for position's StopLoss
Swap	                :Swap is the overnight interest rate if any, accrued on the position.
SymbolCode              :Symbol code of the position.
TakeProfit              :The take profit level of the position.
TradeType               :Trade type (Buy/Sell) of the position.
VolumeInUnits	        :The amount traded by the position.

//--Examples
protected override void OnStart()
{
    foreach (var position in Positions)
    {
        Print("Position Label {0}", position.Label);
        Print("Position ID {0}", position.Id);
        Print("Profit {0}", position.GrossProfit);
        Print("Entry Price {0}", position.EntryPrice);
    }
}
```
