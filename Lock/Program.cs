using System.Runtime.InteropServices.ObjectiveC;

namespace Lock;

public class Program
{
    private static int _counter = 0;
    private static readonly object LockObject = new object();
    
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
        
        Thread.Sleep(new Random().Next(55,1000)); // Simulação de processamento
        
        lock (LockObject)
        {
            _counter++; // Modificando recurso comum
            Console.WriteLine($"Counter = {_counter}");
        }
    }
}