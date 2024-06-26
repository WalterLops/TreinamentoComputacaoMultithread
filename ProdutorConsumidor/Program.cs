namespace ProdutorConsumidor;

public class Program
{
    public static void Main()
    {
        var buffer = new BufferCompartilhado(5);
        var produtor = new Produtor(buffer);
        var consumidor = new Consumidor(buffer);

        Thread tProdutor = new Thread(produtor.ProduzirDados);
        Thread tConsumidor = new Thread(consumidor.ConsumirDados);

        tProdutor.Start();
        tConsumidor.Start();

        tProdutor.Join();
        tConsumidor.Join();
    }
}