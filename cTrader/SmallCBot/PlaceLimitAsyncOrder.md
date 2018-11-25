**MAIN CODE **
* This Bot uses lambda function in the callback action argument
```cs
protected override void OnStart()
{
    PlaceLimitOrderAsync(TradeType.Buy, Symbol, 1000, Symbol.Ask - 20 * Symbol.PipSize, "myLabel", 
                        result => Print(result.ToString()));
}
```
---
**RELATED DOCUMENTED**

