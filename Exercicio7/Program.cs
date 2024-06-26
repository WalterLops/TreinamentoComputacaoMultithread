namespace Exercicio7;

public static class Program
{
    public static void Main()
    {
        using var  contexto = new Contexto();
        
        contexto.Add("TOTAL", 123.80);
        
        Print();
    }
    private static void Print()
    {
        Console.WriteLine($"Valor TOTAL = {Contexto.Get()?.Get("TOTAL")}");
    }
}