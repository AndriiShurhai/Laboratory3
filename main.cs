using System;
using Block1;
using Block3;
using InputArrays;
using Block1Nazariy;
using Block3Nazariy;
using Block1_Karina;
using Block3_Karina;
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
            string student;
            int block;
            int[] array = null;
            int[][] jaggedArray = null;
            int[] prevResArray = null;
            int[][] prevJaggedArray = null;
            do
            {
                Console.WriteLine("\nChoose student:\nNazar\nKarina\nAndrii");
                student = Console.ReadLine();
                Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
                block = int.Parse(Console.ReadLine());
                if(block == 1)
                {
                    Console.WriteLine("\nGenerating Common Array:");
                    array = InputArrays.SimpleInput.ExecuteInput(prevResArray);
                    prevResArray = prevResArray == null ? array : prevResArray;
                }
                else if(block == 2)
                {
                    Console.WriteLine("\nGenerating Jagged Array: ");
                    jaggedArray = InputArrays.JaggedInput.ExecuteInput(prevJaggedArray);
                    prevJaggedArray = prevJaggedArray == null ? jaggedArray : prevJaggedArray;
                }
                switch (student)
                {
                    case "Nazar":
                        
                        switch (block)
                        {
                            case 1:
                                prevResArray = Block1N.Run(array);
                                break;
                            case 2:
                                prevJaggedArray = Block3N.Run(jaggedArray);
                                break;
                            case 0:
                                Console.WriteLine("Returning back");
                                break;
                        }
                        break;

                    case "Karina":
                        switch (block)
                        {
                            case 1:
                                prevResArray = Block1Karina.Start(array);
                                break;
                            case 2:
                                prevJaggedArray = Block3Karina.Start(jaggedArray);
                                break;
                            case 0:
                                Console.WriteLine("Returning back");
                                break;
                        }
                        break;

                    case "Andrii":
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
