namespace ProdutorConsumidor;

public class Consumidor
{
    private BufferCompartilhado _buffer;
    public Consumidor(BufferCompartilhado buffer)
    {
        _buffer = buffer;
    }

    public void ConsumirDados()
    {
        for (int i = 0; i < 20; i++)
        {
            int item = _buffer.Consumir();
            Thread.Sleep(new Random().Next(500, 1000));
        }
    }
}