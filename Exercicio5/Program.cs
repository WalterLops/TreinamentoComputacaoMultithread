namespace Exercicio5;

public static class Program
{
    private static bool _deveContinuar = true;

    public static void Main()
    {
        Console.WriteLine("Aperte uma tecla para iniciar a thread.");
        Console.WriteLine("Aperte novamente uma tecla para finalizar a thread.");
        
        Console.ReadKey();
        
        var t = new Thread(Rodar);
        t.Start();
        
        Console.ReadKey();
        
        _deveContinuar = false;
        
        t.Join();
        
        Console.WriteLine("FIM");
        Console.ReadKey();
    }

    static void Rodar()
    {
        int i = 0, count = 0;
        while (_deveContinuar)
            try
            {
                if (++i % 30 == 1)
                    Console.WriteLine($"Processamento {count++} realizado em background !!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Thread.Sleep(1000);
            }
    }
}