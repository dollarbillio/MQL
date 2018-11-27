**Indicator aka newTemplate**
* Template for indicator creation 
* Contains Abstract ```Method```
```cs
public class Indicator : Algo, IIndicator
```
* **Members**
---
```[Method] Indicator()```: Indicator Class Constructor
* Default, don't do anything
---
```Account [Property]```    
* Contains information of the current account
* Returns IAccount
```cs
// Account
public IAccount Account{ get; }

if (Account.Balance < 10000)
    Print(Account.Balance);
```
```Account [Property] => IAccount [Interface]```
* Contains information of the current account
```cs
public interface IAccount
```
* All Property

```AccountType```: Returns the current account type.

```Balance```: Returns the balance of the current account.

```BrokerName```: Returns the broker name of the current account.

```Currency```: Returns the currency of the current account, e.g. "EUR".

```Equity```: Represents the equity of the current account (balance minus Unrealized Net Loss plus Unrealized Net Profit plus Bonus).

```FreeMargin```: Represents the free margin of the current account.

```IsLive```: Defines if the account is Live or Demo. True if the Account is Live, False if it is a Demo.

```Margin```: Represents the margin of the current account.

```MarginLevel```: Represents the margin level of the current account. Margin level (in %) is calculated using this formula: 
Equity / Margin * 100

```Number```: Returns the number of the current account, e.g. 123456.

```PreciseLeverage```: Gets the precise account leverage value.

```StopOutLevel```: Stop Out level is a lowest allowed Margin Level for account. If Margin Level is less than Stop Out, position will be closed sequentially until Margin Level is greater than Stop Out.

```UnrealizedGrossProfit```: Gets the Unrealized Gross profit value.

```UnrealizedNetProfit```: Gets the Unrealized Gross profit value.	

```cs
// Example
// Account Properties
// Current Account Balance 
double balance = Account.Balance;   
// Current Account Currency e.g. EUR
string currency = Account.Currency; 
// Current Account Equity 
double equity = Account.Equity;     
// Current Account Free Margin   
double freemargin = Account.FreeMargin; 
// Current Account Margin
double margin = Account.Margin;
//Margin level = Equity / Margin * 100
double? marginlevel = Account.MarginLevel; 
```
---
```[Method] Calculate()```
* This is where we put our main logic to calculate value of 1 point of the indicator for the given index
```public void Calculate(int index)```
```cs
//...
public override void Calculate(int index)
{
    //This is where we place our indicator's calculation logic.
}
//...
```
---
```IsLastBar Property```: Returns true, if Calculate is invoked for the last bar
```cs
public bool IsLastBar{ get; }

public override void Calculate(int index)
   if (IsLastBar)
   {
       // this is the current (last) index
   }
```
---
```IsRealTime Property```: Returns true if the processing real time incoming data
```cs
public bool IsRealTime{ get; }

public override void Calculate(int index)
   if (IsRealTime)
   {
       //Place the code-logic that you want to be calculated on incoming live data
   }
```
---
```[Method] Initialize```: Custom initialization for the Indicator. This method is invoked when an indicator is launched.
```cs
protected virtual void Initialize()

//...
protected override void Initialize()
{
    //Place your Initialization logic here
}
```
---
```[Method] ToString```: The name of the indicator derived class
```cs
public override string ToString()

private SampleSMA sma;
//...
sma = Indicators.GetIndicator<SampleSMA>(Source, Period);
Print(sma.ToString());
```
---





**```IIndicator Interface```**
* Base class for all indicator
```cs
public interface IIndicator

// Built-In methods
Calculate: Method to calculate the value(s) of indicator for given index, will be rolling
    public void Calculate(int index)

// Example_1
[Parameter("Period", DefaultValue = 14)]
public int Period { get; set; }
//...
public override void Calculate(int index)
{
    // Calculate value at specified index
    
    // if the index is less than Period exit
    if(index < Period)
        return;
        
    // Maximum returns the largest number in the Series in the range [Series[index-Period], Series[index]]
    double high = MarketSeries.High.Maximum(Period);
    // Minimum returns the smallest number in the Series in the range [index - Period, index]
    double low = MarketSeries.Low.Minimum(Period);
    double center = (high + low) / 2;
    // Display Result of Indicator
    Result[index] = center;
}

// Example_2: SimpleMovingAverage
[Parameter]
public DataSeries Source { get; set; }
[Parameter("Periods", DefaultValue = 25)]
public int Periods { get; set; }
//...
public override void Calculate(int index)
{ 
    // Simple moving average calculation
    double sum = 0.0;
    for (int i = index - Periods + 1; i <= index; i++)
    {
        sum += Source[i];
    }
    Result[index] = sum / Periods;
}
```




**IIndicatorsAccessors**
* Accessor to Indicators
```cs
public interface IIndicatorsAccessor

+-------|Example|-------+
public IIndicatorsAccessor Indicators{ get; }
// initialize indicator variable
protected override void Initialize()
{
    //Use MarketSeries price data as parameters to indicators
    _ma = Indicators.SimpleMovingAverage(MarketSeries.Close, 20);
}
```
---
+-------|Built-In Method|------+
```cs
AcceleratorOscillator	Initializes the AcceleratorOscillator indicator instance
AcceleratorOscillator	Initializes the AcceleratorOscillator instance for specific timeframe
AccumulativeSwingIndex	Initializes the Accumulative Swing Index indicator
AccumulativeSwingIndex	Initializes the Accumulative Swing Index indicator for a specific timeframe
Aroon	The Aroon indicator is used to identify trends and their reversals.
Aroon	Initializes the Aroon indicator instance
AverageTrueRange	Average true range. An indicator providing the degree of price volatility.
AverageTrueRange	Initializes the AverageTrueRange instance for a specific timeframe
AwesomeOscillator	Initializes the AwesomeOscillator indicator instance
AwesomeOscillator	Initializes the AwesomeOscillator instance for specific timeframe
BollingerBands	The Bollinger Bands indicator shows volatility.
ChaikinMoneyFlow	The Chaikin Money Flow indicator measures the money flow volume over a specific period.
ChaikinMoneyFlow	Initializes the ChaikinMoneyFlow indicator instance for a specific timeframe
ChaikinVolatility	The Chaikin Volatiliy indicator measures the trading range between the high and the low prices.
ChaikinVolatility	Initializes the ChaikinVolatility indicator instance for a specific timeframe
CommodityChannelIndex	The Commodity Channel Index identifies overbough and oversold conditions, price reversals and trend strength.
CommodityChannelIndex	Initializes the CommodityChannelIndex indicator instance for a specific timeframe
DetrendedPriceOscillator	The Detrended Price Oscillator shows intermediate overbought and oversold levels.
DirectionalMovementSystem	The Directional Movement System is composed of three indicators that show if the market is trending and provide signals.
DirectionalMovementSystem	Initializes the Directional Movement System Indicator instance for a specific timeframe
DonchianChannel	The Donchian channel is a volatility indicator forming a channel between the highest high and the lowest low of the chosen period.
DonchianChannel	Initializes the DonchianChannel instance for a specific timeframe
EaseOfMovement	The Ease Of Movement indicator relates the price change to the volume.
EaseOfMovement	Initializes the EaseOfMovement indicator instance for a specific timeframe
ExponentialMovingAverage	The Exponential Moving Average smoothes the price data producing a trend indicator.
FractalChaosBands	The Fractal Chaos Bands indicator breaks down large trends into predictable patterns.
FractalChaosBands	Initializes the FractalChaosBands indicator instance for a specific timeframe
GetIndicator	Initializes the custom indicator
GetIndicator	Initializes the custom indicator for a specific timeframe
HighMinusLow	The High Minus Low indicator is used to compute the range of daily bars
HighMinusLow	Initializes the High Minus Low indicator for a specific timeframe
HistoricalVolatility	The Historical Volatility indicator is derived from time series of past market prices.
IchimokuKinkoHyo	Ichimoku Kinko Hyo Indicator is a moving average based trend identification system.
IchimokuKinkoHyo	Initializes the IchimokuKinkoHyo indicator instance for a specific timeframe
KeltnerChannels	Initializes the Keltner Channels indicator instance
KeltnerChannels	Initializes the Keltner Channels indicator instance for specific MarketSeries
LinearRegressionForecast	Linear Regression Forecast is a trend indicator used to forecast values using the Least Squares Fit method.
LinearRegressionIntercept	The Linear Regression Intercept can be used together with the Linear Regression Slope indicator to plot the Linear Regression Line.
LinearRegressionRSquared	The R Squared or coefficient of determination indicator's main purpose is the confirm the strength of the market.
LinearRegressionSlope	The Linear Regression Slope indicator is intended to measure the direction and strength of a trend.
MacdCrossOver	The MACD Line with the Signal line and their difference as a histogram.
MacdCrossOver	Initializes the MacdCrossOver indicator instance for a specific source series
MacdHistogram	The MACD Histogram is a momentum indicator measured by typically subtracting a 26 period moving average from a 12 period moving average.
MacdHistogram	Initializes the MacdHistogram indicator instance for a specific source series
MassIndex	The Mass Index indicator is used to predict trend reversals.
MassIndex	Initializes the MassIndex indicator instance for a specific timeframe
MedianPrice	The Median indicator is the average of the high and the low.
MedianPrice	Initializes the Median indicator instance for a specific timeframe
MomentumOscillator	The Momentum Oscillator measures the momentum of the price.
MoneyFlowIndex	The Money Flow Index measures the strength of the money flow.
MoneyFlowIndex	Initializes the MoneyFlowIndex instance for a specific timeframe
MovingAverage	Moving Average indicators are used to smooth data producing trend indicators.
NegativeVolumeIndex	The Negative Volume Index is a calculation of the percentage change in price on days when trading volume declines.
OnBalanceVolume	The On Balance Volume indicator relates price and volume.
ParabolicSAR	The Parabolic SAR indicator identifies potential reversals in the market direction
ParabolicSAR	Initializes the ParabolicSAR Indicator instance for a specific timeframe
PositiveVolumeIndex	The Positive Volume Index is a calculation of the percentage change in price on days when trading volume increased.
PriceOscillator	The Price Oscillator calculates the difference between two moving averages.
PriceROC	The Price Rate of Change indicator is the percentage change of the current price and the price N periods ago.
PriceVolumeTrend	The Price Volume Trend indicator shows the relationship between price and volume.
RainbowOscillator	The Rainbow Oscillator is a process of repetitive smoothing of simple moving averages resulting in a full spectrum of trends.
RelativeStrengthIndex	The Relative Strength Index indicator measures turns in price by measuring turns in momentum.
StandardDeviation	The Standard Deviation indicator shows volatility.
StochasticOscillator	The Stochastic Oscillator is a momentum indicator that aims to show price reversals by comparing the closing price to the price range.
StochasticOscillator	Initializes the StochasticOscillator Indicator instance for a specific timeframe
SwingIndex	Returns the Swing Index indicator instance.
SwingIndex	Returns the Swing Index indicator instance.
TimeSeriesMovingAverage	The Time Series Moving Average is a moving average based on linear regression
TradeVolumeIndex	Trade Volume Index indicator measures the amount of money flowing in and out of an asset.
TriangularMovingAverage	The Triangular Moving Average is averaged twice to produce a double smoothed trend indicator
Trix	The Trix indicator shows the slope of a triple-smoothed exponential moving average.
TrueRange	Initializes the True Range indicator.
TrueRange	Initializes the True Range indicator for a specific timeframe
TypicalPrice	The Typical Price indicator is the average of the high, low, and closing prices.
TypicalPrice	Initializes the TypicalPrice indicator instance for a specific timeframe
UltimateOscillator	Returns the Ultimate Oscillator indicator instance.
UltimateOscillator	Initializes the UltimateOscillator instance for a specific timeframe
VerticalHorizontalFilter	The Vertical Horizontal Filter indicator measures the level of trend activity.
Vidya	Volatility Index Dynamic Average (VIDYA) is a smoothing (moving average) based on dynamically changing periods.
VolumeOscillator	The Volume Oscillator indicator is the difference between two moving averages.
VolumeOscillator	Initializes the VolumeOscillator instance for a specific timeframe
VolumeROC	Volume Rate of Change Indicator measures the rate of change of the tick volume.
VolumeROC	Initializes the VolumeROC instance for a specific timeframe
WeightedClose	The WeightedClose indicator is an average of each day's price with extra weight given to the closing price.
WeightedClose	Initializes the WeightedClose indicator instance for a specific timeframe
WeightedMovingAverage	The Weighted Moving Average smoothes the price data producing a trend indicator.
WellesWilderSmoothing	Welles Wilder Smoothing eliminates noise to identify the trend.
WilliamsAccumulationDistribution	The Williams Accumulation Distribution indicator shows bullish or bearish trends.
WilliamsAccumulationDistribution	Initializes the WilliamsAccumulationDistribution indicator instance for a specific timeframe
WilliamsPctR	The Williams Percent R indicator is a momentum indicator measuring overbought and oversold levels.
WilliamsPctR	Initializes the WilliamsPctR indicator instance for a specific timeframe
```
