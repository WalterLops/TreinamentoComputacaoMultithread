
namespace Mutex_;

public static class Program
{
    private static int _counter = 0;
    private static readonly Mutex Mutex = new Mutex(false,"NmMutex");

    public static void Main()
    {
        var threads = new List<Thread>();
            
        for (var i = 0; i < 15; i++) 
            threads.Add(new Thread(IncrementCounter));

        foreach (var t in threads) 
            t.Start();
            
        foreach (var t in threads) 
            t.Join();
    }

    private static void IncrementCounter()
    {
        Mutex.WaitOne(); // Solicita o mutex
        try
        {
            Thread.Sleep(new Random().Next(55,1000)); // Simulação de processamento
            _counter++; // Modificando recurso comum
            Console.WriteLine($"Contador = {_counter}");
        }
        finally
        {
            Mutex.ReleaseMutex(); // Libera o mutex
        }
    }
}