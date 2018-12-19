* Modifier 'final'
The use of the 'final' modifier during structure declaration prohibits further inheritance from this
structure. If a structure requires no further modifications, or modifications are not allowed for
security reasons, declare this structure with the 'final' modifier. In addition, all the members of the
structure will also be implicitly considered final.

* The code below shows error as nothing can inherit from ```settings``` 
```mq5
struct settings final
{
//--- Structure body
};
struct trade_settings : public settings
{
//--- Structure body
};
```
