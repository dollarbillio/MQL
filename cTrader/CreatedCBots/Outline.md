* In order to be able to create a robot, we need a normal indicator to indicate are we going to buy or sell, regardless of any stoploss 
and profit taking mechanism
--- 
Indicator
* We start by letting the candle index 0 as having highestHigh = 0 and lowestLow = 0
* We then start with index 1 as having highestHigh and lowestLow that of candle index 0
* Starting from index 2, we will have many conditions
---
Condition:
1) If the candle is normal spread:
