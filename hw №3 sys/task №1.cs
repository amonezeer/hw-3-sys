using System;
using System.Threading;

class Program
{
    private static bool isRunning = true;

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine("        ГЕНЕРАТОР ПРОСТЫХ ЧИСЕЛ         ");
        Console.WriteLine("========================================\n");
        Console.ResetColor();

        Console.Write("введите нижнюю границу (по умолчанию 2) --> ");
        string lowerBoundInput = Console.ReadLine();
        int lowerBound = string.IsNullOrWhiteSpace(lowerBoundInput) ? 2 : int.Parse(lowerBoundInput);

        Console.Write("введите верхнюю границу --> ");
        string upperBoundInput = Console.ReadLine();
        int? upperBound = string.IsNullOrWhiteSpace(upperBoundInput) ? null : int.Parse(upperBoundInput);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nзапуск потока..\n");
        Console.ResetColor();

        Thread primeThread = new Thread(() => GeneratePrimes(lowerBound, upperBound));
        primeThread.Start();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nнажмите Enter для завершения программы\n");
        Console.ResetColor();
        Console.ReadLine();
        isRunning = false;
        primeThread.Join();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n========================================");
        Console.WriteLine("            ПРОГРАММА ЗАВЕРШЕНА          ");
        Console.WriteLine("========================================");
        Console.ResetColor();
    }

    static void GeneratePrimes(int start, int? end)
    {
        int number = start;
        while (isRunning && (!end.HasValue || number <= end.Value))
        {
            if (IsPrime(number))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[ПРОСТОЕ ЧИСЛО] -> {number}\n");
                Console.ResetColor();
            }
            number++;
            Thread.Sleep(100);
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nгенерация завершена\n");
        Console.ResetColor();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
