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
```[Method] Initialize()```: Custom initialization for the Indicator. This method is invoked when an indicator is launched.
```cs
protected virtual void Initialize()

//...
protected override void Initialize()
{
    //Place your Initialization logic here
}
```
---
```[Method] ToString()```: The name of the indicator derived class
```cs
public override string ToString()

private SampleSMA sma;
//...
sma = Indicators.GetIndicator<SampleSMA>(Source, Period);
Print(sma.ToString());
```
---
