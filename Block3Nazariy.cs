using System.Runtime.InteropServices;
using System;
using OutPutArrays;
namespace Block3Nazariy
{
    class Block3N
    {
        public static int[][] Run(int[][] array)
        {
            JaggedOutPut.OutPutArray(array);
            Console.WriteLine("Choose a way 1 - normal, 2 - list");
            byte way = Convert.ToByte(Console.ReadLine());
            switch (way)
            {
                case 1:
                    array = Block3_V12(ref array);
                    break;
                case 2:
                    List<List<int>> list = array.Select(array => array.ToList()).ToList();
                    list = Block3_V12List(list);
                    array = list.Select(array => array.ToArray()).ToArray();
                    break;

            }
            JaggedOutPut.OutPutArray(array);
            return array;
        }
        public static int[][] Block3_V12(ref int[][] array)
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
            // 4    4    4    4    4
            // 6    6    6    6    6
            // 7    7    7    7    0
            // 1 -> 1 -> 1 -> 0 -> 7
            // 5    5    0    1    1
            // 3    0    5    5    5
            // 0    3    3    3    3
            array[maxIdx] = insert;
            // 4    4
            // 6    6
            // 0    9
            // 7 -> 7
            // 1    1
            // 5    5
            // 3    3
            return array;
        }
        public static List<List<int>> Block3_V12List(List<List<int>> list)
        {
            int max = int.MinValue;
            int maxIdx = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    if (list[i].Max() >= max)
                    {
                        max = list[i].Max();
                        maxIdx = i;
                    }
                }
            }
            Console.WriteLine("Input a list you want to insert: ");
            List<int> insert = (Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), Convert.ToInt32)).ToList();
            list.Insert(maxIdx, insert);
            return list;
        }
    }  
}
