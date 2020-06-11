using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Reverse_Polish_Notation
{
    class oneadd
    {
    //this function will take the postfix expression then solve that expression according to the one address mode
        public void evaluate(string postexp, string infix)
        {
            FileStream aFile = new FileStream("C:/Output.txt", FileMode.Create, FileAccess.Write);//It is open in create mode because if there is any file by the name of output is already (in case of second expevaluation)remove that file first
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine("\t\tAllmighty increase my knowlege");//just for pray
            sw.WriteLine("\tSharing Knowledge is wisdom & hiding knowledge is curse\n");//for sperating the message in the world
            sw.WriteLine("\t\tExpression:\t{0}", infix);
            byte[] chr = new byte[100];
            int i = 0, size = postexp.Length;
            intstack stk = new intstack(size);
            while (i < size)
            {
                char ch = postexp[i];
                if (ch == '#')//for negative sign
                {
                    double operand = Convert.ToInt32(postexp[++i]) - 48;
                    stk.push(-1 * operand);
                }
                else if (ch >= '0' && ch <= '9')//for converting into the digit from character
                {
                    double operand = Convert.ToInt32(ch) - 48;
                    stk.push(operand);
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')//for operators
                {
                    double op1 = stk.pop();
                    double op2 = stk.pop();
                    if (ch == '+')
                    {
                        sw.WriteLine("LOAD {0}", op2);
                        double reg = op2;
                        sw.WriteLine("ADD {0}", op1);
                        reg += op1;
                        sw.WriteLine("STOR {0}", "stack");
                        stk.push(reg);
                    }
                    else if (ch == '-')
                    {
                        sw.WriteLine("LOAD {0}", op2);
                        double reg = op2;
                        sw.WriteLine("SUB {0}", op1);
                        reg -= op1;
                        sw.WriteLine("STOR {0}", "stack");
                        stk.push(reg);
                    }
                    else if (ch == '*')
                    {
                        sw.WriteLine("LOAD {0}", op2);
                        double reg = op2;
                        sw.WriteLine("MUL {0}", op1);
                        reg *= op1;
                        sw.WriteLine("STOR {0}", "stack");
                        stk.push(reg);
                    }
                    else if (ch == '/')
                    {
                        sw.WriteLine("LOAD {0}", op2);
                        double reg = op2;
                        sw.WriteLine("DIV {0}", op1);
                        reg /= op1;
                        sw.WriteLine("STOR {0}", "stack");
                        stk.push(reg);
                    }
                }
                i++;
            }
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.WriteLine("\t\t\tMOV  Result:\t{0}", stk.pop());
            sw.WriteLine("\n\n\t\tPrepeared By:\n\t\t\t\tBenjamin Ngarambe"); 
            sw.Close();
        }
    }
}
