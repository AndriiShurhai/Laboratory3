using System;
using Block1;
using Block3;
using InputArrays;
using Block1Nazariy;
using Block3Nazariy;
using Block1_Karina;
using Block3_Karina;
using OutPutArrays;
using System.Threading.Channels;

namespace Lab
{
    class Task
    {
        static void Main()
        {
            Executing();
        }

        static void Executing()
        {
            int[] prevResArray = null;
            int[][] prevJaggedArray = null;

            while (true)
            {
                string[] students = { "Nazar", "Karina", "Andrii" };
                string student = SelectStudent();

                if (students.Contains(student))
                {
                    byte block = SelectBlock();

                    if (block == 0)
                    {
                        Console.WriteLine("Returning back.");
                    }

                    prevResArray = block == 1 ? ExecuteBlock1(student, prevResArray) : prevResArray;
                    prevJaggedArray = block == 2 ? ExecuteBlock3(student, prevJaggedArray) : prevJaggedArray;
                }
                else
                {
                    Console.WriteLine("Unknown student.");
                }
                CheckCurrentArray(prevResArray, prevJaggedArray);
            }
        }

        static void CheckCurrentArray(int[] array, int[][] jaggedArray)
        {
            string choice;
            Console.WriteLine("Display current condition of arrays?\nyes/no");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "yes":

                    Console.WriteLine("Current condition of simple array:");
                    if (array == null)
                    {
                        Console.WriteLine("Array is not created yet.");
                    }
                    else
                    {
                        SimpleOutPut.OutputArray(array);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Current condition of jagged array:");
                    if (jaggedArray == null)
                    {
                        Console.WriteLine("Array is not created yet.");
                    }
                    else
                    {
                        JaggedOutPut.OutPutArray(jaggedArray);
                    }

                    break;
                case "no":
                    Console.WriteLine("Okay");
                    break;
                default:
                    Console.WriteLine("Learn how to type and try next time buddy.");
                    break;
            }
        }

        static string SelectStudent()
        {
            Console.WriteLine("\nChoose student:\nNazar\nKarina\nAndrii");
            return Console.ReadLine();
        }

        static byte SelectBlock()
        {
            Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
            byte block;
            while (!byte.TryParse(Console.ReadLine(), out block) && block < 0 && block > 2)
            {
                Console.WriteLine("Error, invalid input. Please try again.");
            }
            return block;
        }

        static int[] ExecuteBlock1(string student, int[] prevResArray)
        {
            switch (student)
            {
                case "Nazar":
                    return Block1N.Run(SimpleInput.ExecuteInput(prevResArray));
                case "Karina":
                    return Block1Karina.Start(SimpleInput.ExecuteInput(prevResArray));
                case "Andrii":
                    return Execute_Block1.Do(SimpleInput.ExecuteInput(prevResArray));
                default:
                    return prevResArray;
            }
        }

        static int[][] ExecuteBlock3(string student, int[][] prevJaggedArray)
        {
            switch (student)
            {
                case "Nazar":
                    return Block3N.Run(InputArrays.JaggedInput.ExecuteInput(prevJaggedArray));
                case "Karina":
                    return Block3Karina.Start(InputArrays.JaggedInput.ExecuteInput(prevJaggedArray));
                case "Andrii":
                    return Execute_Block3.Do(InputArrays.JaggedInput.ExecuteInput(prevJaggedArray));
                default:
                    return prevJaggedArray;
            }
        }
    }
}
