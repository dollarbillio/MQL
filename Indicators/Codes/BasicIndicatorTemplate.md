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
