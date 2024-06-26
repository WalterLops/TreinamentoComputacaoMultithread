namespace ProdutorConsumidor;

public class BufferCompartilhado
{
    private Queue<int> _fila;
    private Semaphore _cheio;
    private Semaphore _vazio;
    private Mutex _mutex;
    private int _capacidade;

    public BufferCompartilhado(int capacidade)
    {
        _capacidade = capacidade;
        _fila = new Queue<int>(capacidade);
        _cheio = new Semaphore(0, capacidade); // Começa vazio
        _vazio = new Semaphore(capacidade, capacidade); // Capacidade máxima disponível
        _mutex = new Mutex(); // Mutex para acesso exclusivo ao buffer
    }

    public void Produzir(int item)
    {
        _vazio.WaitOne(); // Espera até haver espaço disponível
        _mutex.WaitOne(); // Bloqueia o acesso ao buffer
        _fila.Enqueue(item); // Adiciona o item ao buffer
        Console.WriteLine($"Produzido: {item}");
        _mutex.ReleaseMutex(); // Libera o acesso ao buffer
        _cheio.Release(); // Indica que há mais um item no buffer
    }

    public int Consumir()
    {
        _cheio.WaitOne(); // Espera até haver algo para consumir
        _mutex.WaitOne(); // Bloqueia o acesso ao buffer
        int item = _fila.Dequeue(); // Remove o item do buffer
        Console.WriteLine($"Consumido: {item}");
        _mutex.ReleaseMutex(); // Libera o acesso ao buffer
        _vazio.Release(); // Indica que há mais espaço disponível
        return item;
    }
}