### * How to create ClassMethod
---
```cpp
// +---------------+
// | The main class
// +---------------+
class CTetrisShape 
  { 
protected: 
   int               m_type; 
   int               m_xpos; 
   int               m_ypos; 
   int               m_xsize; 
   int               m_ysize; 
   int               m_prev_turn; 
   int               m_turn; 
   int               m_right_border; 
public: 
   void              CTetrisShape(); 
   void              SetRightBorder(int border) { m_right_border=border; } 
   void              SetYPos(int ypos)          { m_ypos=ypos;           } 
   void              SetXPos(int xpos)          { m_xpos=xpos;           } 
   int               GetYPos()                  { return(m_ypos);        } 
   int               GetXPos()                  { return(m_xpos);        } 
   int               GetYSize()                 { return(m_ysize);       } 
   int               GetXSize()                 { return(m_xsize);       } 
   int               GetType()                  { return(m_type);        } 
   void              Left()                     { m_xpos-=SHAPE_SIZE;    } 
   void              Right()                    { m_xpos+=SHAPE_SIZE;    } 
   void              Rotate()                   { m_prev_turn=m_turn; if(++m_turn>3) m_turn=0; } 
   virtual void      Draw()                     { return;                } 
   virtual bool      CheckDown(int& pad_array[]); 
   virtual bool      CheckLeft(int& side_row[]); 
   virtual bool      CheckRight(int& side_row[]); 
  }; 

//+------------------------------------------------------------------+ 
//| Constructor of the basic class                                   | 
//+------------------------------------------------------------------+ 
void CTetrisShape::CTetrisShape() 
{ 
   m_type=0; 
   m_ypos=0; 
   m_xpos=0; 
   m_xsize=SHAPE_SIZE; 
   m_ysize=SHAPE_SIZE; 
   m_prev_turn=0; 
   m_turn=0; 
   m_right_border=0; 
} 
//+------------------------------------------------------------------+ 
//| Checking ability to move down (for the stick and cube)           | 
//+------------------------------------------------------------------+ 
bool CTetrisShape::CheckDown(int& pad_array[]) 
{ 
  // declare i and xsize and set it to m_xsize/SHAPE_SIZE; 
  int i,xsize=m_xsize/SHAPE_SIZE; 
  //--- 
  for(i=0; i<xsize; i++) 
  { 
    if(m_ypos + m_ysize >= pad_array[i]) return(false); 
  } 
  //--- 
  return(true); 
}
```
