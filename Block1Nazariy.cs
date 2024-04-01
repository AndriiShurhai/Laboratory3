using System.Runtime.ExceptionServices;
using OutPutArrays;
namespace Block1Nazariy
{
    public class Block1N
    {
        public static int[] Run(int[] array)
        {
            Console.WriteLine("Choose a way: \n 1 - normal, 2 - using methods, 3 - using list");
            byte way = Convert.ToByte(Console.ReadLine());
            SimpleOutPut.OutputArray(array);
            switch (way)
            {
                case 1:
                    array = InsertAbsV14(array);
                    break;
                case 2:
                    array = InsertAbsV14Lib(array);
                    break;
                case 3:
                    List<int> list = array.ToList();
                    list = InsertAbsV14List(list);
                    array = list.ToArray();
                    break;
                default:
                    Console.WriteLine("Wrong way, you lost.");
                    return array;
            }
            SimpleOutPut.OutputArray(array);
            return array;
        }
        public static int AmountOfNegativeNumbers(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }
        public static int[] InsertAbsV14(int[] array)
        {
            if (AmountOfNegativeNumbers(array) == 0)
            {
                Console.WriteLine("There's no negative numbers, array doesn`t changed");
                return array;
            }
            int[] newArr = new int[AmountOfNegativeNumbers(array) + array.Length];
            int displacement = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] < 0)
                {
                    newArr[i + displacement] = array[i];
                    newArr[i + 1 + displacement] = -array[i];
                    displacement++;
                }
                else
                {
                    newArr[i + displacement] = array[i];
                }
            }
            return newArr;
        }
        // USING LIBRARY METHODS
        public static int[] InsertAbsV14Lib(int[] array)
        {
            if (!array.Any(x => x < 0))
            {
                Console.WriteLine("There's no negative numbers, array doesn`t changed");
                return array;
            }
            int[] newArr = new int[array.Count(x => x < 0) + array.Length];
            int displacement = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array.ElementAt(i) < 0)
                {
                    newArr.SetValue(array[i], i + displacement);
                    newArr.SetValue(-array[i], i + displacement + 1);
                    displacement++;
                }
                else
                {
                    newArr.SetValue(array[i], i + displacement);
                }
            }
            return newArr;
        }
        // USING LIST
        public static List<int> InsertAbsV14List(List<int> list)
        {
            if (!list.Any(x => x < 0))
            {
                Console.WriteLine("There's no negative numbers, list doesn`t changed");
                return list;
            }
            list.Capacity += list.Count(x => x < 0);
            for (int idx = 0; idx < list.Capacity - 1; idx++)
            {
                if (list.ElementAt(idx) < 0)
                {
                    list.Insert(idx + 1, -list.ElementAt(idx));
                }
            }
            return list;
        }
    }
}
