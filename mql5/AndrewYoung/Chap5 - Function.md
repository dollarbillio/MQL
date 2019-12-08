* 5.1 Example of a function
```mq5
double BuyStopLoss(string pSymbol, int pStopPoints, double pOpenPrice)
{
  double stopLoss = pOpenPrice - (pStopPoints * _Point);
  stoploss = NormalizeDouble(stoploss, _Digits);
  return (stopLoss);
}
```
* 5.2 Calling function
```mq5
// Input variables
input int Stoploss = 500;

// OnTick() event handler
double orderPrice = SymbolInfoDouble(_Symbol, SYMBOL_ASK);
double useStopLoss = BuyStopLoss(_Symbol, StopLoss, orderPrice);
```
---
* 5.3 Passing by reference
```mq5
void FillArray(int &array[])
{
  ArrayResize(array, 3);
  array[0] = 1;
  array[1] = 2;
  array[3] = 3;
}

int fill[];
FillArray(fill);
Print(fill[0]); // output = 1
```
---
* 5.4 Overloading Functions
```mq5
bool TrailingStop(string pSymbol, int pTrailPoints, int pMinProfit = 0, int pStep = 10);
bool TrailingStop(string pSymbol, double pTrailPrice, int pMinProfit = 0, int pStep = 10);

// call the first variant of the function
// Input variables
input int TrailingPoints = 500;
// OnTick() Event handler
TrailingStop(_Symbol, TrailingPoints);

// call the second variant of the function
input int TrailingPoints = 500;
// OnTick() Event handler
double trailingPrice = SymbolInfoDouble(_Symbol, SYMBOL_ASK) - TrailingPoints * _Point);
TrailingStop (_Symbol, trailingPrice);
```
