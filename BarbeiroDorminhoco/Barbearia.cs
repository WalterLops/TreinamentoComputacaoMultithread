namespace BarbeiroDorminhoco;

public class Barbearia
{
    private int _numCadeiras;
    private Queue<int> _clientesEspera;
    private Semaphore _semBarbeiro;
    private Semaphore _semCliente;
    private Semaphore _semAcessoEspera;
    
    public Barbearia(int numCadeiras)
    {
        _numCadeiras = numCadeiras;
        _clientesEspera = new Queue<int>();
        _semBarbeiro = new Semaphore(0, 1);
        _semCliente = new Semaphore(0, numCadeiras);
        _semAcessoEspera = new Semaphore(1, 1);
    }

    public void CortarCabelo(int clienteId)
    {
        _semAcessoEspera.WaitOne(); // Adquire acesso à lista de espera

        if (_clientesEspera.Count < _numCadeiras)
        {
            _clientesEspera.Enqueue(clienteId); // Cliente senta e espera
            Console.WriteLine($"Cliente {clienteId} está esperando.");
            _semAcessoEspera.Release(); // Libera acesso à lista de espera
            _semCliente.Release(); // Notifica o barbeiro que há um cliente
            _semBarbeiro.WaitOne(); // Espera o barbeiro ficar pronto

            // Corte de cabelo sendo feito
            Console.WriteLine($"Cliente {clienteId} está tendo seu cabelo cortado.");
            Thread.Sleep(new Random().Next(1000, 2000)); 
            Console.WriteLine($"Cliente {clienteId} teve seu cabelo cortado e está saindo.");
        }
        else
        {
            Console.WriteLine($"Cliente {clienteId} foi embora porque não há cadeiras disponíveis.");
            _semAcessoEspera.Release(); // Libera acesso à lista de espera
        }
    }

    public void AtenderCliente()
    {
        while (true)
        {
            _semCliente.WaitOne(); // Espera por um cliente
            _semAcessoEspera.WaitOne(); // Adquire acesso à lista de espera

            if (_clientesEspera.Count > 0)
            {
                var cliente = _clientesEspera.Dequeue(); // Atende o próximo cliente
                _semAcessoEspera.Release(); // Libera acesso à lista de espera
                _semBarbeiro.Release(); // Notifica que o barbeiro está atendendo
                Console.WriteLine($"Barbeiro está cortando o cabelo do cliente {cliente}.");
                Thread.Sleep(new Random().Next(1000, 2000));
            }
            else
            {
                _semAcessoEspera.Release(); // Libera acesso à lista de espera
            }
        }
    }
}