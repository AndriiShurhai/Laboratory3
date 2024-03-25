using System;
using Block1;
using InputArrays;
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
            int[] prevResArray = null;
            do
            {
                array = Input.ExecuteInput(prevResArray);
                Console.WriteLine("Choose student:\nNazar\nKarina\nAndrii\nNone - end program");
                student = Console.ReadLine();
                Console.WriteLine("Choose block:\n1 - First Block\n2 - Third Block\n0 - return back");
                block = int.Parse(Console.ReadLine());

                switch (student)
                {
                    case "Nazar":
                        switch (block)
                        {
                            case 1:
                                Console.WriteLine("1");
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
                        switch (block)
                        {
                            case 1:
                                Console.WriteLine("1");
                                break;
                            case 2:
                                Console.WriteLine("2");
                                break;
                            case 3:
                                Console.WriteLine("3");
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
                                Console.WriteLine("2");
                                break;
                            case 3:
                                Console.WriteLine("3");
                                break;
                        }
                        break;
                }
            } while (student != "None");
        }
    }
}
