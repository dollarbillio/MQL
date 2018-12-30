**Destructor**
* A destructor is a special function that, called automatically when a class object is destroyed. 
* ```~Destructor()```  
* Strings, dynamic arrays and objects, requiring deinitialization, will be de-initialized anyway, 
regardless of the destructor presence or absence. 
* If there is a ```~destructor()```,  it will be performed immediately after the function ends.
* Destructors are always ```virtual```, regardless of whether they are declared with the virtual keyword or not
