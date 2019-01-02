http://www.cplusplus.com/reference/string/string/
---
* Create new string
```cpp
#include <string>

int main
{
  std::string name = "Cherno"
  // string concatenation
  std::string name = std::string("Cherno") + " hello!";
}
```
* Remember to call reference when passing on ```string``` input if the function doesn't return anything otherwise it will create a copy and waste of memory
```cpp
void Print(std::string& string)
{
  string += 'L';
  std::cout << string <<std::endl;
}
```
