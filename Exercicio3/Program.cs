namespace Exercicio3;

internal static class Program
{
    private static readonly object ControleAcesso = new();
    public static void Main()
    {
        for (var i = 0; i < 20; ++i)
        {
            var t = new Thread(() => Imprimir(i));
            t.Start();
        }
    }

    static void Imprimir(object? param)
    {
       var id = (int)(param ?? 0);
       var caracteres = $"Hello World! {id}";

       lock (ControleAcesso)
       {
           foreach (var caracter in caracteres)
               Console.Write(caracter);
           Console.WriteLine();
       }
    }
}