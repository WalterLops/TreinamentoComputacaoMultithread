namespace ProdutorConsumidor;

public class Produtor
{
    private BufferCompartilhado _buffer;
    public Produtor(BufferCompartilhado buffer)
    {
        _buffer = buffer;
    }

    public void ProduzirDados()
    {
        for (int i = 0; i < 20; i++)
        {
            _buffer.Produzir(i);
            Thread.Sleep(new Random().Next(500, 1000));
        }
    }
}