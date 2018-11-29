```Indicator.MarketSeries | Robot.MarketSeries | Algo.MarketSeries```
---
```cs
public MarketSeries MarketSeries{ get; }

//---
//Access price and time data through MarketSeries
var closePrice = MarketSeries.Close[index];
var openTime = MarketSeries.OpenTime.LastValue;
```
* Market series of the current symbol and timeframe
* Access to Open, High, Low, Close, Typical, Median and Weighted Price, Open Time and current Timeframe
---
---
**Returns**
```cs
public interface MarketSeries

//---
//Accessing historical O-H-L-C prices from Robots and Indicators
int index = MarketSeries.Close.Count-1;
double close = MarketSeries.Close[index];
double high = MarketSeries.High[index];
double low = MarketSeries.Low[index];
double open = MarketSeries.Open[index];
```
* Provides access to market data such as the DataSeries Open, High, Low, Close.
* Access to the Open, Hight, Low, Close, Median, Typical, Weighted price series
as well as OpenTime for the current symbol and timeframe.
---
---
**Members of MarketSeries**
```cs
public DataSeries Close{ get; }

//---
[Parameter(DefaultValue = 14)]
public int Period { get; set; }
private SimpleMovingAverage smaClose
protected override void Initialize()
{
    //Simple moving average of the Close prices series for the specified period
    smaClose = Indicators.SimpleMovingAverage(MarketSeries.Close, Period);
}
```
* Close price series of historical trendbars.
* Same with ```High, Low, Open, Typical, WeightedClose```
---
```cs
public DataSeries Median{ get; }

//---
protected override void OnBar()
{
    int currentIndex = MarketSeries.Median.Count - 1;
    var currentTypical = MarketSeries.Median[currentIndex];     //The current Median price
    var previousTypical = MarketSeries.Median[currentIndex - 1]; //The previous Median price
    if (currentTypical < previousTypical)
    {
        // Do something
    }
}
```
* Median price series of historical trendbars.
---
```cs
public TimeSeries OpenTime{ get; }

//---
//Accessing historical Open Times
Print("{0}", MarketSeries.OpenTime[index]);     
Print("{0}", MarketSeries.OpenTime[index].Day); 
Print("{0}", MarketSeries.OpenTime[index].Hour);
```
* Open Time series of historical trendbars.
```cs
public interface TimeSeries
```
* A series of values that represent time like MarketSeries.OpenTime
* Available ```members``` of TimeSeries
---
* ```Count```: Gets the number of elements contained in the series.
* ```this[int index]```: Returns the DateTime value at the specified index.
* ```LastValue```: Gets the last value of this time series.
---
```cs
public int GetIndexByExactTime(DateTime dateTime)	

//---
var indexSeries2 = indexSeries2.OpenTime.GetIndexByExactTime(MarketSeries.OpenTime.LastValue);
```
* Find the index in a different time frame series
---
```cs
public int GetIndexByTime(DateTime dateTime)

//---
var indexSeries2 = indexSeries2.OpenTime.GetIndexByTime(MarketSeries.OpenTime.LastValue);
```
* Find the index in a different time frame series
---
```cs
public DateTime Last(int index)

//---
DateTime openTime = MarketSeries.OpenTime.Last[5];
```
* Access a value in the dataseries certain bars ago
---
---
```cs
public string SymbolCode{ get; }

//---
Print("{0}", MarketSeries.SymbolCode);  

Symbol eurUsd = MarketData.GetSymbol("EURUSD");
MarketSeries seriesEurUsd = MarketData.GetSeries(eurUsd, TimeFrame.Daily);
Print(seriesEurUsd.SymbolCode);
```
* The code representation of the symbol that the MarketSeries is subscribed to
---
---
```cs
public DataSeries TickVolume{ get; }

//---
public override void Calculate(int index)
{
    double currentVolume = MarketSeries.TickVolume[index];
    double previousVolume = MarketSeries.TickVolume[index-1];
}
```
* Volume of Ticks for Historical Trendbars
---
---
```cs
public TimeFrame TimeFrame{ get; }

//---
Print("{0}", MarketSeries.TimeFrame); 

Symbol eurUsd = MarketData.GetSymbol("EURUSD");
MarketSeries seriesEurUsd = MarketData.GetSeries(eurUsd, TimeFrame.Daily);
Print(seriesEurUsd.TimeFrame);
```
* The timeframe that the MarketSeries is subscribed to
```cs
public class TimeFrame : Object

//---
if(TimeFrame  < TimeFrame.Daily)
    Print("Intraday Trading"); 
```
---
**Available time frame**

* ```Hour```: 1 hour Timeframe
* ```Minute```:	1 Minute Timeframe
* ```Minute10```: 10 Minute Timeframe
* ```Minute15```: 15 Minute Timeframe
* ```Minute2```: 2 Minute Timeframe
* ```Minute20```: 20 Minute Timeframe
* ```Minute3```: 3 Minute Timeframe
* ```Minute30```: 30 Minute Timeframe
* ```Minute4```: 4 Minute Timeframe
* ```Minute45```: 45 Minute Timeframe
* ```Minute5```: 5 Minute Timeframe
* ```Minute6```: 6 Minute Timeframe
* ```Minute7```: 7 Minute Timeframe
* ```Minute8```: 8 Minute Timeframe
* ```Minute9```: 9 Minute Timeframe
* ```ToString```: Convert the TimeFrame property to a string
