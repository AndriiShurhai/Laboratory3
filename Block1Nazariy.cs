using System.Runtime.ExceptionServices;
internal class Program
{
    private static void Main()
    {
        ChoosingTask();     
    }
    public static void ChoosingTask()
    {
        int[] array;
        Console.WriteLine("How do you want to generate array? With random numbers, manually on different lines or manually in one line?(random/modl/miol): ");
        String choice = Console.ReadLine().ToLower();
        switch (choice)
        {
            case "random":
                array = RandomArray();
                break;
            case "modl":
                array = ArrayEnter();
                break;
            case "miol":
                array = ArrayOneLine();
                break;
            default:
                Console.WriteLine("Wrong choice: select random, modl or miol");
                return;
        }
        Console.WriteLine("Choose a way: \n 1 - normal, 2 - using methods, 3 - using list");
        byte way = Convert.ToByte(Console.ReadLine());
        switch (way)
        {
            case 1:
                ShowArray(array);
                array = InsertAbsV14(array);
                ShowArray(array);
                break;
            case 2:
                ShowArrayLib(array);
                array = InsertAbsV14Lib(array);
                ShowArrayLib(array);
                break;
            case 3:
                List<int> list = array.ToList();
                ShowList(list);
                list = InsertAbsV14List(list);
                ShowList(list);
                break;
            default:
                Console.WriteLine("Wrong way, you lost.");
                return;
        }
    }
    public static int[] RandomArray()
    {
        Console.WriteLine("Type amount of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        Random r = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = r.Next(-101, 101);
        }
        return array;
    }
    public static int[] ArrayEnter()
    {
        Console.WriteLine("Type amount of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] modlArray = new int[n];
        Console.WriteLine("Input elements: ");
        for (int i = 0; i < n; i++)
        {
            modlArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        return modlArray;
    }
    public static int[] ArrayOneLine()
    {
        Console.WriteLine("Type elements: ");
        String[] sArray = Console.ReadLine().Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int[] array = new int[sArray.Length];
        for (int i = 0; i < sArray.Length; i++)
        {
            array[i] = Convert.ToInt32(sArray[i]);
        }
        return array;
    }
    public static void ShowArray(int[] array)
    {
        Console.WriteLine("Your array: ");
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    public static int AmountOfNegativeNumbers(int[] array)
    {
        int count = 0;
        for(int i = 0; i < array.Length; i++)
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
        if(AmountOfNegativeNumbers(array) == 0)
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
    public static void ShowArrayLib(int[] array)
    {
        Console.WriteLine("Your array: \n {0}", string.Join(' ', array));
    }
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
    public static void ShowList(List<int> list)
    {
        Console.WriteLine("Your list: \n {0}", string.Join(' ', list));
    }
    public static List<int> InsertAbsV14List(List<int> list)
    {
        if(!list.Any(x => x < 0))
        {
            Console.WriteLine("There's no negative numbers, list doesn`t changed");
            return list;
        }
        list.Capacity += list.Count(x => x < 0);
        for(int idx = 0; idx < list.Capacity - 1; idx++)
        {
            if (list.ElementAt(idx) < 0)
            {
                list.Insert(idx + 1, -list.ElementAt(idx));
            }
        }
        return list;
    }
}