using System;
using OutPutArrays;
namespace Block1_Karina
{
    public class Block1Karina
    {
        public static int[] Start(int[] array)
        {
            Console.WriteLine("Який спосіб? 1-вручну,2-бібліотечні методи,3-List");
            int n = Convert.ToInt32(Console.ReadLine());
            SimpleOutPut.OutputArray(array);
            switch (n)
            {
                case 1:
                    array = Block1_7(array);
                    break;
                case 2:
                    array = Block1_7_library(array);
                    break;
                case 3:
                    List<int> arrList = array.ToList();
                    arrList = Block1_7_list(arrList);
                    array=arrList.ToArray();
                    break;

                default:
                    Console.WriteLine("Введіть число");
                    break;
            }
            SimpleOutPut.OutputArray(array);
            return array;
        }
        public static int[] Block1_7(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There are no odd elements");
                return array;
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] % 2 != 0 && array[j + 1] % 2 == 0)
                    {
                        int swap = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = swap;
                    }
                }
            }
            Array.Resize(ref array, array.Length - count);
            return array;
        }


        //Library
        public static int[] Block1_7_library(int[] array)
        {
            int count = array.Count(num => num % 2 != 0);
            if (count == 0)
            {
                Console.WriteLine("There are no odd elements");
                return array;
            }
            var odd = array.Where(n => n % 2 != 0);
            var even = array.Where(n => n % 2 == 0);
            var result = even.Concat(odd).ToArray();
            Array.Copy(result, array, array.Length);
            Array.Resize(ref array, array.Length - count);
            return array;
        }
        //list
        public static List<int> Block1_7_list(List<int> listFromArr)
        {
            if (!listFromArr.Any(x => x % 2 == 0))
            {
                Console.WriteLine("There are no odd elements");
                return;
            }
            listFromArr.RemoveAll(x => x % 2 != 0);
            
            return listFromArr;
        }

    }
}
