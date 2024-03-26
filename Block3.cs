using System;
using InputArrays;
using OutPutArrays;

namespace Block3
{
    public class Execute_Block3
    {
        public static int[][] Do(int[][] inputArray)
        {
            int k = GetKNumber();
            JaggedOutPut.OutPutArray(inputArray);
            int[][] resultArray = AddKRows(k, inputArray);
            Console.WriteLine();
            JaggedOutPut.OutPutArray(resultArray);

            return resultArray;
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

        public static int[][] AddKRows(int k, int[][] array)
        {
            Array.Resize(ref array, array.Length + k);

            for (int i = array.Length - k; i < array.Length; i++)
            {
                int[] arr = SimpleInput.ManualArrayLine();
                array[i] = arr;
            }

            return array;
        }
    }
}