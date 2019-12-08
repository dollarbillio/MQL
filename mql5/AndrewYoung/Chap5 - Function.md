* Example of a function
```mq5
double BuyStopLoss(string pSymbol, int pStopPoints, double pOpenPrice)
{
  double stopLoss = pOpenPrice - (pStopPoints * _Point);
  stoploss = NormalizeDouble(stoploss, _Digits);
  return (stopLoss);
}
```
