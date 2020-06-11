using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class intstack
    {
        double[] stkarray;
        int top;
        public intstack(int length)
        {
            top = -1;
            stkarray = new double[length];
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
        public void push(double x)
        {
            if (IsFull())
                throw new Exception("Stack is Full");
            else
            {
                top++;
                stkarray[top] = x;
            }
        }
        public double pop()
        {
            if (IsEmpty())
                return '0';
            //throw new Exception("Stack is Empty");
            else
            {
                double x = stkarray[top];
                top--;
                return x;
            }
        }
    }
}
