* In order to be able to create a robot, we need a normal indicator to indicate are we going to buy or sell, regardless of any stoploss 
and profit taking mechanism
--- 
Indicator
* We start by letting the candle index 0 as having highestHigh = 0 and lowestLow = 0
* We then start with index 1 as having highestHigh and lowestLow that of candle index 0
* Starting from index 2, we will have many conditions
---
Condition:
1) If the candle is normal spread

+ if ```totallyInside```: 
  + When a candle has its low updated as **new** ```lowestLow```, we first need to check if the spread of the candle is too small.
    If the current candle is too small (<= 2.5 pips), we need to take the high of the previous candle. This is done in order to verify   
    better inside candle. In case that the previous candle is too big spread. We will create an artificial spread: lowestLow + 3 pips
    We name these: lowestLow and followingHigh, highestHigh and followingLow
    + => ```totallyInsideBear```: (lastHigh <= followingHigh) && (lastLow >= lowestLow) [sell momentum]
    + => ```totallyInsideBull```: (lastHigh <= highestHigh) && (lastLow >= followingLow) [buy momentum] 
  + Do nothing

+ if ```CloseInside```: 
  + 


+ if ```CloseOutside```
  + If ```notEngulfing```: not (lastHigh >= twoLastHigh && lastLow <= twoLastLow) 
    + if ```lastCandleIsBear```: Calculate (highestHigh - currentClose)
      + if (highestHigh - currentClose) > 7: that is a sell order
      + if (highestHigh - currentClose) < 7: we move to the next candle. 
      + if after many candles, before (highestHigh - currentClose) > 7 and get back to (currentClose >= highestHigh), we update highestHigh
    
    + if ```lastCandleIsBull```: Calculate currentClose - lowestLow
      + if (currentClose - lowestLow) > 7: that is a buy order
      + if (currentClose - lowestLow) < 7: we move to the next candle. 
      + if after many candles, before (currentClose - lowestLow) > 7 and get back to (currentClose <= lowestLow), we update lowestLow
  
  

