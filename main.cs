using System;
using Block1;
using Block3;
using InputArrays;
using Block1Nazariy;
using Block3Nazariy;
using Block1_Karina;


namespace Lab
{
    class Task
    {
        static void Main(string[] args) {
            Executing();
        }

        static void Executing()
        {
            string student;
            int block;
            int[] array;
            int[][] jaggedArray;
            int[] prevResArray = null;
            int[][] prevJaggedArray = null;
            do
            {
                Console.WriteLine("\nGenerating Common Array:");
                array = InputArrays.SimpleInput.ExecuteInput(prevResArray);
                prevResArray = prevResArray == null ? array : prevResArray;

                Console.WriteLine("\nGenerating Jagged Array: ");
                jaggedArray = InputArrays.JuggedInput.ExecuteInput(prevJaggedArray);
                prevJaggedArray = prevJaggedArray == null ? jaggedArray : prevJaggedArray;

                Console.WriteLine("\nChoose student:\nNazar\nKarina\nAndrii");
                student = Console.ReadLine();

                switch (student)
                {
                    case "Nazar":
                        Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
                        block = int.Parse(Console.ReadLine());
                        switch (block)
                        {
                            case 1:
                                Console.WriteLine("1");
                                prevResArray = Block1N.Start(array);
                                break;
                            case 2:
                                Console.WriteLine("3");
                                break;
                            case 0:
                                Console.WriteLine("Returning back");
                                break;
                        }
                        break;

                    case "Karina":
                        Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
                        block = int.Parse(Console.ReadLine());
                        switch (block)
                        {
                            case 1:
                                Console.WriteLine("1");
                                prevResArray=Block1Karina.Start(array);
                                break;
                            case 2:
                                Console.WriteLine("2");
                                break;
                            case 0:
                                Console.WriteLine("Returning back");
                                break;
                        }
                        break;

                    case "Andrii":
                        Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
                        block = int.Parse(Console.ReadLine());
                        switch (block)
                        {
                            case 1:
                                prevResArray = Execute_Block1.Do(array);
                                break;
                            case 2:
                                prevJaggedArray = Execute_Block3.Do(jaggedArray);
                                break;
                            case 0:
                                Console.WriteLine("Returning back");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown data. Let's start from beginning.");
                        break;
                }
            } while (student != "");
        }
    }
}
