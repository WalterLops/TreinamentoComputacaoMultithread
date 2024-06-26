using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        int numFilosofos = 5;
        object[] garfos = new object[numFilosofos];
        Filosofo[] filosofos = new Filosofo[numFilosofos];
        Thread[] threads = new Thread[numFilosofos];

        // Inicializa os objetos garfos
        for (int i = 0; i < numFilosofos; i++) 
            garfos[i] = new object();

        // Inicializa os filósofos e suas threads
        for (int i = 0; i < numFilosofos; i++)
        {
            filosofos[i] = new Filosofo(i, garfos[i], garfos[(i + 1) % numFilosofos]);
            threads[i] = new Thread(filosofos[i].Jantar);
            threads[i].Start();
        }
        
        foreach (var filosofo in threads)
            filosofo.Join();
    }
}
