using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Reverse_Polish_Notation
{
    class twoaddress
    {
        public void evaluate(string postexp, string infix)
        {
            FileStream aFile = new FileStream("C:/Output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(aFile);
            byte[] chr = new byte[100];
            int i = 0, size = postexp.Length;
            intstack stk = new intstack(size);
            while (i < size)
            {
                char ch = postexp[i];
                if (ch == '#')
                {
                    double operand = Convert.ToInt32(postexp[++i]) - 48;
                    stk.push(-1 * operand);
                }
                else if (ch >= '0' && ch <= '9')
                {
                    double operand = Convert.ToInt32(ch) - 48;
                    stk.push(operand);
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    double op1 = stk.pop();
                    double op2 = stk.pop();
                    if (ch == '+')
                    {
                        sw.WriteLine("MOV {0},{1}", "reg", op2);
                        double reg = op2;
                        sw.WriteLine("ADD {0},{1}", "reg", op1);
                        reg += op1;
                        stk.push(reg);
                    }
                    else if (ch == '-')
                    {
                        sw.WriteLine("MOV {0},{1}", "reg", op2);
                        double reg = op2;
                        sw.WriteLine("SUB {0},{1}", "reg", op1);
                        reg -= op1;
                        stk.push(reg);
                    }
                    else if (ch == '*')
                    {
                        sw.WriteLine("MOV {0},{1}", "reg", op2);
                        double reg = op2;
                        sw.WriteLine("MUL {0},{1}", "reg", op1);
                        reg *= op1;
                        stk.push(reg);
                    }
                    else if (ch == '/')
                    {
                        sw.WriteLine("MOV {0},{1}", "reg", op2);
                        double reg = op2;
                        sw.WriteLine("DIV {0},{1}", "reg", op1);
                        reg /= op1;
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
