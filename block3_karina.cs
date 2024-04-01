using System.Security.Cryptography.X509Certificates;
using System;
using OutPutArrays;
namespace Block3_Karina
{
    public class Block3Karina
    {
        public static int[][] Start(int[][] array)
        {
            Console.WriteLine("Enter numbers");
            int K1 = Convert.ToInt32(Console.ReadLine()) - 1;
            int K2 = Convert.ToInt32(Console.ReadLine()) - 1;
            if (K1 > K2)
            {
                (K1, K2) = (K2, K1);
            }
            if (K1 < 0 || K2 >= array.Length)
            {
                Console.WriteLine("Index was outside the bounds of the array.");
                return array;
            }
            JaggedOutPut.OutPutArray(array);
            Console.WriteLine();
            JaggedOutPut.OutPutArray(ArrayWithoutRows(array, K1, K2));
            return ArrayWithoutRows(array, K1, K2);
        }
        
        public static int[][] ArrayWithoutRows(int[][] array, int K1, int K2)
        {
            int range = K2 - K1 + 1;
            int[][] erasedArr = new int[array.Length - range][];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= K1 && i <= K2)
                {
                    count++;
                    continue;
                }
                erasedArr[i - count] = array[i];
            }
            return erasedArr;
        }
       
    }

}
