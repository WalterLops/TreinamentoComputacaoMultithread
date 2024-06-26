namespace AsyncLocal;

class Exemplo
{
    static AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>();

    static ThreadLocal<string> _threadLocalString = new ThreadLocal<string>();

    static async Task MetodoAssincronoA()
    {
        // Inicia várias chamadas de método assíncrono, com diferentes valores AsyncLocal.
        // Também definimos valores ThreadLocal, para demonstrar como os dois mecanismos diferem.
        _asyncLocalString.Value = "Valor 1";
        _threadLocalString.Value = "Valor 1";
        var t1 = MetodoAssincronoB("Valor 1");

        _asyncLocalString.Value = "Valor 2";
        _threadLocalString.Value = "Valor 2";
        var t2 = MetodoAssincronoB("Valor 2");

        // Aguarda ambas as chamadas
        await t1;
        await t2;
    }

    static async Task MetodoAssincronoB(string valorEsperado)
    {
        Console.WriteLine("Entrando em MetodoAssincronoB.");
        Console.WriteLine("   Esperado '{0}', valor AsyncLocal é '{1}', valor ThreadLocal é '{2}'", 
            valorEsperado, _asyncLocalString.Value, _threadLocalString.Value);
        await Task.Delay(100);
        Console.WriteLine("Saindo de MetodoAssincronoB.");
        Console.WriteLine("   Esperado '{0}', obteve '{1}', valor ThreadLocal é '{2}'", 
            valorEsperado, _asyncLocalString.Value, _threadLocalString.Value);
    }

    static async Task Main(string[] args)
    {
        await MetodoAssincronoA();
    }
}