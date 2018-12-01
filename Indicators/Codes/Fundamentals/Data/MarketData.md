```Indicator.MarketData | Robot.MarketData | Algo.MarketData```
```cs 
public MarketData MarketData{ get; }

//--
private MarketDepth _md;
_md = MarketData.GetMarketDepth("GBPUSD");
```
* Provides access to Depth of Market Data
* Return ```MarketData```
---
---
**MEMBERS of ```public interface MarketData```**
---
---
**GetMarketDepth - returns MarketDepth**
```cs
public MarketDepth GetMarketDepth(string symbolCode)

//---
MarketDepth md = MarketData.GetMarketDepth("EURUSD");
```
**Members of ```public interface MarketDepth```**
* ```IReadonlyList MarketData.GetMarketDepth("EURUSD).Ask/BidEntries```:
```cs
public IReadonlyList Ask/BidEntries{ get; }

//--
Count	The total number of elements contained in the collection
this[int index]	Represents the item contained in the collection at a specific index
``
* ``` public even MarketData.GetMarketDepth("EURUSD).Updated```
```cs
public event Action Updated

MarketDepth _marketDepth;
protected override void Initialize()
{
    _marketDepth = MarketData.GetMarketDepth(Symbol);
    // subscribe to event Updated
    _marketDepth.Updated += MarketDepthUpdated;
}
// user defined function MarketDepthUpdated
void MarketDepthUpdated()
{
    // Do something
}
```
---
---
**GetSeries - returns MarketSeries**
```cs
public MarketSeries GetSeries(Symbol symbol, TimeFrame timeFrame)

//---
var marketSeriesMin30 = MarketData.GetSeries(TimeFrame.Minute30);
var smaMin30 = Indicators.SimpleMovingAverage(marketSeriesMin30.Close, 14);
```
---
---
**GetSymbol - returns Symbol**
```cs
public Symbol GetSymbol(string symbolCode)

//---
Symbol USDCAD = MarketData.GetSymbol("USDCAD");
var usdCadAsk = USDCAD.Ask;
```
