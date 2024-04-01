﻿using System.Runtime.InteropServices;
using System;
namespace Block3Nazariy
{
    class Program
    {
        // question: 38 рядок, чи можна так зробить?
        public static void Do()
        {
            int[][] array = InputArray();
            array = Block3_V12(array);
            ShowArray(array);
        }
        public static void ShowArray(int[][] array)
        {
            Console.WriteLine("Your array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
            Console.WriteLine();
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
        public static int[][] InputArray()
        {
            Console.WriteLine("Input amount of subarrays in array: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[N][];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Input elements of {i + 1} subarray");
                array[i] = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), Convert.ToInt32);
            }
            return array;
        }
        /*public static List<int> Block3_V12List()*/
    }
}