using System;
using System.Threading;

class Program
{
    static int[] arr = new int[10];

    static void Main()
    {
        Console.WriteLine("Введіть 10 цілих чисел у діапазоні (0 - 25):");
        for (int i = 0; i < arr.Length; i++)
        {
            int num;
            while (true)
            {
                Console.Write($"Елемент {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out num) && num >= 0 && num <= 25)
                {
                    arr[i] = num;
                    break;
                }
                Console.WriteLine("Помилка! Введіть число від 0 до 25.");
            }
        }

        foreach (var num in arr)
            Console.Write(num + " ");
        Console.WriteLine();

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
