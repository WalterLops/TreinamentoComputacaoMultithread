namespace BarbeiroDorminhoco;

public class Program
{
    public static void Main()
    {
        var barbearia = new Barbearia(3);

        var barbeiro = new Thread(barbearia.AtenderCliente);
        barbeiro.Start(); // Inicia a thread do barbeiro

        var clientes = new Thread[10];
        for (var i = 0; i < clientes.Length; i++)
        {
            var clienteId = i;
            clientes[i] = new Thread(() => barbearia.CortarCabelo(clienteId));
            clientes[i].Start();
            Thread.Sleep(500); // Espera a chegada dos clientes
        }

        foreach (var t in clientes) 
            t.Join();
        
        barbeiro.Interrupt();
        Console.WriteLine("O barbeiro terminou o dia de trabalho.");
    }
}