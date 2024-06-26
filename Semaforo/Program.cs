namespace Semaforo;

public class Program
{
    private static int _counter = 0;
    private static readonly Semaphore Semaphore = new(1, 1);
    
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
        Semaphore.WaitOne(); // Solicita o semáforo
        try
        {
            Thread.Sleep(new Random().Next(55,1000)); // Simulação de processamento
            _counter++; // Modificando recurso comum
            // Imprimindo o contador e o ID da thread
            Console.WriteLine($"Thread ID = {Thread.CurrentThread.ManagedThreadId}, Contador = {_counter}");
        }
        finally
        {
            Semaphore.Release(); // Libera o semáforo
        }
    }

}