## IndicatorAttribute
---
```cs
public sealed class IndicatorAttribute : Attribute
```
* Indicator Attribute. Applies metadata to enable the indicator plot
* Make it effective <= applies square bracket [Indicator()]
```cs
// Example
[Indicator("IndicatorName", ScalePrecision = 5, IsOverlay = false, TimeZone = TimeZones.UTC)] 
public class SampleIndicator : Indicator
```
---
**MEMBERS**
---
```cs
public sealed enum AccessRights
```
* AccessRights required for Indicator
```cs
// GetterSetter
public AccessRights AccessRights{ get; set; }

```
* ```AccessRights.FileSystem```: Access to file system
* ```AccessRights.FullAccess```: Unlimited access right
* ```AccessRights.Internet```: Access to internet
* ```AccessRights.None```: Doesn't need any access right
* ```AccessRights.Registry```: Access to windows registry
---
```cs
public bool AutoRescale{ get; set; }
``` 
* Indicates whether this instance automatically rescales the chart or not
```cs
[Indicator(AutoRescale = false)]
public class SampleIndicator : Indicator
```
---
```cs
public bool IsOverlay{ get; set; }
```
* Indicate whether the indicator is plotted on the chart or separate window
```cs
[Indicator(IsOverlay = true)] // Plots the Indicator on the chart
public class SampleIndicator : Indicator
```
---
```cs
public string Name{ get; }
```
* The name is displayed on the top left of the indicator panel
```cs
namespace cAlgo.Indicators
{
    [Indicator("IndicatorName")] 
    public class SampleIndicator : Indicator
    {
        //...
    }
}
```
---
```cs
public int ScalePrecision{ get; set; }
```
* The number of decimals displayed on the price scale of the indicator panel
```cs
namespace cAlgo.Indicators
{
    [Indicator(ScalePrecision = 5)] // The scale precision is 5 decimals
    public class SampleIndicator : Indicator
    {
        //...
    }
}
```
---
```cs
public string TimeZone{ get; set; }
```
* The chart timezone of the displayed indicator
```cs
[Indicator(TimeZone = TimeZones.UTC)]
public class SampleIndicator : Indicator
```
---
