using System;
using System.Diagnostics.CodeAnalysis;
using OutPutArrays;


namespace Block1
{
    public class Execute_Block1
    {
        public static int[] Do(int[] inputArray)
        {
            int key = GetUsersKey();

            int[] resultArray = CreateArrayWithoutKey(inputArray, key);

            OutPut.OutputArray(resultArray);

            return resultArray;
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

        static int[] CreateArrayWithoutKey(int[] array, int key)
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
                return array;
            }

            for (int i = keyIndex; i > 0; i--)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }

            for (int i = 1; i < size; i++)
            {
                resultArray[i - 1] = array[i];
            }

            return resultArray;
        }
    }
}