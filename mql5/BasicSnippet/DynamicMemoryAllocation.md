```cpp
Entity* e = new Entity();
```
* Initialize a pointer of type Entity
* Use the key word "new" to allocate memory for an entity object 
* Return the address of the first byte.
---
**Interpretation**
* ```Entity* e``` creates a pointer , ```new Entity()``` creates an object of type Entity using dynamic memory allocation.
* a ```* pointer``` to ```Entity``` that points to the **beginning** of **where** an Entity object ```e``` created is **stored in memory**. 
---
* Normally **initialize** <-  you give it a name (such as Entity* e where "e" is the name of the pointer variable) 
* Here **initialize** ```Entity``` <- **dynamic memory** that is **only accessible** through **a pointer** instead of being able to call it by **it's name**
---
* From ```pointer``` directly to ```Function()``` 
```cpp
std::cout << e->GetName() << std::endl;
```
