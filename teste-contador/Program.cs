using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        long limit = 1_000_000_000;
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Iniciando contagem até um bilhão...");

        stopwatch.Start();
        for (long i = 0; i <= limit; i++)
        {
            if (i % 1_000_000 == 0)
            {
                Console.WriteLine($"Contagem: {i}");
            }
        }

        stopwatch.Stop();

        Console.WriteLine("Contagem concluída!");
        Console.WriteLine($"Tempo total: {stopwatch.Elapsed.TotalSeconds} segundos");
    }
}
