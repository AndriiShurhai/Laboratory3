using System.Security.Cryptography.X509Certificates;
using System;
using OutPutArrays;
namespace Block3_Karina
{
    public class Block3Karina
    {
        public static int[][] Start(int[][] array)
        {
            JaggedOutPut.OutPutArray(array);
            Console.WriteLine();
            Console.WriteLine("Enter two numbers on different lines");
            int K1 = Convert.ToInt32(Console.ReadLine()) - 1;
            int K2 = Convert.ToInt32(Console.ReadLine()) - 1;
            if (K1 > K2)
            {
                int temp = K1;
                K1 = K2;
                K2 = temp;
            }
            if (K1 < 0 || K2 >= array.Length)
            {
                Console.WriteLine("Index was outside the bounds of the array.");
                return array;
            }
            Console.WriteLine("Який спосіб? 1-вручну, 2-List");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    array = ArrayWithoutRows(array, K1, K2);
                    break;
                case 2:
                    List<List<int>> list = ListWithoutRows(array, K1, K2);
                    array = list.Select(x => x.ToArray()).ToArray();
                    break;
            }
            JaggedOutPut.OutPutArray(array);
            return array;
        }
        public static List<List<int>> ArrayToAList(int[][] array)
        {
            return array.Select(x => x.ToList()).ToList();
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

        public static List<List<int>> ListWithoutRows(int[][] array, int K1, int K2)
        {
            List<List<int>> list = new();
            list = ArrayToAList(array);
            list.RemoveRange(K1, K2 - K1 + 1);
            return list;
        }
    }
}