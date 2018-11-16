**Basic Function**
---
* Create a pop up window with comment
```mql5
//+------------------------------------------------------------------+
//| Expert tick function                                             |
//+------------------------------------------------------------------+
void OnTick()
  {
//---
   Comment("Hello This is me");
  }
```

**Basic Order Fill**
---
```mql5
#include <Trade\Trade.mqh>

//+------------------------------------------------------------------+
//| Expert tick function                                             |
//+------------------------------------------------------------------+
void OnTick()
  {
   
   double AccBal = AccountInfoDouble(ACCOUNT_BALANCE);
   double AccProfit = AccountInfoDouble(ACCOUNT_PROFIT);
   double AccEquity = AccountInfoDouble(ACCOUNT_EQUITY);
   
   Comment ("Account Balance: ", AccBal, "\n", "Account Profit: ", AccProfit);
   
   // +------------------------------------------------+
   // |Make a trade: MQLTradeRequest and MqlTradeResult
   // +------------------------------------------------+
   
   MqlTradeRequest myrequest; // initialize a trade request
   MqlTradeResult myresult; // shows results after a trade request is made
   ZeroMemory(myrequest); // reset myrequests
   myrequest.action = TRADE_ACTION_DEAL; // Make a market order
   myrequest.type = ORDER_TYPE_BUY; // make a buy order
   myrequest.symbol = _Symbol; // Current Chart
   myrequest.volume = 0.01; // 0.01 lot
   myrequest.type_filling = 1; // Execute order only when market is available
   myrequest.price = SymbolInfoDouble(_Symbol, SYMBOL_ASK); // Buy at ask price
   myrequest.tp = 0; // Take profit = 0
   myrequest.deviation = 50;
   
   // +------------------------------------------------+
   // |Make a trade - END -
   // +------------------------------------------------+
   
   // If there is no open order on the symbol
   if (!PositionSelect(_Symbol)) 
   // +------------------------------------------+ 
   // | bool  PositionSelect(string  symbol);
   // +------------------------------------------+
      {
         // send order
         OrderSend (myrequest, myresult);
      }
  
  // Sell rules
  if ((AccBal - AccEquity) > 2)
      
      {
         // Close all order function below
         CloseAllOrders();
      }
  }
 
 
 void CloseAllOrders()
 {
    CTrade trade; // CTrade CTrade is a class for easy access to the trade functions.

    int i = PositionsTotal() - 1; // Tell the total position
    while (i >= 0) // iterate over all trades for executing close order
      {
         if (trade.PositionClose(PositionGetSymbol(i))) i--; // Close trade one by one
         // +--------------------------------------------------------------------+
         // |Ctrade.PositionClose() Close position
         // |PositionGetSymbol(i): Get the symbol associated with position order
         // +--------------------------------------------------------------------+
      }
}
```

**BASIC SELL TRADE**

```mql5
#include<Trade\Trade.mqh>
CTrade trade;

void OnTick()
  {
      // +------------------------------------------------------------------------+
      // | - Newthings - 
      // | * NormalizeDouble(Value, Digit)
      // | * int _Digits: stores number of digits after a decimal point, 
      // |    which defines the price accuracy of the symbol of the current chart. 
      // +------------------------------------------------------------------------+

      double Bid=NormalizeDouble(SymbolInfoDouble(_Symbol, SYMBOL_BID), _Digits);
      double Balance=AccountInfoDouble(ACCOUNT_BALANCE);
      double Equity=AccountInfoDouble(ACCOUNT_EQUITY);
      
      if (Equity >= Balance)
         // +------------------------------------------------------------------------+
         // | - Newthings - 
         // | * trade.Sell == Ctrade.Sell
         // | * Sell(double        volume,          // position volume 
         // |        const string  symbol=NULL,     // symbol 
         // |         double        price=0.0,       // execution price 
         // |         double        sl=0.0,          // stop loss price 
         // |         double        tp=0.0,          // take profit price 
         // |         const string  comment=""       // comment 
         // |  
         // |* _Point: variable contains the point size of the current symbol 
         // +------------------------------------------------------------------------+
         trade.Sell(0.01,NULL,Bid,0, (Bid - 100 * _Point), NULL);
   
  }
```

