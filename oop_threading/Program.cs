using System;
using System.Threading;

class Program
{
    static int[] arr = new int[10];

    static void Main()
    {
        Random rnd = new Random();
        Console.Write("Масив: ");

        
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(0, 26);
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n");

        Thread T0 = new Thread(PrintGreaterThan10);
        Thread T1 = new Thread(PrintAverage);

        
        T0.Start();
        T1.Start();

        
        T0.Join();
        T1.Join();

    }

    // Потік T0
    static void PrintGreaterThan10()
    {
        Console.WriteLine("Числа більші за 10:");
        foreach (int x in arr)
        {
            if (x > 10)
                Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    // Потік T1
    static void PrintAverage()
    {
        double sum = 0;
        foreach (int x in arr)
            sum += x;

        double average = sum / arr.Length;
        Console.WriteLine("\nСереднє арифметичне: " + average);
    }
}
