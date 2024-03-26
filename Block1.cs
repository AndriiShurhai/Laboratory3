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

            SimpleOutPut.OutputArray(inputArray);
            Console.WriteLine();
            SimpleOutPut.OutputArray(resultArray);

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

            for (int i = keyIndex + 1; i < size; i++)
            {
                array[i - 1] = array[i];

            }

            Array.Resize(ref array, size-1);

            return array;
        }
    }
}