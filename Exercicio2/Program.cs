namespace Exrecicio2;

public static class Program
{
    public static void Main()
    {
        var n = 20;
        var listaThreads = new List<Thread>();

        for (var i = 0; i < n; ++i)
            listaThreads.Add(new Thread(Imprimir));

        for (var i = 0; i < n; ++i)
            listaThreads[i].Start(i+1);

        Console.WriteLine("Antes de Fim");

        foreach (var t in listaThreads)
            t.Join();

        Console.WriteLine("Fim");
    }
    
    static void Imprimir(object? param)
    {
        var id = (int)(param ?? 0);
        var caracteres = $"Hello World! {id}";
        
        foreach (var caracter in caracteres)
            Console.Write(caracter);
        
        Console.WriteLine();
    }
}