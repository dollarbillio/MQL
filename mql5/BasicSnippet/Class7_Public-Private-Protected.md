* When developing a new class, it is recommended to restrict access to the members from the outside -> ```private``` or ```protected``` are used. 
* If ```private``` is used, hidden data can be accessed only from function-methods of the **```same class```**. 
* If ```protected``` is used, hidden data can be accessed also from methods of classes - inheritors of this class. 
* ```public``` completely open access to members and/or methods of a class
---
---
```cpp
// +------------------+
// | Main Classs
// +------------------+
class CTetrisField 
{ 
private: 
   int               m_score;                            // Score 
   int               m_ypos;                             // Current position of the figures 
   int               m_field[FIELD_HEIGHT][FIELD_WIDTH]; // Matrix of the well 
   int               m_rows[FIELD_HEIGHT];               // Numbering of the well rows 
   int               m_last_row;                         // Last free row 
   CTetrisShape     *m_shape;                            // Tetris figure 
   bool              m_bover;                            // Game over 
public: 
   void              CTetrisField() { m_shape=NULL; m_bover=false; } 
   void              Init(); 
   void              Deinit(); 
   void              Down(); 
   void              Left(); 
   void              Right(); 
   void              Rotate(); 
   void              Drop(); 
// these 
private: 
   void              NewShape(); 
   void              CheckAndDeleteRows(); 
   void              LabelOver(); 
};
```
