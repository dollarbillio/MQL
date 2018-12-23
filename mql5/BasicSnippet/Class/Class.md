
```mq5
//+------------------------------------------------------------------+
//| Script program start function |
//+------------------------------------------------------------------+
void OnStart()
{
   class MyDateClass
   { 
      private:
         int m_year; 
         int m_month; 
         int m_day; 
         int m_hour; 
         int m_minute; 
         int m_second;
      public:
      //--- Default constructor
         MyDateClass(void); //--- Parametric constructor
      //--- Parametric constructor
         MyDateClass(MyDateClass(int h,int m,int s);
   };
  
   //+------------------------------------------------------------------+ 
   //| Default constructor | 
   //+------------------------------------------------------------------+ 
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
   
   //+------------------------------------------------------------------+ 
   //| Parametric constructor | 
   //+------------------------------------------------------------------+ 
   MyDateClass::MyDateClass(int h,int m,int s)
   {
      MqlDateTime mdt;
      datetime t=TimeCurrent(mdt); 
      m_year=mdt.year; 
      m_month=mdt.mon; 
      m_day=mdt.day;
      m_hour=h;
      m_minute=m;
      m_second=s; 
      Print(__FUNCTION__);
   }
}
```
