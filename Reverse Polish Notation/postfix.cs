using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class postfix
    {
        public string conversion(string infix)//geting the infix expression and returning the reverse polish notation/post fix expression
        {
            int c = 0;
            string rpn = "";//initaly string will empty
            int size = infix.Length, i = 0;//geting the length of the experasion(infix string) and i variable will be use for counting in while loop
            stack stk = new stack(size);//crating a stack according to the size of expression
            while (i < size)//this loop is used for examining the expression
            {
                char ch = infix[i];//geting a single character of the string for expresion
                //Console.WriteLine(ch);
                //return "a";
                if (ch == '(' || ch == '{' || ch == '[' || ch == ')' || ch == '}' || ch == ']')
                {
                    if (ch == '(' || ch == '{' || ch == '[')
                    {
                        c++;
                        stk.push(ch);
                    }
                    else if (ch == ')' || ch == '}' || ch == ']')
                    {
                        if (ch == ')')
                        {
                            while (true)
                            {
                                char sp = stk.pop();
                                if (sp == '(' || sp=='e')
                                    break;
                                rpn = rpn + "" + sp;
                            }
                        }
                        else if (ch == '}')
                        {
                            while (true)
                            {
                                char sp = stk.pop();
                                if (sp == 'e')
                                    break;
                                if (sp == '{')
                                    break;
                               rpn = rpn + "" + sp;
                            }
                        }
                        else
                        {
                            
                            while (true)
                            {
                                char sp = stk.pop();
                                if (sp == '[' || sp=='e')
                                    break;
                                //Console.WriteLine(sp);
                                rpn = rpn + "" + sp;
                                sp = stk.pop();
                            }
                        }
                    }
                    
                }
                else if (ch == '#')
                {
                    rpn = rpn + "" + ch;
                    rpn = rpn + "" + infix[++i];
                   
                }
                else if (ch >= '0' && ch <= '9')//for operand
                {
                    rpn = rpn + "" + ch;//appending operand with the string
                    
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')//for operator examining
                {
                    while (true)//make it infinite because dont know the operator precedence
                    {
                        char sp = stk.pop();//geting the latest store operand in the que for checking the operator precedence and type(+,-,*or/ )
                        if (ch == '+' || ch == '-')//actions related to plus and minus operator 
                        {
                            if (sp == 'e' || sp == '(' || sp == '{' || sp == '[')//if the que will empty
                            {
                                if (sp == '(' || sp == '{' || sp == '[')
                                {
                                    stk.push(sp);
                                }
                                stk.push(ch);//pushing the latest read operator in the expression
                                break;//breaking the infinite loop for geting the next operator in the expression
                            }
                            else if (sp == '/' || sp == '*')//for equal precedence
                            {
                                rpn = rpn + "" + sp;//When same precedence then solve from left to right
                                stk.push(ch);//now pushing the latest same presendece operator
                                break;//after it will break obviously before it lies a low precedence
                            }
                            else if (sp == '+' || sp == '-')//for low precedence
                            {
                                //stk.push(sp);//because it will not append with post fix string this time and its presedence is less so again push in stack
                                rpn = rpn + "" + sp;
                                stk.push(ch);//pushing high precedecne operator
                                break;//after it will break obviously before it lies a low precedence
                            }
                            else //appending with array because these operator have high precedence then the latest(ch) operator 
                                rpn = rpn + "" + sp;//appending with string
                            //rpn = rpn + "" + sp;//appending the operator with the post fix string
                        }
                        else if (ch == '*' || ch == '/')//for division and multiplication
                        {
                            if (sp == 'e' || sp == '(' || sp=='{' || sp=='[')//when stack will empty means this operator will perform after the first save operator
                            {
                                if (sp == '(' || sp == '{' || sp == '[')
                                    stk.push(sp);
                                stk.push(ch);//push that operator
                                break;//obviously for next operator and stack is now waiting for next opertaor
                            }
                            else if (sp == '/' || sp == '*')//for equal precedence
                            {
                                rpn = rpn + "" + sp;//When same precedence then solve from left to right
                                stk.push(ch);//now pushing the latest same presendece operator
                                break;//after it will break obviously before it lies a low precedence
                            }
                            else if (sp == '+' || sp == '-')//for low precedence
                            {
                                stk.push(sp);//because it will not append with post fix string this time and its presedence is less so again push in stack
                                stk.push(ch);//pushing high precedecne operator
                                break;//after it will break obviously before it lies a low precedence
                            }
                            else //appending with array because these operator have high precedence then the latest(ch) operator 
                                rpn = rpn + "" + sp;//appending with string
                        }
                    }
                }
                i++;//incrementing for next character in the string and termenating the loop
              
            }
           while (true)//for appending the remaining operator in the que it is infinite because dont know the number of the remaining operator in the que
            {
                char sp = stk.pop();//get the remaining operator from the que
                if (sp == 'e')//checking the que for empty
                    break;//terminating the loop because now que is empty
                if ( sp == '[')
                    Console.WriteLine("Rwanda");
                rpn = rpn + "" + sp;//appending the operators with the post fix expression
            }
           return rpn;//returnin the reverse polish notation or post fix expression
        }

    }
}
