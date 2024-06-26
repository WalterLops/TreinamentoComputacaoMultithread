namespace Exercicio9;

public static class Program
{
    public static void Main()
    {
        var lista = new List<char>();
        
        Parallel.For(0, 20, (index) => 
        {
            
            lock (lista)
            {var nome = $"Eu sou a Thread {index}\n";
                foreach (var c in nome)
                {

                    {
                        for (var i = 0; i < 500; ++i)
                            Math.Sin(i);


                        lista.Add(c);
                    }
                }
            }
            
        });

        foreach (var c in lista)
            Console.Write(c);
        
        Console.WriteLine(lista.Count);
    }
}