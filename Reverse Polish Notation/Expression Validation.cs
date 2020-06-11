using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class Expression_Validation
    {
        public bool expval(string infix)
        {
            int opert = 0, opere = 0;//for counting operator and operand
            int i = 0, size = infix.Length;//for while loop
            while (i < size)
            {
                char ch = infix[i];
                if (ch == '#')
                {
                    if (i + 1 == size)
                        throw new Exception("You can not decleare here minus sign with operand");
                    if (infix[i + 1] < '0' || infix[i + 1] > '9')
                        throw new Exception("This is not suited for minus operand");
                    opere += 1;
                    i++;
                }
                else if (ch >= '0' && ch <= '9')
                    opere += 1;
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                    opert += 1;
                i++;
            }
            if (opert == opere - 1)
                return true;
            throw new Exception("There is not a no of operator or operand equal to the role");
        }
    }
}
