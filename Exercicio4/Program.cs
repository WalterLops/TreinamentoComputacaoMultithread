namespace Exercicio4;
public static class Program
{
    public static void Main()		
    {
        var queue = new Queue<string>();
        var isRunning = true;
        
        new Thread(() => 
        {
            while (isRunning)
                try
                {
                    var message = string.Empty;
                    lock(queue)
                    {
                        if (queue.Count > 0)
                            message = queue.Dequeue();
                        else
                            Monitor.Wait(queue);
                    }
                    if (!string.IsNullOrEmpty(message))
                        Console.WriteLine($"Você escreveu: {message}");
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e);
                }
        }).Start();

        while(true)
        {
            Console.WriteLine("Escreva uma mensagem para processamento. Escreva FIM para término.");
            
            var mensagem = Console.ReadLine() ?? "";
            
            if (mensagem == "FIM") break;
            
            lock (queue)
            {
                queue.Enqueue(mensagem);
                Monitor.Pulse(queue);
            }
        }

        isRunning = false;
        lock(queue)
            Monitor.Pulse(queue);
    }
}