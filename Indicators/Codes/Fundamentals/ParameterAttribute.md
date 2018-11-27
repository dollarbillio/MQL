## ParameterAttribute
* Able to choose parameter from drop down list
```cs
public class ParameterAttribute : Attribute
```
---
**MEMBERS**
---
```cs
public Object DefaultValue{ get; set; }
```
* Gets or sets the default value of this Parameter property
```cs
[Parameter(DefaultValue = 14)] 
public int Periods { get; set; }
```
---
```cs
public Object MaxValue{ get; set; }
```
* Gets or sets the maximum value of this Parameter property. Used for validating user input.
```cs
[Parameter(DefaultValue = 14, MaxValue = 20)] 
public int Periods { get; set; }
```
---
```cs
public Object MinValue{ get; set; }
```
* Gets or sets the maximum value of this Parameter property. Used for validating user input.
```cs
[Parameter(DefaultValue = 14, MinValue = 5)] 
public int Periods { get; set; }
```
---
```cs
public string Name{ get; }
```
* Name of the indicator
```cs
[Parameter("MaPeriod")]
public int Period { get; set; } 
```
---
