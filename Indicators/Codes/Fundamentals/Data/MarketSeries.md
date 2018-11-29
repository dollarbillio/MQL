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
* Same with ```High, Low, Open```
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
```Count```: Gets the number of elements contained in the series.
```this[int index]```: Returns the DateTime value at the specified index.
```LastValue```: Gets the last value of this time series.
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

