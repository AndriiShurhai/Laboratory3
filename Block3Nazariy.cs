using System.Runtime.InteropServices;
using System;
using OutPutArrays;
namespace Block3Nazariy
{
    class Block3N
    {
        // question: 38 рядок, чи можна так зробить?
        public static int[][] Run(int[][] array)
        {
            JaggedOutPut.OutPutArray(array);
            array = Block3_V12(array);
            JaggedOutPut.OutPutArray(array);
            return array;
        }
        public static int[][] Block3_V12(int[][] array)
        {
            int max = int.MinValue;
            int maxIdx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Max() >= max)
                {
                    max = array[i].Max();
                    maxIdx = i;
                }
            }
            Console.WriteLine("Input array you want to insert: ");
            int[] insert = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), Convert.ToInt32);
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 2; i >= maxIdx; i--)
            {
                array[i + 1] = array[i];
            }
            // insert = 9;
            // 4 6 7 1 5 3 0 -> 4 6 7 1 5 0 3 -> 4 6 7 1 0 5 3 -> 4 6 7 0 1 5 3 -> 4 6 0 7 1 5 3;
            array[maxIdx] = insert;
            // 4 6 0 7 1 5 3 -> 4 6 9 7 1 5 3;
            return array;
        }
        /*public static List<int> Block3_V12List()*/
    }
}
