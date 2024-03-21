using System;
using System.Diagnostics.CodeAnalysis;


namespace Block1
{
    public class Execute_Block1
    {
        public static void Do()
        {
            int[] inputArray = GetInputArray();
            int key = GetUsersKey();

            EliminateKey(inputArray, key);
        }

        static int[] GetInputArray()
        {
            Console.Write("Enter an array: ");
            string[] data = Console.ReadLine().Trim().Split();
            int[] array = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                array[i] = int.Parse(data[i]);
            }

            return array;
        }

        static int GetUsersKey()
        {
            int key;

            Console.Write("Enter a key: ");
            while (!(int.TryParse(Console.ReadLine(), out key)))
            {
                Console.WriteLine("Error, that is not integer. Try again");
            }

            return key;
        }

        static void DisplayArray(int[] array)
        {
            Console.Write("Array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        static void EliminateKey(int[] array, int key)
        {
            int keyIndex = -1;
            int size = array.Length;
            int[] resultArray = new int[size - 1];

            for (int i = 0; i < size; i++)
            {
                if (array[i] == key)
                {
                    keyIndex = i;
                    break;
                }
            }

            if (keyIndex == -1)
            {
                Console.WriteLine("No such key in array");
                return;
            }

            for (int i = keyIndex; i > 0; i--)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }

            for (int i = 1; i < size; i++)
            {
                resultArray[i - 1] = array[i];
            }
            DisplayArray(resultArray);
        }
    }
}