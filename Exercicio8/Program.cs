namespace Exercicio8;

public static class Program
{
    public static void Main()
    {
        var n = 20;
        
        Parallel.For(0, n, Imprimir);
        
        Console.WriteLine("Fim");

        var valores = new List<int>();
        
        for (var i = 0; i < n; ++i)
            valores.Add(i);
        
        Parallel.ForEach(valores, Imprimir);
        
        Console.WriteLine("Fim");
    }
    private static void Imprimir(int i)
    {
        var caracteres = "Hello World! " + i;
        
        foreach (var caracter in caracteres)
            Console.Write(caracter);
        
        Console.WriteLine();
    }
}