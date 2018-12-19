* Organize trade settings so that the next time you can call back the settings easily

```mq5
struct trade_settings
{
  double take; // values of the profit fixing price
  double stop; // value of the protective stop price
  uchar slippage; // value of the acceptable slippage
};
//--- create up and initialize a variable of the trade_settings type
trade_settings my_set={0.0,0.0,5};
if (input_TP>0) my_set.take=input_TP;
```
