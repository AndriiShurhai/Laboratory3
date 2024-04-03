using System;
using System.Collections.Generic;
using System.Linq;
using OutPutArrays;
using InputArrays;

namespace Block3
{
    public class Execute_Block3
    {
        public static int[][] Do(int[][] inputArray)
        {
            int[][] resultArray = null;
            int choice;

            Console.Write("Choose the way to execute:\n1 - Using Arrays\n2 - Using Lists\n0 - return back\n");
            while (!(int.TryParse(Console.ReadLine(), out choice)) || (choice < 0 || choice > 2))
            {
                Console.WriteLine("Error. Try again");
            }

            switch (choice)
            {
                case 1:
                    resultArray = DoWithArraysApproach(inputArray);
                    break;
                case 2:
                    resultArray = DoWithListsApproach(inputArray);
                    break;
                case 0:
                    Console.WriteLine("Returning back.");
                    break;
                default:
                    Console.WriteLine("Learn how to type buddy.");
                    break;
            }
            return resultArray;
        }

        public static int[][] DoWithArraysApproach(int[][] inputArray)
        {
            JaggedOutPut.OutPutArray(inputArray);
            int k = GetKNumber();
            int[][] resultArray = AddKRowsArray(k, inputArray);
            Console.WriteLine();
            JaggedOutPut.OutPutArray(resultArray);

            return resultArray;
        }

        public static int[][] DoWithListsApproach(int[][] input)
        {
            JaggedOutPut.OutPutArray(input);

            List<List<int>> inputList = ConvertToList(input);

            int k = GetKNumber();

            List<List<int>> result = AddKRowsList(k, inputList);

            OutputJaggedList(result);

            return ConvertToArray(result);
        }

        public static int GetKNumber()
        {
            int k;

            Console.Write("Enter k: ");
            while (!(int.TryParse(Console.ReadLine(), out k)))
            {
                Console.WriteLine("Error, that is not integer. Try again");
            }

            return k;
        }

        public static int[][] AddKRowsArray(int k, int[][] array)
        {
            Array.Resize(ref array, array.Length + k);

            for (int i = array.Length - k; i < array.Length; i++)
            {
                int[] arr = SimpleInput.ManualArrayLine();
                array[i] = arr;
            }

            return array;
        }

        public static List<List<int>> AddKRowsList(int k, List<List<int>> list)
        {
            for (int i = 0; i < k; i++)
            {
                List<int> l = SimpleInput.ManualArrayLine().ToList();
                list.Add(l);
            }

            return list;
        }

        public static List<List<int>> ConvertToList(int[][] input)
        {
            return input.Select(row => row.ToList()).ToList();
        }

        public static int[][] ConvertToArray(List<List<int>> input)
        {
            return input.Select(row => row.ToArray()).ToArray();
        }

        public static void OutputJaggedList(List<List<int>> jaggedList)
        {
            foreach (var innerList in jaggedList)
            {
                foreach (var item in innerList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
