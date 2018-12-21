**```MqlDateTime```**
```mq5
// Tis A Default Constructor
MyDateClass::MyDateClass(void)
{
  MqlDateTime mdt;
  datetime t=TimeCurrent(mdt);

  m_year=mdt.year;
  m_month=mdt.mon;
  m_day=mdt.day;
  m_hour=mdt.hour;
  m_minute=mdt.min;
  m_second=mdt.sec;
  Print(__FUNCTION__);
}
```
---
**```TimeCurrent()```**: the last known server time
```mq5
// call with no parameter
datetime  TimeCurrent();

// call with MqlDateTime parameter
datetime  TimeCurrent( 
   MqlDateTime&  dt_struct      // structure type variable 
   );
```
---
**```TimeToString()```**
* [Output] Time in seconds from 00:00 1970/01/01.
* mode=TIME_DATE|TIME_MINUTES
  + Additional data input mode. Can be one or combined flag: 
  + TIME_DATE gets result as "yyyy.mm.dd", 
  + TIME_MINUTES gets result as "hh:mi", 
  + TIME_SECONDS gets results as "hh:mi:ss".
```mq5
string  TimeToString( 
   datetime  value,                           // number 
   int       mode=TIME_DATE|TIME_MINUTES      // output format 
   );
```
