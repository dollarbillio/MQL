* 1.1 Example of a function
```mq5
double BuyStopLoss(string pSymbol, int pStopPoints, double pOpenPrice)
{
  double stopLoss = pOpenPrice - (pStopPoints * _Point);
  stoploss = NormalizeDouble(stoploss, _Digits);
  return (stopLoss);
}
```
* 1.2 Calling function
```mq5
// Input variables
input int Stoploss = 500;

// OnTick() event handler
double orderPrice = SymbolInfoDouble(_Symbol, SYMBOL_ASK);
double useStopLoss = BuyStopLoss(_Symbol, StopLoss, orderPrice);
```
