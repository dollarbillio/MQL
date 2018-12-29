* ```Static variable``` in a function
* The example above say that ```int x``` can't be modifed outside the function  
```cpp
void Function()
{
  // static here says that int x is only initialized once = 0 and will be kept through out all ```function call```
  static int x = 0; 
  i++;
  std::cout << x << std::endl;
}

int main()
{
  Function(); // x = 1
  Function(); // x = 2
  Function(); // x = 3
  Function(); // x = 4
  
  std::cin::get();
}
```
