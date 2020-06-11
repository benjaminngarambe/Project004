using System;
using System.Collections.Generic;
using System.Text;
using System.IO;//for file handling

namespace Reverse_Polish_Notation
{
    class zeroadd
    {
        //taking postfix expression into postexp and infix in infix(infix will take just for store in the output)
        public void evaluate(string postexp, string infix)
        {
            FileStream aFile = new FileStream("C:/Output.txt", FileMode.Create , FileAccess.Write);
            StreamWriter sw = new StreamWriter(aFile);
            sw.WriteLine("\t\tAllmighty increase my knowlege");
            sw.WriteLine("\tSharing Knowledge is wisdom & hiding knowledge is curse\n");
            sw.WriteLine("\t\tExpression:\t{0}", infix);
            int i = 0, size = postexp.Length;//size have the length of the postfix expression and i variable will count it
            intstack stk = new intstack(size);//creating the stack for storing the operand after conversion into integer from character
            while (i < size)//read untill the expression will end
            {
                char ch = postexp[i];//geting the character of the expression
                if (ch == '#')//for minus operand
                {
                    double operand = Convert.ToInt32(postexp[++i]) - 48;//subtract 48 for converting the character into the integer
                    stk.push(-1 * operand);
                }
                else if (ch >= '0' && ch <= '9')//checking for the operand
                {
                    double operand = Convert.ToInt32(ch) - 48;
                    sw.WriteLine("PUSH {0}", operand);
                    stk.push(operand);
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')//checking for the operator
                {
                    double op1 = stk.pop();
                    double op2 = stk.pop();
                    if (ch == '+')
                    {
                        sw.WriteLine("ADD");
                        double reg = op2 + op1;
                        stk.push(reg);
                    }
                    else if (ch == '-')
                    {
                        sw.WriteLine("SUB");
                        double reg = op2 - op1;
                        stk.push(reg);
                    }
                    else if (ch == '*')
                    {
                        sw.WriteLine("MUL");
                        double reg = op2 * op1;
                        stk.push(reg);
                    }
                    else if (ch == '/')
                    {
                        sw.WriteLine("DIV");
                        double reg = op2 / op1;
                        stk.push(reg);
                    }
                }
                i++;//incrementing for reading the next character in the postfix string and termenating the loop
            }
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.WriteLine("\t\t\tPOP  Result:\t{0}", stk.pop());
            sw.WriteLine("\n\n\t\tPrepeared By:\n\t\t\t\tBenjamin Ngarambe"); 
            sw.Close();//closing the file
       }
    }
}
