Access Rights 
```cs
public sealed enum AccessRights
```
```cs
[Robot(AccessRights = AccessRights.Internet)]
public class SampleSARTrailingStop : Robot

//---
[Indicator(AccessRights = AccessRights.None)]
public class SampleEMA : Indicator
```
---
**Available Members**
* ```None```:Algorithm doesn’t require any access rights. When such cBot or Custom Indicator will be added to the chart the access rights dialog will not be shown.
* ```FileSystem```: Access to file system.
* ```Internet```: Access to Internet or other networks.
* ```Registry```: Access to windows registry.
* ```FullAccess```:	The unlimited access rights. Algorithms which declare FullAccess as access rights can use all the power of .NET framework including import WinApi functions, use the .NET Reflection, creating windows, etc.
---
**Multiple ```AccessRights```**
```cs
[Indicator(TimeZone = TimeZones.UTC, AccessRights = AccessRights.Internet | AccessRights.Registry)]
public class MyIndicator : Indicator
```
