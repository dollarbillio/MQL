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

public interface MarketSeries

Close	Close price series of historical trendbars.
public DataSeries Close{ get; }

[Parameter(DefaultValue = 14)]
public int Period { get; set; }
private SimpleMovingAverage smaClose
protected override void Initialize()
{
    //Simple moving average of the Close prices series for the specified period
    smaClose = Indicators.SimpleMovingAverage(MarketSeries.Close, Period);
}

Return DataSeries

//Accessing historical OHLC prices from Indicators 
double close = MarketSeries.Close[index];
double high = MarketSeries.High[index];
double low = MarketSeries.Low[index];
double open = MarketSeries.Open[index];

//Accessing historical O-H-L-C prices from Robots
int index = MarketSeries.Close.Count-1;
double close = MarketSeries.Close[index];
double high = MarketSeries.High[index];
double low = MarketSeries.Low[index];
double open = MarketSeries.Open[index];



High	Highest price series of historical trendbars.
public DataSeries High{ get; }

Low	Low price series of historical trendbars.
Median	Median price series of historical trendbars.
Open	Open price series of historical trendbars.
OpenTime	Open Time series of historical trendbars.
public TimeSeries OpenTime{ get; }

Print("{0}", MarketSeries.OpenTime[index]);     
Print("{0}", MarketSeries.OpenTime[index].Day); 
Print("{0}", MarketSeries.OpenTime[index].Hour);

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

public class TimeFrame : Object

public static TimeFrame Daily

Daily	Daily Timeframe
Day2	2 day Timeframe
Day3	3 day Timeframe
Hour	1 hour Timeframe
Hour12	12 hour Timeframe
Hour2	2 hour Timeframe
Hour3	3 hour Timeframe
Hour4	4 hour Timeframe
Hour6	6 hour Timeframe
Hour8	8 hour Timeframe
Minute	1 Minute Timeframe
Minute10	10 Minute Timeframe
Minute15	15 Minute Timeframe
Minute2	2 Minute Timeframe
Minute20	20 Minute Timeframe
Minute3	3 Minute Timeframe
Minute30	30 Minute Timeframe
Minute4	4 Minute Timeframe
Minute45	45 Minute Timeframe
Minute5	5 Minute Timeframe
Minute6	6 Minute Timeframe
Minute7	7 Minute Timeframe
Minute8	8 Minute Timeframe
Minute9	9 Minute Timeframe
Monthly	Monthly Timeframe
Weekly	Weekly Timeframe
ToString	Convert the TimeFrame property to a string

if(TimeFrame  < TimeFrame.Daily)
    Print("Intraday Trading");

Typical	Typical price series of historical trendbars.
WeightedClose	Weighted price series of historical trendbars.


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
