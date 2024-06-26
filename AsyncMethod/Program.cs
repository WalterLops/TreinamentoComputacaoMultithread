namespace AsyncMethod;

internal static class Program
{
    static async Task Main()
    {
        Console.WriteLine($"ID da thread principal antes da chamada não bloqueante: {Thread.CurrentThread.ManagedThreadId}");
        await NonBlockingCall();
        Console.WriteLine($"ID da thread principal depois da chamada não bloqueante: {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine($"ID da thread principal antes da chamada bloqueante: {Thread.CurrentThread.ManagedThreadId}");
        await BlockingCall();
        Console.WriteLine($"ID da thread principal depois da chamada bloqueante: {Thread.CurrentThread.ManagedThreadId}");
    }

    static async Task NonBlockingCall()
    {
        Console.WriteLine($"Início da chamada não bloqueante na thread ID: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(2000); // Simula uma tarefa assíncrona
        Console.WriteLine($"Conclusão da chamada não bloqueante na thread ID: {Thread.CurrentThread.ManagedThreadId}");
    }

    static async Task BlockingCall()
    {
        Console.WriteLine($"Início da chamada bloqueante na thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000); // Simula uma tarefa síncrona que bloqueia a thread
        Console.WriteLine($"Conclusão da chamada bloqueante na thread ID: {Thread.CurrentThread.ManagedThreadId}");
    }
}