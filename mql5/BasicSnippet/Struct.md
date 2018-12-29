*  ```Struct``` could be similar to ```Class```
- By Default, things in ```Struct``` are public
- We should use ```struct``` when it represent **structure of data** and **methods** to manipulate those data
  - Could be Data grouped together because of similar characteristics

* In the code below,
  * ```Animal``` is the parent class, ```Dog``` and ```Cat``` are children of ```Animal```
  * ```anAnimal``` is an instance of ```Animal``` and can be ```Dog = anAnimal```
  * ```elephant``` is an instance of ```Animal``` and can be ```elephant = cat```
  * ```Dog``` and ```Cat``` are different Children => ```cat.head = dog.head```
```mq5
//+------------------------------------------------------------------+
//| Script program start function                                    |
//+------------------------------------------------------------------+
//--- basic structure for describing animals
struct Animal
{
   int               head; // number of heads
   int               legs; // number of legs
   int               wings; // number of wings
   bool              tail; // tail
   bool              fly; // flying
   bool              swim; // swimming
   bool              run; // running
};
//--- structure for describing dogs
struct Dog: Animal
{
   bool              hunting; // hunting breed
};
//--- structure for describing cats
struct Cat: Animal
{
   bool              home; // home breed
};
//+------------------------------------------------------------------+
//| Script program start function |
//+------------------------------------------------------------------+
void OnStart()
{
   //--- create and describe an object of the basic Animal type
   Animal anAnimal;
   anAnimal.head=1;
   anAnimal.legs=4;
   anAnimal.wings=0;
   anAnimal.tail=true;
   anAnimal.fly=false;
   anAnimal.swim=false;
   anAnimal.run=true;
   //--- create objects of child types
   Dog dog;
   Cat cat;
   //--- can be copied from ancestor to descendant (Animal ==> Dog)
   dog=anAnimal;
   dog.swim=true; // dogs can swim
   //--- you cannot copy objects of child structures (Dog != Cat)
   //cat=dog; // compiler returns an error here
   //--- therefore, it is possible to copy elements one by one only
   cat.head=dog.head;
   cat.legs=dog.legs;
   cat.wings=dog.wings;
   cat.tail=dog.tail;
   cat.fly=dog.fly;
   cat.swim=false; // cats cannot swim
   //--- it is possible to copy the values from descendant to ancestor
   Animal elephant;
   elephant=cat;
   elephant.run=false;// elephants cannot run
   elephant.swim=true;// elephants can swim
   //--- create an array
   Animal animals[4];
   animals[0]=anAnimal;
   animals[1]=dog;
   animals[2]=cat;
   animals[3]=elephant;
   //--- print out
   ArrayPrint(animals);
   //--- execution result
   /*
   [head] [legs] [wings] [tail] [fly] [swim] [run]
   [0] 1 4 0 true false false true
   [1] 1 4 0 true false true true
   [2] 1 4 0 true false false false
   [3] 1 4 0 true false true false
   */
}
//+------------------------------------------------------------------+
```
