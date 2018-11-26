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
```
```SimpleMovingAverage```: The simple moving average smoothes the price data producing a trend indicator
```cs
public SimpleMovingAverage SimpleMovingAverage(DataSeries source, int periods)

//--
source	The source data used for SMA calculation.
periods	The periods used in the calculation.

//--Return
public interface SimpleMovingAverage : MovingAverage, IIndicator

[Indicator]
public class SimpleMovingAverageExample : Indicator
{
    [Parameter]
    public DataSeries Source { get; set; }
    [Parameter(DefaultValue = 14, MinValue = 2)]
    public int Periods { get; set; }
    [Output("Result", Color = Colors.Orange)]
    public IndicatorDataSeries Result { get; set; }
    private SimpleMovingAverage _simpleMovingAverage;
    protected override void Initialize()
    {
        _simpleMovingAverage = Indicators.SimpleMovingAverage(Source, Periods);
    }
    public override void Calculate(int index)
    {
        var average = _simpleMovingAverage.Result[index];
        double sum = 0;
        for (var period = 0; period < Periods; period++)
        {
            sum += Math.Pow(Source[index - period] - average, 2.0);
        }
        Result[index] = Math.Sqrt(sum / Periods);
    }
}

+---------| Example |---------+
private SimpleMovingAverage sma;
protected override void Initialize()
{
    sma = Indicators.SimpleMovingAverage(MarketSeries.Close, 14);
}
public override void Calculate(int index)
{
    Result[index] = sma.Result[index]; 
}
```
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