* MqlDateTime
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
