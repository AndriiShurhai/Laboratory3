internal class Program
{
    private static void Main()
    {

        int[] array = { -1 };
        Console.WriteLine("How do you want to generate array? With random numbers, manually on different lines or manually in one line?(random/modl/miol): ");
        String choice = Console.ReadLine().ToLower();
        switch (choice)
        {
            case "random":
                array = RandomArray();
                break;
            case "modl":
                array = ManualArray();
                break;
            case "miol":
                array = ManualArrayLine();
                break;
            default:
                Console.WriteLine("Wrong choice, select random, modl or miol");
                break;
        }
        ShowArray(array);
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
    public static int[] ManualArray()
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
    public static int[] ManualArrayLine()
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