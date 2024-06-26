public class Filosofo
{
    private int _id;
    private object _garfoEsquerdo;
    private object _garfoDireito;

    public Filosofo(int id, object garfoEsquerdo, object garfoDireito)
    {
        _id = id;
        _garfoEsquerdo = garfoEsquerdo;
        _garfoDireito = garfoDireito;
    }

    public void Jantar()
    {
        Pensa();
        SeAlimenta();
    }

    private void Pensa()
    {
        Console.WriteLine($"Filósofo {_id} está pensando.");
        Thread.Sleep(new Random(_id).Next(1000, 2000));
    }

    private void SeAlimenta()
    {
        // Tenta pegar os garfos
        lock (_garfoEsquerdo)
        {
            Console.WriteLine($"Filósofo {_id} pegou o garfo esquerdo.");
            Thread.Sleep(100); // Espera para simular a tentativa de pegar o outro garfo

            lock (_garfoDireito)
            {
                // Conseguiu pegar ambos os garfos
                Console.WriteLine($"Filósofo {_id} pegou o garfo direito e está se alimentando.");
                Thread.Sleep(new Random(_id).Next(1000, 2000));
            }
            // Libera o garfo direito
            Console.WriteLine($"Filósofo {_id} devolveu o garfo direito.");
        }
        // Libera o garfo esquerdo
        Console.WriteLine($"Filósofo {_id} devolveu o garfo esquerdo.");
    }
}