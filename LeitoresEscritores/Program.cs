namespace LeitoresEscritores_;

public class Program
{
    public static void Main()
    {
        var recurso = 0;
        var controleAcesso = new LeitoresEscritores();

        var acaoLeitura = () =>
        {
            Console.WriteLine($"Valor lido: {controleAcesso.Stack.Pop()}");
            Thread.Sleep(1000);
        };

        var acaoEscrita = () =>
        {
            recurso++;
            controleAcesso.Stack.Push(recurso.ToString());
            Console.WriteLine($"Valor escrito: {recurso}");
            Thread.Sleep(1000);
        };

        var threadsLeitoresEscritores = new Thread[10];
        for (var i = 0; i < threadsLeitoresEscritores.Length; i++)
        {
            if (controleAcesso.Stack.Count > 0) // Cria um leitor
                threadsLeitoresEscritores[i] = new Thread(() => controleAcesso.Ler(acaoLeitura));
            else // Cria um escritor
                threadsLeitoresEscritores[i] = new Thread(() => controleAcesso.Escrever(acaoEscrita));
            threadsLeitoresEscritores[i].Start();
        }

        foreach (var t in threadsLeitoresEscritores) 
            t.Join();
    }
}

