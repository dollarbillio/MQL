* An example showing how enums is integrated in Class
```cpp
#include <iostream>

class Log
{
public:
  enum Level
  {
    LevelError = 0, LevelWarning, LevelInfo
  };

private:
  // Set default Level 
  Level enum_MsgLogLevel = LevelInfo;

public:
  void SetLevel(Level level)
  {
    enum_MsgLogLevel = level;
  }
  
  void Error(const char* message)
  {
    if (enum_MsgLogLevel >= LevelError)
      std::cout<<"[ERROR]: " << message << std::endl;
  }
};

int main()
{
  Log log;
  // Take from class Log LevelError meaning that There can be only one LevelError in LogClass
  log.SetLevel(Log::LevelError); 
  std::cin.get();
}
```
