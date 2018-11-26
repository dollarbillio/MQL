**MAIN CODE**
* Default template when created new
```cs
namespace cAlgo
{
    // The Indicator class declaration must be preceded by the indicator attribute, 
    //[Indicator()] and it should be a public Indicator derived class    
    [Indicator(IsOverlay = false, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class PracticeIndicator : Indicator
    {
        // The parameter attribute is necessary if the program will contain user input
        [Parameter(DefaultValue = 0.0)]
        public double Parameter { get; set; }

        // The Output attribute is used to display the Output of 
        // an Indicator Series on the Chart
        [Output("Main")]
        public IndicatorDataSeries Result { get; set; }

        // The Initialize method is called upon loading of an indicator
        // Typically used to initialize variables and series such as 
        // nested indicators
        protected override void Initialize()
        {
            // Initialize and create nested indicators
        }

        // Calculate method can't be ommited
        // main method of indicator
        // called on each historical bar defined by the index 
        //  and in real time on each incoming tick.
        public override void Calculate(int index)
        {
            // Calculate value at specified index
            // Result[index] = ...
        }
    }
}
```
**RELATED DOCUMENTED**

**```Indicators```** - Base class for Indicators
* Contains all necessary market information, provides access to built-in indicators and provides framework for
convenient indicators' creation.
```cs
public class Indicator : Algo, IIndicator

//---
Account: Contains information of the current account
IsLastBar: Returns true, if Calculate is invoked for the last bar
IsRealTime: Returns true, if the indicator is processing real time incoming data.
Indicator: Indicator class constructor
Calculate: Calculate the value(s) of indicator for the given index.
Initialize: Custom initialization for the Indicator. This method is invoked when an indicator is launched.
ToString: The name of the indicator derived class

//--Example
private IndicatorDataSeries input;
protected override void Initialize()
{
    input = CreateDataSeries();
}
public override void Calculate(int index)
{
    input[index] = (MarketSeries.Close[index] + MarketSeries.Open[index]) / 2;
}
```
**```IIndicator```**: Base Interface for all Indicators
```cs
public interface IIndicator

//---Available Methods
Calculate: Method to calculate the value(s) of indicator for given index.

public void Calculate(int index)

//--Example1--
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

    // +-----------------------------------+
    // | Calculate value at specified index
    // | Result[index] = ...
    // +-----------------------------------+
}

//--Example2--
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

//--Example3--
private IndicatorDataSeries input;
protected override void Initialize()
{
    input = CreateDataSeries();
}
public override void Calculate(int index)
{
    input[index] = (MarketSeries.Close[index] + MarketSeries.Open[index]) / 2;
}
```
**Indicator.Account**: Contains information about the current account
```cs
public IAccount Account{ get; }

//---
Return IAccount
public interface IAccount

AccountType: Returns current account type
Balance: Returns the balance of the current account.
BrokerName: Returns the broker name of the current account
Currency: Returns the currency of the current account, e.g. "EUR".
Equity: Represents the equity of the current account (balance plus unrealized profit and loss).
FreeMargin: Represents the free margin of the current account.
IsLive: True if the Account is Live, False if it is a Demo
Margin: Represents the margin of the current account.
MarginLevel: Returns margin level of the current account. Margin level (in %) is calculated using this formula: Equity / Margin * 100
Number; Returns the number of the current account, e.g. 123456.
PreciseLeverage: The account leverage
StopOutLevel: Stop Out level is a lowest allowed Margin Level for account. If Margin Level is less than Stop Out, position will be closed sequentially until Margin Level is greater than Stop Out.
UnrealizedGrossProfit	
UnrealizedNetProfit	

//--Example--
if (Account.Balance < 10000)
    Print(Account.Balance);
```
**```Indicators```**: Access to built-in Indicators
```cs
public IIndicatorsAccessor Indicators{ get; }

//--Return IIndicatorsAccessor

//--Example--
protected override void Initialize()
{
    //Use MarketSeries price data as parameters to indicators
    _ma = Indicators.SimpleMovingAverage(MarketSeries.Close, 20);
}

//--List of indicators can be found in cAlgo
```
**```IndicatorAttribute```**: Indicator Attribute. Applies metadata to enable the indicator plot.
* To make it effective apply enclosed in square brackets, e.g. [Indicator] before the indicator class declaration. Cannot be ommited.
```cs
public sealed class IndicatorAttribute : Attribute

//-- Setting Attributes
AccessRights: AccessRights required for Indicator
AutoRescale: Indicates whether this instance automatically rescales the chart or not
IsOverlay: Indicates whether this instance is overlayed on the chart or plotted on a separate indicator panel
Name: The name of the indicator
ScalePrecision: The price scale precision
TimeZone: The chart timezone of the displayed indicator
IndicatorAttribute: Initializes a new instance of the IndicatorAttribute and sets the name of the indicator
IndicatorAttribute: Initializes a new instance of the IndicatorAttribute

//--Example
[Indicator("IndicatorName", ScalePrecision = 5, IsOverlay = false, TimeZone = TimeZones.UTC)] 
public class SampleIndicator : Indicator
```
**```IndicatorDataSeries```**: Represents a mutable array of values. An extension of DataSeries used to represent indicator values.
```cs
public interface IndicatorDataSeries : DataSeries

//  The following example is the calculation of the simple moving average 
//  of the median price
[Output("Result")]
public IndicatorDataSeries Result { get; set; }
private IndicatorDataSeries _dataSeries;
private SimpleMovingAverage _simpleMovingAverage;
protected override void Initialize()
{
    _dataSeries = CreateDataSeries();
    _simpleMovingAverage = Indicators.SimpleMovingAverage(_dataSeries, 14);
}
public override void Calculate(int index)
{
    _dataSeries[index] = (MarketSeries.High[index] + MarketSeries.Low[index])/2;
    Result[index] = _simpleMovingAverage.Result[index];
}

