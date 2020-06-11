using System;
using System.Collections.Generic;
using System.Text;
using System.IO;//for reading and writing purposes on the files
using System.Threading;//For use makes a threads in the Software Introduction
#region Prepeared By Benjamin Ngarambe
namespace Reverse_Polish_Notation
{
   
    class Program
    {
        #region For Key Pressing
        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            // Announce that the event handler has been invoked.
            Console.WriteLine("\nThe read operation has been interrupted.");

            // Announce which key combination was pressed.
            Console.WriteLine("  Key pressed: {0}", args.SpecialKey);

            // Announce the initial value of the Cancel property.
            Console.WriteLine("  Cancel property: {0}", args.Cancel);

            // Set the Cancel property to true to prevent the process from terminating.
            Console.WriteLine("Setting the Cancel property to true...");
            args.Cancel = true;

            // Announce the new value of the Cancel property.
            Console.WriteLine("  Cancel property: {0}", args.Cancel);
            Console.WriteLine("The read operation will resume...\n");
        }
        #endregion
        static void Main(string[] args)
        {
            #   region for handeling of the key information and colors (back and for)
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));//for making the different forcolors
            ConsoleKeyInfo cki;//For checking the control information
            Console.TreatControlCAsInput = false;//Initially input
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);//For calling the key press event handeller
            Console.Clear();//removing the prevouis background color completely
            #endregion
            #region interface which will intract with the user
            while (true)//It will terminate when user want there fore we made it as a infinite loop
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[12]);//change for the forcolor for the input which is define by 12 which means red color
                while (true)
                {
                    // Prompt the user.
                    Console.Write("Press Esc key for exit & right arrow for continue:\t");
                    // Start a console read operation. Do not display the input.
                    cki = Console.ReadKey(true);
                    if (cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Escape)
                        // Announce the name of the key that was pressed .
                        Console.WriteLine(" \n Key pressed: {0}  which is worong\n", cki.Key);
                    else
                        Console.WriteLine(" \n Key pressed: {0}\n", cki.Key);

                    // Exit if the user pressed the 'X' key.
                    if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.Escape) break;
                }
                if (cki.Key == ConsoleKey.Escape)//if escape key press now user want to terminate the application so break the loop
                    break;
                Console.Clear();//if user not want to break then againg clear the whole output for further expressions
                Console.Write("Please Insert the Expression:\t");
                string input = Console.ReadLine();//taking the expression which will resolve
                Console.Write("Please Insert the Address Instruction Mode:\t");
                int addmode = Convert.ToInt32(Console.ReadLine());//taking the addressing mode
                start obj = new start();//creating the object for interacting with the internal process of the application
                obj.ABBAS(input, addmode);//calling the function whihc will perform the begining work towards the actual work
            #endregion
            }
        }
    }
}
#endregion
