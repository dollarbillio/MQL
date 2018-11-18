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
