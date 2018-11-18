void OnTick()
{
   //--- Create Total number of orders
   int ThisCurrTotalOrders = 0;
   
   for (int i=PositionsTotal()-1; i>=0;i--) 
   {
      string symbol = PositionGetSymbol(i);
      
      if (Symbol()==symbol)
      {
         ThisCurrTotalOrders +=1;
      }
   } 
   
   Comment("\n\n Positions For this currency pair: ",
            ThisCurrTotalOrders, "\n\n", "Total number of bar: ", Bars(_Symbol, Period()));
}
