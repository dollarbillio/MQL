
public interface Symbol

Ask	The current ask price for this symbol.
Bid	The current bid price of this symbol.
Code	Represents the currency pair code, e.g. "EURUSD"
Digits	Number of digits for this symbol
DynamicLeverage	Dynamic leverage tiers for symbol.
LotSize	Size of 1 lot in units of base currency
MarketHours	Access to symbol's trading sessions schedule
PipSize	Pip size for current symbol
PipValue	The monetary value of one pip
Spread	The current spread of this symbol.
TickSize	Tick size for current symbol
TickValue	The monetary value of one tick
UnrealizedGrossProfit	Sum of unrealized Gross profits of positions of this Symbol
UnrealizedNetProfit	Sum of unrealized Net profits of positions of this Symbol
VolumeInUnitsMax	The maximum tradable amount
VolumeInUnitsMin	The minimum tradable amount
VolumeInUnitsStep	The minimum trade amount increament
NormalizeVolumeInUnits	Round the volume to an amount suitable for a trade
QuantityToVolumeInUnits	Convert Quantity (in lots) to Volume in units of base currency
VolumeInUnitsToQuantity	Convert Volume in units of base currency to Quantity (in lots)

double bid = Symbol.Bid;
double ask = Symbol.Ask;
string code = Symbol.Code;
int digits = Symbol.Digits;
double pipSize = Symbol.PipSize;
double pointSize = Symbol.PointSize;
double spread = Symbol.Spread;
