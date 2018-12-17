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
+ if ```totallyInside```: (lastHigh <= twoLastHigh) && (lastLow >= twoLastLow)
  + Do nothing

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
  
  

