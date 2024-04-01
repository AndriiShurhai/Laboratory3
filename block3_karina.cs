using System.Security.Cryptography.X509Certificates;

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
                Console.ReadKey();
                return array;
            }
            int range = K2 - K1 + 1;
            int[][] erasedArr = new int[array.Length - range][];
            Console.WriteLine("Enter subarrays");
            InputArr(array);
            erasedArr = EraseRows(array, erasedArr, K1, K2);
            Console.WriteLine("Your array:");
            ShowArray(erasedArr);
            Console.ReadKey();
            return array;
        }
        public static int[][] InputArr(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }
            return array;
        }
        public static int[][] EraseRows(int[][] array, int[][] erasedArr, int K1, int K2)
        {
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
        public static int[][] ShowArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {

                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }
            return array;
        }
    }

}
