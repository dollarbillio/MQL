* The use of the 'final' modifier during class declaration prohibits further inheritance from this class. 
* If the class interface requires no further modifications, or modifications are not allowed for security reasons, 
declare this class with the 'final' modifier. In addition, all the members of the class will also be implicitly considered final.
---
---
```cpp
class CFoo final
  {
  //--- Class body
  };

// This will create error as CFoo can't be inherited
class CBar : public CFoo
  {
  //--- Class body
  };
```
