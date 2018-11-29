```Indicator.MarketData```
```Robot.MarketData```
```cs 
public MarketData MarketData{ get; }
```
* Provides access to Depth of Market Data
* Return ```MarketData```
---
MEMBERS:
---
```cs

```
* Access to MarketDepth Ask Entries, Bid Entries and the event at which the market depth gets updated
```cs
public MarketDepth GetMarketDepth(string symbolCode)

MarketDepth md = MarketData.GetMarketDepth("EURUSD");

public interface MarketDepth

```cs
public MarketSeries GetSeries(TimeFrame timeFrame)

var marketSeriesMin30 = MarketData.GetSeries(TimeFrame.Minute30);
var smaMin30 = Indicators.SimpleMovingAverage(marketSeriesMin30.Close, 14);


High	Highest price series of historical trendbars.
public DataSeries High{ get; }

Low	Low price series of historical trendbars.
Median	Median price series of historical trendbars.
Open	Open price series of historical trendbars.
OpenTime	Open Time series of historical trendbars.
public TimeSeries OpenTime{ get; }


SymbolCode	The code representation of the symbol that the MarketSeries is subscribed to
public string SymbolCode{ get; }

Print("{0}", MarketSeries.SymbolCode); 


Symbol eurUsd = MarketData.GetSymbol("EURUSD");
MarketSeries seriesEurUsd = MarketData.GetSeries(eurUsd, TimeFrame.Daily);
Print(seriesEurUsd.SymbolCode);


TickVolume	Volume of Ticks for Historical Trendbars
public DataSeries TickVolume{ get; }

public override void Calculate(int index)
{
    double currentVolume = MarketSeries.TickVolume[index];
    double previousVolume = MarketSeries.TickVolume[index-1];
}


TimeFrame	The timeframe that the MarketSeries is subscribed to
public TimeFrame TimeFrame{ get; }

Print("{0}", MarketSeries.TimeFrame);  

Symbol eurUsd = MarketData.GetSymbol("EURUSD");
MarketSeries seriesEurUsd = MarketData.GetSeries(eurUsd, TimeFrame.Daily);
Print(seriesEurUsd.TimeFrame);

---
public MarketSeries GetSeries(string symbolCode, TimeFrame timeFrame)

var daily = MarketData.GetSeries("EURUSD", TimeFrame.Daily);
var sma = Indicators.SimpleMovingAverage(daily.Close, 14);

Symbol USDCAD = GetSymbol("USDCAD");
var daily = MarketData.GetSeries(USDCAD, TimeFrame.Daily);
var sma = Indicators.SimpleMovingAverage(daily.Close, 14);

---
GetSymbol	Get the Symbol given the symbol's string name representation

public Symbol GetSymbol(string symbolCode)
Symbol USDCAD = MarketData.GetSymbol("USDCAD");
var usdCadAsk = USDCAD.Ask;
