using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class Heterogeneous_Brackets_Validity
    {
        public int check(string exp)
        {
            stack stk = new stack(exp.Length);
            int i = 0;
            while (i < exp.Length)
            {
                char ch = exp[i];
                if (ch == '(' || ch == '{' || ch == '[')
                    stk.push(ch);
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    char sp = stk.pop();
                    if (sp == 'e')
                        return 0;
                    else if (ch == ')' && sp == '(') { }
                    else if (ch == '}' && sp == '{') { }
                    else if (ch == ']' && sp == '[') { }
                    else return 0;
                }
                i++;
            }
            if(stk .pop ()=='e')
                return 1;
            else 
                return 0;
                
            }
        }
    }

