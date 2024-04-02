using System;
using System.Diagnostics.CodeAnalysis;
using OutPutArrays;


namespace Block1
{
    public class Execute_Block1
    {
        public static int[] Do(int[] inputArray)
        {
            int[] resultArray = inputArray;
            int choice = -1;


            Console.WriteLine("Choose version to execute:\n1 - manual version\n2 - libraries version\n3 - lists version\n0 - return back");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    resultArray = DoWithManualApproach(inputArray);
                    break;
                case 2:
                    resultArray = DoWithLibrariesApproach(inputArray);
                    break;
                case 3:
                    resultArray = DoWithListsApproach(inputArray);
                    break;
                case 0:
                    Console.WriteLine("Returing back.");
                    break;
                default:
                    Console.WriteLine("Learn how to type dude.");
                    break;
            }
            return resultArray;
        }

        public static int[] DoWithManualApproach(int[] inputArray)
        {
            Console.WriteLine("Array working with: ");
            SimpleOutPut.OutputArray(inputArray);
            int key = GetUsersKey();
            CreateArrayWithoutKey(ref inputArray, key);
            Console.WriteLine();
            SimpleOutPut.OutputArray(inputArray);

            return inputArray;
        }

        public static int[] DoWithLibrariesApproach(int[] inputArray)
        {
            Console.WriteLine("Array working with: ");
            Console.WriteLine(String.Join(" ", inputArray));
            int key = GetUsersKey();
            int[] resultArray = CreateArrayWithoutKeyLibrary(inputArray, key);
            Console.WriteLine();
            Console.WriteLine(String.Join(" ", resultArray));

            return resultArray;
        }

        public static int[] DoWithListsApproach(int[] inputArray)
        {
            List<int> list = new List<int>(inputArray);
            Console.WriteLine("Array working with: ");
            Console.WriteLine(String.Join(" ", list));

            int key = GetUsersKey();
            List<int> result = CreateArrayWithoutKeyLists(list, key);

            Console.WriteLine();
            Console.WriteLine(String.Join(" ", result));

            return result.ToArray();
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

        static void CreateArrayWithoutKey(ref int[] array, int key)
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
                return;
            }

            for (int i = keyIndex + 1; i < size; i++)
            {
                array[i - 1] = array[i];

            }

            Array.Resize(ref array, size - 1);

        }

        static int[] CreateArrayWithoutKeyLibrary(int[] array, int key)
        {
            int keyIndex = Array.IndexOf(array, key);

            if (keyIndex == -1)
            {
                Console.WriteLine("No such key in array");
                return array;
            }

            int[] rArray = new int[array.Length - 1];
            Array.Copy(array, 0, rArray, 0, keyIndex);
            Array.Copy(array, keyIndex + 1, rArray, keyIndex, array.Length - keyIndex - 1);

            return rArray;
        }

        static List<int> CreateArrayWithoutKeyLists(List<int> array, int key)
        {
            List<int> list = new List<int>(array);
            int keyIndex = list.IndexOf(key);

            if (keyIndex == -1)
            {
                Console.WriteLine("No such key in array");
                return list;
            }

            list.RemoveAt(keyIndex);

            return list;
        }
    }
}