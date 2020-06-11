using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Reverse_Polish_Notation
{
    #region using of the forground color with use built in functions
    class color//this function will perform the work for the forground colors without using the builtin function
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleTextAttribute(
            IntPtr hConsoleOutput,
            CharacterAttributes wAttributes); /* declaring the setconsoletextattribute function*/

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        /*declaring the getstdhandle funtion to get thehandle that would be used in setConsoletextattribute function */

        public void change(string v)
        {
            IntPtr hOut; /* declaring varianle to get handle*/
            hOut = GetStdHandle(-11);/* -11 is sent for output device*/


            /*Displaying text in different colors and background colors*/

            SetConsoleTextAttribute(hOut, CharacterAttributes.FOREGROUND_BLUE);
            Console.WriteLine(" \n\t\t{0} ", v);
        }

        public void Rchange(string v)
        {
            IntPtr hOut;
            hOut = GetStdHandle(-11);

            SetConsoleTextAttribute(hOut, CharacterAttributes.FOREGROUND_WHITE);
           // Console.WriteLine(" \t\t\n{0}", v);
        }
        /* This enumeration lists all of the character attributes. You can combine attributes to achieve specific effects.*/
        public enum CharacterAttributes
        {
            FOREGROUND_BLUE = 0x0009,
            FOREGROUND_GREEN = 0x0002,
            FOREGROUND_RED = 0x0004,
            FOREGROUND_WHITE = 0x0007,
            FOREGROUND_INTENSITY = 0x0006,
            BACKGROUND_BLUE = 0x0010,
            BACKGROUND_GREEN = 0x0020,
            BACKGROUND_RED = 0x0040,
            BACKGROUND_INTENSITY = 0x0080,
        }

    }
    #endregion
    class start
    {
        #region for checking the expresion validation is according to the predefined rules
        void check(string exp)
        {
            int i = 0, op = 0, oper = 0;
            while (i < exp.Length)
            {
                if (exp[i] >= '0' && exp[i] <= '9')
                { i++; op++; }
                else if (exp[i] == '+' || exp[i] == '-' || exp[i] == '*' || exp[i] == '/')
                { i++; oper++; }
                else if (exp[i] == '#' || exp[i] == '[' || exp[i] == '{' || exp[i] == '(' || exp[i] == ']' || exp[i] == '}' || exp[i] == ')')
                    i++;
                else
                    throw new ProgramException("you can enter only arithmetic expression with specified instruction");
            }
            if (op != oper + 1)
                throw new ProgramException("Invalid arithmetic expression");
        }
        #endregion
        #region for calling the appropriate function according to the addressing mode and for output purposes 
        //instadd varible is used for checking the instruction address
        public void ABBAS(string infix, int instadd)
        {
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            if(infix.Length ==2)
                throw new ProgramException("This infix expression does not fulfill the condition of required no of operators and operands");
            check(infix);
            Heterogeneous_Brackets_Validity obj1 = new Heterogeneous_Brackets_Validity();
            if (obj1.check(infix) == 0)//Checking the infix expression for hetrogeneous validity
             throw new ProgramException("This infix expression does not fulfill the condition of Hetrogeneous");
         postfix obj = new postfix();
         string poststr = obj.conversion(infix);//Converting the infix expression into postfix expression
         
         if (instadd == 0)
         {
             zeroadd obj2 = new zeroadd();
             obj2.evaluate(poststr, infix);
         }
         else if (instadd == 1)
         {
             oneadd obj2 = new oneadd();
             obj2.evaluate(poststr, infix);
             
         }
         else if (instadd == 2)
         {
             twoaddress obj2 = new twoaddress();
             obj2.evaluate(poststr, infix);
         }
         else if (instadd == 3)
         {
             ThreeAdd obj2 = new ThreeAdd();
             obj2.evaluate(poststr, infix);
         }
         else//if instruction address will greater than 3 or less than zero
             throw new ProgramException("\n\tThis address instruction is invalid\n\tThis exception is thrown from start class");
            string inst;//for printing the file reading
            FileStream aFile = new FileStream("C:/Output.txt", FileMode.Open);//opening the output file in open mode for read purpose
            StreamReader sr = new StreamReader(aFile);//for reading the file
            inst = sr.ReadLine();
            color cf = new color();
           cf.change("");
           Console.BackgroundColor = ConsoleColor.Magenta ;
            Console.Clear();
            while (inst != null)//for reading the whole file
            {
               Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[13]);
               for (int i = 0; i < inst.Length; i++)
               {
                   Console.Write(inst[i]);
                   Thread.Sleep(20);
               }
               Console.WriteLine();
                inst = sr.ReadLine();
            }
            cf.Rchange("");
            Console.BackgroundColor = ConsoleColor.Cyan;
            sr.Close();//closing the file after reading the whole file
        }
        #endregion
    }
}
