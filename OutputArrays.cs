using System;

namespace OutPutArrays {
    class SimpleOutPut
    {
        public static void OutputArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
    class JaggedOutPut
    {
        public static void OutPutArray(int[][] array)
        {
            foreach (int[] arr in array)
            {
                SimpleOutPut.OutputArray(arr);
            }
        }
    }
}
