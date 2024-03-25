using System;

namespace OutPutArrays {
    class OutPut
    {
        public static void OutputArray(int[] array)
        {
            Console.Write("Your Array: ");
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
