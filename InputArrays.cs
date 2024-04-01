using System;
namespace InputArrays
{
    class SimpleInput
    {
        public static int[] ExecuteInput(int[] array = null)
        {
            bool wrongChoice;
            do
            {
                wrongChoice = false;
                Console.WriteLine("How do you want to generate array? With random numbers, manually on different lines, manually in one line or use previous result as an input?(random/modl/miol/prev): ");
                String choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "random":
                        array = RandomArray();
                        break;
                    case "modl":
                        array = ManualArray();
                        break;
                    case "miol":
                        array = ManualArrayLine();
                        break;
                    case "prev":
                        if (array != null)
                        {
                            Console.WriteLine("We gonna use previous array as an input");
                        }
                        else
                        {
                            Console.WriteLine("There is no any previous array yet, try something else");
                            wrongChoice = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong choice, select random, modl or miol");
                        wrongChoice = true;
                        break;
                }
            } while (array == null || wrongChoice);

            return array;
        }

        public static int[] RandomArray()
        {
            int[] array;
            bool validInput = true;
            int n;
            do
            {
                Console.WriteLine("Type amount of elements: ");
                validInput = int.TryParse(Console.ReadLine(), out n);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
            } while (!validInput || n == 0);
            array = new int[n];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-101, 101);
            }
            return array;
        }

        public static int[] ManualArray()
        {
            int[] array;
            bool validInput = true;
            int n;
            do
            {
                Console.WriteLine("Type amount of elements: ");
                validInput = int.TryParse(Console.ReadLine(), out n);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
            } while (!validInput);

            array = new int[n];

            do
            {
                Console.WriteLine("Input elements: ");
                for (int i = 0; i < n; i++)
                {
                    validInput = int.TryParse(Console.ReadLine(), out array[i]);
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        break;
                    }
                }
            } while (!validInput || array.Length == 0);
            return array;
        }

        public static int[] ManualArrayLine()
        {
            int[] array;
            bool validInput = true; 
            do
            {
                Console.WriteLine("Type elements: ");
                string[] sArray = Console.ReadLine().Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                array = new int[sArray.Length];
                for (int i = 0; i < sArray.Length; i++)
                {
                    validInput = int.TryParse(sArray[i], out array[i]);
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid input. Please enter valid integers separated by spaces.");
                        break;
                    }
                }
            } while (!validInput || array.Length == 0);

            return array;
        }
    }

    class JaggedInput
    {
        public static int[][] ExecuteInput(int[][] array = null)
        {
            bool wrongChoice;
            do
            {
                wrongChoice = false;
                Console.WriteLine("How do you want to generate array? With random numbers, manually or use previous result as an input?(random/manual/prev)");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "random":
                        array = RandomJaggedArray();
                        break;
                    case "manual":
                        array = ManualJaggedArray();
                        break;
                    case "prev":
                        if (array != null)
                        {
                            Console.WriteLine("We gonna use previous array as an input");
                        }
                        else
                        {
                            Console.WriteLine("There is no any previous array yet, try something else.");
                            wrongChoice = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown information");
                        wrongChoice = true;
                        break;
                }
            } while (array == null || wrongChoice);

            return array;
        }

        public static int[][] RandomJaggedArray()
        {
            int[][] jaggedArray;
            bool validInput = true;
            int rows;
            do
            {
                Console.Write("Enter amount of rows:");
                validInput = int.TryParse(Console.ReadLine(), out rows);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
            } while (!validInput || rows == 0);

            jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = SimpleInput.RandomArray();
            }

            return jaggedArray;
        }

        public static int[][] ManualJaggedArray()
        {
            int[][] jaggedArray;
            bool validInput = true;
            int rows;
            do
            {
                Console.WriteLine("Enter amount of rows");
                validInput = int.TryParse(Console.ReadLine(), out rows);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
            } while (!validInput || rows == 0);
            jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = SimpleInput.ManualArrayLine();
            }

            return jaggedArray;
        }
    }
}
