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
+ if the previous of this candle is oversized, we update this highestHigh and lowestLow as High and Low of this normal candle

+ if ```totallyInside```: 
  + When a candle has its low updated as **new** ```lowestLow```, we first need to check if the spread of the candle is too small.
    If the current candle is too small (<= 2.5 pips), we need to take the high of the previous candle. This is done in order to verify   
    better inside candle. In case that the previous candle is too big spread. We will create an artificial spread: lowestLow + 3 pips
    We name these: lowestLow and followingHigh, highestHigh and followingLow
    + => ```totallyInsideBear```: (lastHigh <= followingHigh) && (lastLow >= lowestLow) [sell momentum]
    + => ```totallyInsideBull```: (lastHigh <= highestHigh) && (lastLow >= followingLow) [buy momentum] 
  + Do nothing

+ if ```CloseInside``` and ```oneTailOutside```: a candle close inside when it is between ```lowestLow and followingHigh``` and '''highestHigh and followingLow```
  + If the candle wick is ```low``` but ```isBullCandle```, we see that its ```wick``` and ```color``` are different
  We will do nothing. as there are still confusion
  + If the wick and the candle go together, we will update low and high as well as ```followingHigh``` and ```followingLow``` as 
  of the other wick of the candle.
  + I would say that the ```followingHigh``` and ```followingLow``` must be suppassed and the currentcandle close ```> or <``` than 
  the ```lowestLow``` and the ```highestHigh``` before a signal is made

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
---
---
2) The candle has small spread
  + If the previous candle of this candle is an oversized candle:
    + If the candle inside the previous big sized candle, 
      if the big candle is ```bullCandle```, we take the ```highestHigh``` as the high of this candle and ```followingLow``` as the           ```high - 3``` and start doing the same thing again. 
      if the big candle is ```bearCandle```, we update the ```lowestLow``` as the low of this candle and ```followingHigh``` as the 
      ```low + 3``` and start doing the same thing again
  + If the previous candle is normal candle: we don't do anything. Return
---
---
3) The candle has unusual spread
* Don't take any trade when the previouscandle is too large. Wait at least for the candle to go back to normal. It is ok
* Update ```HighestHigh``` and ```lowestLow```
---
---
* Remember the time of day affect spread and all other stoploss


