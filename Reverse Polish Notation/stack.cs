using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class stack
    {
        char[] stkarray;
        int top;
        public stack(int length)
        {
            top = -1;
            stkarray = new char[length];
            
        }
        bool IsFull()
        {
            if (top == stkarray.Length - 1)
            {
                return true;
            }
            else
                return false;
        }
        bool IsEmpty()
        {
            if (top == -1)
                return true;
            else
                return false;
        }
        public void push(char x)
        {
            if (IsFull())
                throw new Exception("Stack is Full");
            else
            {
                
                top++;
                stkarray[top] = x;
               
            }
        }
        public char pop()
        {
            if (IsEmpty())
                return 'e';
            //throw new Exception("Stack is Empty");
            else
            {
                char x = stkarray[top];
                top--;
                return x;
            }
        }
    }
}
