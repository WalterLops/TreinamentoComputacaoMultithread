namespace Exercicio1;

public static class Program
{
    public static void Main()
    {
        var t = new Thread(Imprimir);
        t.Start();
    }
    
    private static void Imprimir()
    {
        var caracteres = "Hello World!";
        
        foreach(var caracter in caracteres)
            Console.Write(caracter);
        
        Console.WriteLine();
    }
}