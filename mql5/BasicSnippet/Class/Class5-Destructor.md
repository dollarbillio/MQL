**Destructor**
* A destructor is a special function that is called automatically when a class object is destroyed. 
The name of the destructor is written as a class name with a tilde (~). 
Strings, dynamic arrays and objects, requiring deinitialization, will be de-initialized anyway, 
regardless of the destructor presence or absence. If there is a destructor, these actions will be performed after calling the destructor.
* Destructors are always virtual, regardless of whether they are declared with the virtual keyword or not
